using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using DataTire;
using Zion.ERP.Reports.DataSets;
using Zion.ERP.Reports.DataSets.SAS;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using System.IO;
using ZION.ERP.Reports.DataSets.SAS;
using ZION.ERP.Reports.DataSets;
namespace Digiteq
{
    public partial class frm_rpt_SalesStrandedReprots : MettroForm
    {
        
        //form manage

        bool bRouteSelected = false, bSelesRepSelected = false, bCustomerSelected = false, bCustomerClassSelected = false, bCustomerTypeSelected = false, bCustomerCategorySelected = false, bJobSelected = false, bJobTypeSelected = false, bSalesNoteTypeSelected = false,
            bItemClassSelected = false, bItemTypeSelected = false, bItemcatagorySelected = false, bItemSelected = false, bSalesManagerSelected = false, bAreaManagerSelected = false ,bDriverSelected=false,bDeliveroOfficerSelected=false ;// bIsItemSelected = false;
        //string sReportNo = "";
        int iReport;

        //Datasets
        public DataTable dtAllDetailRecodes = new DataTable();
        dts_Sales glb_dtsSales = new dts_Sales();
        dts_DeliveryOrders glb_dtsDeliveryOrders = new dts_DeliveryOrders();
     //   dts_JobProfile glb_dtsJobProfile = new dts_JobProfile();
        dts_PMS glb_dtsProduction = new dts_PMS();
        dts_Sales.dt_sasMonthlySalesRoportsDataTable glb_dtMonthlySales = new dts_Sales.dt_sasMonthlySalesRoportsDataTable();
        dts_sasDeliveryTracking glb_dtsSasDeliveryTracking = new dts_sasDeliveryTracking();
        dts_sasSalesReturn glb_dtsSalesReturn = new dts_sasSalesReturn();
        dts_sasSales_NoteTypeWise_ItemCategoryWise glb_dts_sasSales_NoteTypeWise_ItemCategoryWise = new dts_sasSales_NoteTypeWise_ItemCategoryWise();
        dts_sasInvoice glb_dts_sasInvoice = new dts_sasInvoice();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_Unspecified glb_dtsUnspecified = new dts_Unspecified();


        #region Form Load
        public frm_rpt_SalesStrandedReprots()
        {
            iFormID = clsSecurity.getFormID(FormName.ReportSalesStranded);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }

        private void frmReportChequeDeposit_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Sales Standard Reports", 2, iFormID);
            ThemeColor = clsFormatter.colorSales;

            clsFill.Fill_ItemPrices(ref cmbPriceCategory);
            clsFill.FillEnumDescription(typeof(prod_Costing_Mode), ref cmbCostPrice);
            CreateDataTable_Detail();

            DisplayReports();
            clearField();
            HideSelectedReports();

            //   clsFormatter.ReportPermitionOnRaioButton(ref xpanel1);
        }
        #endregion

        #region Hide Reports
        private void HideSelectedReports()
        {
            for (int i = 0; i < dgvReports.Rows.Count; i++)
            {
                if (dgvReports.Rows[i].Cells["report_ID"].Value.ToString() == ((int)enum_ReportName.ST_SalesReport_NoteTypeWise).ToString() ||
                    dgvReports.Rows[i].Cells["report_ID"].Value.ToString() == ((int)enum_ReportName.ST_SalesReport_SalesmanWise).ToString())
                {
                    if (clsSecurity.BranchName != "Cuddles Sales")
                    {
                        dgvReports.Rows.RemoveAt(i);
                        continue;
                    }
                }

                if (dgvReports.Rows[i].Cells["report_ID"].Value.ToString() == ((int)enum_ReportName.ST_DONotInvoiced).ToString())
                {
                    if (!clsConfig.bShowDONotInvoiced)
                    {
                        //dgvReports.Rows[i].Visible = false;
                        dgvReports.Rows.RemoveAt(i);
                        continue;
                    }
                }

                if (dgvReports.Rows[i].Cells["report_ID"].Value.ToString() == ((int)enum_ReportName.ST_FreeItem).ToString())
                {
                    if (!clsConfig.bShowFreeItems)
                    {
                        dgvReports.Rows.RemoveAt(i);
                        continue;
                    }
                }

                if (dgvReports.Rows[i].Cells["report_ID"].Value.ToString() == ((int)enum_ReportName.ST_CustomerOrderTrackingReport).ToString())
                {
                    if (!clsConfig.bShow_CustomerOrderTracking_Report)
                    {
                        dgvReports.Rows.RemoveAt(i);
                        continue;
                    }
                }
            }
        }
        #endregion

        #region Display Reports
        private void DisplayReports()
        {
            try
            {
                dgvReports.Rows.Clear();
                dgvReports.DataSource = DBHandling.ExecQuery("EXEC sp_Reports '" + 11 + "'").Tables[0];
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
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
                                Cursor = Cursors.WaitCursor;
                                ProgressBar.Value = 0;

                                #region Selected Search Fields
                                bRouteSelected = false; bSelesRepSelected = false; bCustomerSelected = false; bCustomerClassSelected = false; bCustomerTypeSelected = false;
                                bCustomerCategorySelected = false; bJobSelected = false; bJobTypeSelected = false; bSalesNoteTypeSelected = false; bItemClassSelected = false;
                                bItemTypeSelected = false; bItemcatagorySelected = false; bItemSelected = false; bSalesManagerSelected = false; bAreaManagerSelected = false;
                                bDriverSelected = false; bDeliveroOfficerSelected = false;
                                //bIsItemSelected = false;
                                string sFilter = "";
                                string sFormula = "";
                                string sDateRange = "From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "  To : " + dtpTo.Value.ToString("dd MMM yyyy");


                                if (txtItemClass.Tag != null && txtItemClass.Tag.ToString().Trim().Length > 0)
                                    bItemClassSelected = true;
                                if (TxtItemType.Tag != null && TxtItemType.Tag.ToString().Trim().Length > 0)
                                    bItemTypeSelected = true;
                                if (TxtItemCat.Tag != null && TxtItemCat.Tag.ToString().Trim().Length > 0)
                                    bItemcatagorySelected = true;
                                if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0)
                                    bItemSelected = true;
                                if (txtRoute.Tag != null && txtRoute.Tag.ToString().Trim().Length > 0)
                                    bRouteSelected = true;
                                if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Trim().Length > 0)
                                    bSelesRepSelected = true;
                                if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Trim().Length > 0)
                                    bCustomerSelected = true;
                                if (txtCusClass.Tag != null && txtCusClass.Tag.ToString().Trim().Length > 0)
                                    bCustomerClassSelected = true;
                                if (txtCusType.Tag != null && txtCusType.Tag.ToString().Trim().Length > 0)
                                    bCustomerTypeSelected = true;
                                if (txtCusCategory.Tag != null && txtCusCategory.Tag.ToString().Trim().Length > 0)
                                    bCustomerCategorySelected = true;
                                if (txtJobCode.Tag != null && txtJobCode.Tag.ToString().Trim().Length > 0)
                                    bJobSelected = true;
                                if (txtJobType.Tag != null && txtJobType.Tag.ToString().Trim().Length > 0)
                                    bJobTypeSelected = true;
                                if (txtSalesNoteType.Tag != null && txtSalesNoteType.Tag.ToString().Trim().Length > 0)
                                    bSalesNoteTypeSelected = true;
                                if (txtSalesManager.Tag != null && txtSalesManager.Tag.ToString().Trim().Length > 0)
                                    bSalesManagerSelected = true;
                                if (txtAreaManager.Tag != null && txtAreaManager.Tag.ToString().Trim().Length > 0)
                                    bAreaManagerSelected = true;
                                if (txtDriver.Tag != null && txtDriver.Tag.ToString().Trim().Length > 0)
                                    bDriverSelected = true;
                                if (txtDeliveryOfficer.Tag != null && txtDeliveryOfficer.Tag.ToString().Trim().Length > 0)
                                    bDeliveroOfficerSelected = true;
                                #endregion

                                #region Selected Filters
                                if (bItemClassSelected)
                                    sFilter += (sFilter.Length != 0 ? " | " : "") + "Item Class : " + txtItemClass.Text.Trim();
                                if (bItemTypeSelected)
                                    sFilter += (sFilter.Length != 0 ? " | " : "") + "Item Type : " + TxtItemType.Text.Trim();
                                if (bItemcatagorySelected)
                                    sFilter += (sFilter.Length != 0 ? " | " : "") + "Item Catagory : " + TxtItemCat.Text.Trim();
                                if (bItemSelected)
                                    sFilter += (sFilter.Length != 0 ? " | " : "") + "Item : " + txtItemID.Text.Trim();
                                if (bRouteSelected)
                                    sFilter += (sFilter.Length != 0 ? " | " : "") + "Route : " + txtRoute.Text.Trim();
                                if (bSelesRepSelected)
                                    sFilter += (sFilter.Length != 0 ? " | " : "") + "Sales Rep : " + txtSalesRep.Text.Trim();
                                if (bCustomerSelected)
                                    sFilter += (sFilter.Length != 0 ? " | " : "") + "Customer : " + txtCustomer.Text.Trim();
                                if (bCustomerTypeSelected)
                                    sFilter += (sFilter.Length != 0 ? " | " : "") + "Customer Type : " + txtCusType.Text.Trim();
                                if (bJobSelected)
                                    sFilter += (sFilter.Length != 0 ? " | " : "") + "Job Code : " + txtJobCode.Text.Trim();
                                if (bJobTypeSelected)
                                    sFilter += (sFilter.Length != 0 ? " | " : "") + "Job Type : " + txtJobType.Text.Trim();
                                if (bSalesNoteTypeSelected)
                                    sFilter += (sFilter.Length != 0 ? " | " : "") + "Sales note type : " + txtSalesNoteType.Text.Trim();
                                if (bSalesManagerSelected)
                                    sFilter += (sFilter.Length != 0 ? " | " : "") + "Sales Manager : " + txtSalesManager.Text.Trim();
                                if (bAreaManagerSelected)
                                    sFilter += (sFilter.Length != 0 ? " | " : "") + "Area Manager : " + txtAreaManager.Text.Trim();
                                if(bDriverSelected)
                                    sFilter += (sFilter.Length != 0 ? " | " : "") + "Driver : " + txtDriver.Text.Trim();
                                if (bDeliveroOfficerSelected)
                                    sFilter += (sFilter.Length != 0 ? " | " : "") + "Delivery officer : " + txtDeliveryOfficer.Text.Trim();
                                if (txtTown.Tag != null && txtTown.Tag.ToString().Length > 0)
                                    sFilter += (sFilter.Length != 0 ? " | " : "") + "Town Name : " + txtTown.Text.Trim();
                                if (cmbTaxType.Tag != null && cmbTaxType.Tag.ToString().Length > 0)
                                    sFilter += (sFilter.Length != 0 ? " | " : "") + "Tax Type : " + cmbTaxType.Text.Trim();
                                if (cmbPriceCategory.Tag != null && cmbPriceCategory.Tag.ToString().Length > 0)
                                    sFilter += (sFilter.Length != 0 ? " | " : "") + "Selling Price : " + cmbPriceCategory.Text.Trim();
                                if (cmbCostPrice.Tag != null && cmbCostPrice.Tag.ToString().Length > 0)
                                    sFilter += (sFilter.Length != 0 ? " | " : "") + "Price : " + cmbCostPrice.Text.Trim();
                                #endregion


                                #region DO Not Invoiced
                                if (Report == enum_ReportName.ST_DONotInvoiced)
                                {
                                    try
                                    {
                                        glb_dtsDeliveryOrders.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.WaitCursor;
                                        string sRouteID = "";

                                        foreach (tbl_sasDeliveryOrder detail in tbl_sasDeliveryOrder.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && p.DeliveryOrder_ID != "default" && !p.IsSeattled && !p.IsDeleted && p.DeliveryOrderDate.Date >= dtpFrom.Value.Date && p.DeliveryOrderDate.Date <= dtpTo.Value.Date))
                                        {
                                            if (bCustomerSelected)
                                            {
                                                if (detail.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            tbl_genCustomerMaster CusDetail = tbl_genCustomerMaster.Select(detail.Customer_ID);
                                            if (CusDetail != null)
                                            {
                                                #region Route
                                                if (bRouteSelected)
                                                {
                                                    if (!chkUseCustomerMasterRoute.Checked)
                                                    {
                                                        sRouteID = detail.Route_ID.ToString();
                                                    }
                                                    else
                                                    {
                                                        foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(detail.Customer_ID))
                                                        {
                                                            sRouteID = oRoute.Route_ID.ToString();
                                                            if (txtRoute.Tag.ToString() == sRouteID)
                                                                break;
                                                        }
                                                    }

                                                    if (txtRoute.Tag.ToString() != sRouteID)
                                                        continue;
                                                }
                                                #endregion

                                                if (bCustomerClassSelected)
                                                {
                                                    if (CusDetail.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (CusDetail.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (CusDetail.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }
                                            }

                                            string sSalesman = "";
                                            tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                                            if (order != null)
                                            {
                                                sSalesman = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                                            }

                                            glb_dtsDeliveryOrders.dt_deliveryOrderHeader.Adddt_deliveryOrderHeaderRow(detail.DeliveryOrder_ID, detail.DeliveryOrderDate, detail.Remark, detail.Customer_ID, clsGenaralName.getName_Customer(detail.Customer_ID), clsGenaralName.getName_CustomerDeliveryAddress(detail.Customer_ID), "", "", "", detail.Store_ID, clsGenaralName.getName_Store(detail.Store_ID),
                                                "", detail.OrderRefNo_ID, detail.Vehicle_No, detail.SubTotal, detail.DiscountTotal, detail.DiscountPercentage, detail.NbtTotal, detail.NbtPercentage, detail.VatTotal, detail.VatPercentage, 0, 0, detail.GrandTotal, detail.Employee_ID, detail.IsWeightCalculation, sSalesman, detail.IsDeleted, 0, DateTime.MinValue, "", "", "", "", "", "", "");
                                        }

                                        glb_dtsDeliveryOrders.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsDeliveryOrders, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.ST_DONotInvoiced));

                                    }
                                    catch (Exception)
                                    {
                                        throw;
                                    }
                                    finally
                                    {
                                        glb_dtsDeliveryOrders.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.Default;
                                    }
                                }
                                #endregion

                                #region Sales Price List (MRP)
                                else if (Report == enum_ReportName.ST_SalesPriceList_MRP)
                                {
                                    Cursor = Cursors.WaitCursor;

                                    dts_Sales glb_dts_Sales = new dts_Sales();
                                    glb_dts_Sales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Sales Price List ", "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                    dts_ReportExport glb_dts_ExportReport = new dts_ReportExport();

                                    string sItemCat = bItemcatagorySelected ? TxtItemCat.Tag.ToString() : "%";
                                    string sItem = bItemSelected ? txtItemID.Tag.ToString() : "%";

                                    string sQuary = "exec [srh_sasSalesPriceReport] '" + sItem + "', '" + sItemCat + "' ";

                                    glb_dts_Sales.dt_sasSalesPriceList.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                    frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();
                                    CRViwer.print("\\Reports\\SAS\\Standard\\rpt_sas_SalesPriceList_MRP.rpt", glb_dts_Sales, glb_dts_ExportReport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    Cursor = Cursors.Default;
                                }
                                #endregion

                                #region Delevery Report Pending
                                else if (Report == enum_ReportName.St_DelevaryReport_Pending || Report == enum_ReportName.St_DelevaryReport_Deleverd|| Report==enum_ReportName.St_DelevaryReport_Deleverd_Summary)
                                {
                                    dts_Unspecified glb_dts_sasDeliveryOrder = new dts_Unspecified();

                                    Cursor = Cursors.WaitCursor;

                                    //  DataSets.dts_Sales glb_dts_Sales = new DataSets.dts_Sales();
                                    glb_dts_sasDeliveryOrder.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                    dts_ReportExport glb_dts_ExportReport = new dts_ReportExport();

                                    string customer_ID = bCustomerSelected ? txtCustomer.Tag.ToString() : "";
                                    string route_ID = bRouteSelected ? txtRoute.Tag.ToString().Trim() : "";
                                    string Driver = bDriverSelected ? txtDriver.Tag.ToString() : "";
                                    string DeliveryOfficer = bDeliveroOfficerSelected ? txtDeliveryOfficer.Tag.ToString() : "";
                                    string sQuary = "exec sp_GetRPT_sasDeliveryOrder_DoDate '" + customer_ID + "', '" + route_ID + "' ,'" + Driver + "' ,'"+ DeliveryOfficer + "' ,'"+ dtpFrom.Value.Date.ToString("dd-MMM-yyyy") + "','" + dtpTo.Value.ToString("dd-MMM-yyyy") + "'," + ((Report == enum_ReportName.St_DelevaryReport_Pending) ? "0" : "1");

                                    glb_dts_sasDeliveryOrder.dt_Unspecified_01.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                    frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();
                                    CRViwer.print(sReportPath, glb_dts_sasDeliveryOrder, glb_dts_ExportReport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    Cursor = Cursors.Default;
                                }
                                #endregion



                                #region  Monthly Sales Summary Report
                                else if (Report == enum_ReportName.ST_MounthlySalesSummaryReport)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsSales.Clear();
                                        string sRouteID = "", sSalesmanID = "";

                                        //fill data table                            

                                        List<tbl_sasInvoice> oInvoiceList = tbl_sasInvoice.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => !p.IsDeleted && p.Invoice_ID != "default"
                                        && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date
                                        && !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque).ToList();

                                        foreach (tbl_sasInvoice oInvoice in oInvoiceList)
                                        {
                                            if (bCustomerSelected)
                                                if (oInvoice.Customer_ID != txtCustomer.Tag.ToString())
                                                    continue;

                                            tbl_genCustomerMaster CusDetail = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                            if (CusDetail != null)
                                            {
                                                #region Route
                                                if (bRouteSelected)
                                                {
                                                    if (!chkUseCustomerMasterRoute.Checked)
                                                    {
                                                        sRouteID = oInvoice.Route_ID.ToString();
                                                    }
                                                    else
                                                    {
                                                        foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oInvoice.Customer_ID))
                                                        {
                                                            sRouteID = oRoute.Route_ID.ToString();
                                                            if (txtRoute.Tag.ToString() == sRouteID)
                                                                break;
                                                        }
                                                    }

                                                    if (txtRoute.Tag.ToString() != sRouteID)
                                                        continue;
                                                }
                                                #endregion

                                                #region Sales Rep
                                                if (chkUseCustomerMastorSaleRep.Checked)
                                                    sSalesmanID = CusDetail.SalesRep_ID;
                                                else
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }

                                                if (bSelesRepSelected)
                                                {
                                                    if (sSalesmanID != txtSalesRep.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                #endregion

                                                if (bCustomerClassSelected)
                                                {
                                                    if (CusDetail.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (CusDetail.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (CusDetail.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }
                                            }

                                            decimal dTotalWeight = 0, dTotalQty = 0;
                                            foreach (tbl_sasInvoice_Detail oInvoiceDetails in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID))
                                            {
                                                dTotalWeight += oInvoiceDetails.Weight;
                                                dTotalQty += oInvoiceDetails.Qty;
                                            }

                                            glb_dtsSales.dt_sasMonthlySalesReport_Summary.Adddt_sasMonthlySalesReport_SummaryRow(oInvoice.Invoice_ID, oInvoice.InvoiceDate,
                                                "", "", oInvoice.GrandTotal, dTotalWeight, dTotalQty, oInvoice.InvoiceDate.Month, oInvoice.InvoiceDate.Year.ToString());
                                            //clsHelpMethods_Local.startProgressBar(0, oInvoiceList.Count + 2, 1, ProgressBar);
                                        }

                                        glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Annual Sales Report Summary ", "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                        //print("\\Reports\\SAS\\Standard\\rpt_sas_SalesMonthWise.rpt", " Monthly Sales report Summary", glb_dtsSales, "");
                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print("\\Reports\\SAS\\Standard\\rpt_sas_SalesMonthWise.rpt", glb_dtsSales, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glb_dtsSales.Clear();
                                    }
                                }

                                #endregion

                                #region Sales Report [Item-wise]
                                else if (Report == enum_ReportName.ST_Sales_Report_Itemwise)
                                {
                                    sFormula = " {vw_rpt_sasInvoice.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasInvoice.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                    sFormula += " and {vw_rpt_sasInvoice.isDeleted} = " + false;
                                    if (txtSalesRep.Tag != null)
                                        sFormula += " and {vw_rpt_sasInvoice.salesRep_ID}= '" + txtSalesRep.Tag.ToString().Trim() + "' ";
                                    print("\\reports\\SAS\\Standard\\rpt_sas_ItemWiseSalesReport.rpt", " Sales Report [Item-wise] ", sFormula, sFilter);
                                }
                                #endregion

                                #region Sales Report Summary [Item-wise]
                                else if (Report == enum_ReportName.ST_Sales_Report_Summary_ItemWise)
                                {
                                    sFormula = " {vw_rpt_sasInvoice.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasInvoice.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                                    sFormula += " and {vw_rpt_sasInvoice.isDeleted} = " + false;
                                    if (txtSalesRep.Tag != null)
                                        sFormula += " and {vw_rpt_sasInvoice.salesRep_ID}= '" + txtSalesRep.Tag.ToString().Trim() + "' ";
                                    print("\\reports\\SAS\\Standard\\rpt_sas_ItemWiseSalesReportSummary.rpt", " Sales Report Summary [Item-wise] ", sFormula, sFilter);
                                }
                                #endregion

                                #region Tax Reports Summary
                                //else if (Report == enum_ReportName.ST_Tax_Report_Invoice_LocalNBTVAT || (Report == enum_ReportName.ST_Tax_Report_Invoice_LocalSVAT) || (Report == enum_ReportName.ST_Tax_Report_Invoice_ExportSVAT))
                                else if (Report == enum_ReportName.ST_Tax_Report_Invoice_ExportSVAT)
                                {
                                    //bool bPermissionValid = false;
                                    glb_dtsSales.Clear();
                                    string sRouteID = "", sSalesmanID = "";

                                    if (cmbTaxType.Text.Trim() == "Local NBT/VAT")
                                    {
                                        //if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Tax_Report_Invoice_LocalNBTVAT)))
                                        Report = enum_ReportName.ST_Tax_Report_Invoice_LocalNBTVAT;
                                        //if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID((Report))))
                                        //{
                                        //    bPermissionValid = true;
                                        #region Local NBT/VAT
                                        List<tbl_sasInvoice> Query = tbl_sasInvoice.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => !p.IsDeleted && p.Invoice_ID != "default" && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date
                                                               && !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque && !p.IsSVatInvoice && p.Currency_ID == clsConfig.sLocalCurrencyCode).ToList();

                                        foreach (tbl_sasInvoice oInvoice in Query)
                                        {
                                            if (bCustomerSelected)
                                            {
                                                if (oInvoice.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            tbl_genCustomerMaster CusDetail = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                            if (CusDetail != null)
                                            {
                                                #region Route
                                                if (bRouteSelected)
                                                {
                                                    if (!chkUseCustomerMasterRoute.Checked)
                                                    {
                                                        sRouteID = oInvoice.Route_ID.ToString();
                                                    }
                                                    else
                                                    {
                                                        foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oInvoice.Customer_ID))
                                                        {
                                                            sRouteID = oRoute.Route_ID.ToString();
                                                            if (txtRoute.Tag.ToString() == sRouteID)
                                                                break;
                                                        }
                                                    }

                                                    if (txtRoute.Tag.ToString() != sRouteID)
                                                        continue;
                                                }
                                                #endregion

                                                #region Sales Rep
                                                if (chkUseCustomerMastorSaleRep.Checked)
                                                    sSalesmanID = CusDetail.SalesRep_ID;
                                                else
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }

                                                if (bSelesRepSelected)
                                                {
                                                    if (sSalesmanID != txtSalesRep.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                #endregion

                                                if (bCustomerClassSelected)
                                                {
                                                    if (CusDetail.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (CusDetail.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (CusDetail.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }
                                            }

                                            //decimal dWithNBTAmount = oInvoice.GrandTotal * 100 / (100 + oInvoice.VatPercentage);
                                            //decimal dNetTotal = dWithNBTAmount * 100 / (100 + oInvoice.NbtPercentage);
                                            //decimal dNBTAmount = dWithNBTAmount - dNetTotal;
                                            //decimal dVatAmount = oInvoice.GrandTotal - dWithNBTAmount;

                                            decimal dWithNBTAmount = 0, dSubTotal = 0, dNBTAmount = 0, dVatAmount = 0;
                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvoice.GrandTotal, oInvoice.VatPercentage, oInvoice.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);

                                            glb_dtsSales.dtTaxSummary.AdddtTaxSummaryRow(oInvoice.InvoiceDate, dSubTotal, dNBTAmount, dWithNBTAmount, dVatAmount, "INV", oInvoice.GrandTotal,
                                                clsGenaralName.getName_CurrencyCode(oInvoice.Currency_ID), oInvoice.CurrencyRate, clsHelpMethods_Local.getDisplayPrice(dWithNBTAmount, oInvoice.CurrencyRate),
                                                clsHelpMethods_Local.getDisplayPrice(dVatAmount, oInvoice.CurrencyRate));
                                            clsHelpMethods_Local.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
                                        }
                                        sReportTitle_Main = "Tax Reports Summary [Local NBT/VAT]";
                                        sReportPath = "\\reports\\SAS\\Standard\\rpt_sas_TaxReportSummary.rpt";
                                        #endregion
                                        //}
                                    }
                                    else if (cmbTaxType.Text.Trim() == "Export VAT")//"Local SVAT"
                                    {
                                        //if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Tax_Report_Invoice_LocalSVAT)))
                                        Report = enum_ReportName.ST_Tax_Report_Invoice_LocalSVAT;
                                        //if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID((Report))))
                                        //{
                                        //    bPermissionValid = true;

                                        #region Local SVAT
                                        foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => !p.IsDeleted && p.Invoice_ID != "default" && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date
                                                               && !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque && p.IsSVatInvoice && p.Currency_ID == clsConfig.sLocalCurrencyCode))
                                        {
                                            //decimal dWithNBTAmount = oInvoice.GrandTotal * 100 / (100 + oInvoice.VatPercentage);
                                            //decimal dNetTotal = 0;
                                            //decimal dNBTAmount = 0;
                                            //decimal dVatAmount = oInvoice.GrandTotal - dWithNBTAmount;

                                            decimal dWithNBTAmount = 0, dSubTotal = 0, dNBTAmount = 0, dVatAmount = 0;
                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvoice.GrandTotal, oInvoice.VatPercentage, oInvoice.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);

                                            glb_dtsSales.dtTaxSummary.AdddtTaxSummaryRow(oInvoice.InvoiceDate, dSubTotal, dNBTAmount, dWithNBTAmount, dVatAmount, "INV",
                                                oInvoice.GrandTotal, clsGenaralName.getName_CurrencyCode(oInvoice.Currency_ID), oInvoice.CurrencyRate,
                                                clsHelpMethods_Local.getDisplayPrice(dWithNBTAmount, oInvoice.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(dVatAmount, oInvoice.CurrencyRate));
                                        }
                                        sReportTitle_Main = "Tax Reports Summary [Local SVAT]";
                                        //sReportPath = "\\reports\\SAS\\Standard\\rpt_sas_TaxReportLocalSVATSummary.rpt";
                                        sReportPath = "\\reports\\SAS\\Standard\\rpt_sas_TaxReportSummary_InvoiceLocal_SVAT.rpt";
                                        //Standard\\rpt_sas_TaxReportDetail_InvoiceLocal_NBT_VAT.rpt";
                                        #endregion
                                        //}
                                    }
                                    else if (cmbTaxType.Text.Trim() == "Export SVAT")
                                    {
                                        //if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Tax_Report_Invoice_ExportSVAT)))
                                        Report = enum_ReportName.ST_Tax_Report_Invoice_ExportSVAT;
                                        //if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID((Report))))
                                        //{
                                        //    bPermissionValid = true;
                                        #region Export SVAT
                                        foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => !p.IsDeleted && p.Invoice_ID != "default" && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date
                                                             && !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque && p.IsSVatInvoice && p.Currency_ID != clsConfig.sLocalCurrencyCode))
                                        {
                                            //decimal dWithNBTAmount = oInvoice.GrandTotal * 100 / (100 + oInvoice.VatPercentage);
                                            //decimal dNetTotal = 0;
                                            //decimal dNBTAmount = 0;
                                            //decimal dVatAmount = oInvoice.GrandTotal - dWithNBTAmount;

                                            decimal dWithNBTAmount = 0, dSubTotal = 0, dNBTAmount = 0, dVatAmount = 0;
                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvoice.GrandTotal, oInvoice.VatPercentage, oInvoice.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);

                                            glb_dtsSales.dtTaxSummary.AdddtTaxSummaryRow(oInvoice.InvoiceDate, dSubTotal, dNBTAmount, dWithNBTAmount, dVatAmount, "INV", oInvoice.GrandTotal,
                                                clsGenaralName.getName_CurrencyCode(oInvoice.Currency_ID), oInvoice.CurrencyRate, clsHelpMethods_Local.getDisplayPrice(dWithNBTAmount, oInvoice.CurrencyRate),
                                                clsHelpMethods_Local.getDisplayPrice(dVatAmount, oInvoice.CurrencyRate));
                                            //glbDtsSales.dt_sasTurnOver.Adddt_sasTurnOverRow(oInv.Invoice_ID, oInv.InvoiceDate, oInv.Customer_ID, clsGenaralName.getName_Customer(oInv.Customer_ID), bIsExport, sJobType, clsHelpMethods.getDisplayPrice(oInv.GrandTotal, oInv.CurrencyRate), clsGenaralName.getName_CurrencyCode(oInv.Currency_ID), oInv.CurrencyRate, "default");
                                        }
                                        sReportTitle_Main = "Tax Reports Summary [Export SVAT]";
                                        //sReportPath = "\\reports\\SAS\\Standard\\rpt_sas_InvoiceExport_Detail_AKT.rpt.rpt";
                                        sReportPath = "\\reports\\SAS\\Standard\\rpt_sas_TaxReportSummary_InvoiceExport_SVAT.rpt";

                                        #endregion
                                        //}
                                    }

                                    //if (bPermissionValid)
                                    //{
                                    #region tbl_bpsCreditNote
                                    foreach (tbl_bpsCreditNote oCRN in tbl_bpsCreditNote.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && p.CreditNoteType_ID != clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit)))//
                                    {
                                        if (oCRN.IsDeleted == false && oCRN.CreditNoteDate >= dtpFrom.Value && oCRN.CreditNoteDate <= dtpTo.Value && oCRN.Currency_ID == clsConfig.sLocalCurrencyCode)
                                        {
                                            //decimal dWithNBTAmount = oCRN.TotalAmount * 100 / (100 + oCRN.VatPercentage);
                                            //decimal dNetTotal = dWithNBTAmount * 100 / (100 + oCRN.NbtPercentage);
                                            //decimal dNBTAmount = dWithNBTAmount - dNetTotal;
                                            //decimal dVatAmount = oCRN.TotalAmount - dWithNBTAmount;

                                            decimal dWithNBTAmount = 0, dSubTotal = 0, dNBTAmount = 0, dVatAmount = 0;
                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oCRN.TotalAmount, oCRN.VatPercentage, oCRN.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);

                                            //dtAllDetailRecodes.Rows.Add(oCRN.CreditNoteDate, dNetTotal, dNBTAmount, dWithNBTAmount, dVatAmount, "CRN");
                                            glb_dtsSales.dtTaxSummary.AdddtTaxSummaryRow(oCRN.CreditNoteDate, dSubTotal, dNBTAmount, dWithNBTAmount, dVatAmount, "CRN", oCRN.TotalAmount,
                                                clsGenaralName.getName_CurrencyCode(oCRN.Currency_ID), oCRN.CurrencyRate, clsHelpMethods_Local.getDisplayPrice(dWithNBTAmount, oCRN.CurrencyRate),
                                                clsHelpMethods_Local.getDisplayPrice(dVatAmount, oCRN.CurrencyRate));

                                            sReportTitle_Main = "Tax Reports Summary [Export SVAT]";
                                            //sReportPath = "\\reports\\SAS\\Standard\\rpt_sas_InvoiceExport_Detail_AKT.rpt.rpt";
                                            sReportPath = "\\reports\\SAS\\Standard\\rpt_sas_TaxReportSummary_InvoiceExport_SVAT.rpt";
                                        }
                                    }
                                    #endregion

                                    glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                    frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    rpt.print(sReportPath, glb_dtsSales, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    // print(sReportPath, sReportTitle, glb_dtsSales.dtTaxSummary, "");
                                    //}
                                }
                                #endregion

                                #region Tax  Reports Details (Invoice)
                                //else if (Report == enum_ReportName.ST_Tax_Report_Invoice_DetailLocalNBTVAT || Report == enum_ReportName.ST_Tax_Report_Invoice_DetailExportVAT || Report == enum_ReportName.ST_Tax_Report_Invoice_DetailExportSVAT)
                                else if (Report == enum_ReportName.ST_Tax_Report_Invoice_DetailLocalNBTVAT)
                                {
                                    glb_dtsSales.dt_sasTaxDetails_Invoice.Rows.Clear();
                                    string sRouteID = "";
                                    string sInvoiceType = "";
                                    //bool bPermissionValid = false;

                                    #region Local NBT/VAT
                                    if (cmbTaxType.Text.Trim() == "Local NBT/VAT" || cmbTaxType.Text.Trim() == "Local VAT (Excluding: NBT)")
                                    {
                                        Report = enum_ReportName.ST_Tax_Report_Invoice_DetailLocalNBTVAT;
                                        //if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(Report)))
                                        //{
                                        //    bPermissionValid = true;
                                        List<tbl_sasInvoice> Query = tbl_sasInvoice.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => !p.IsDeleted && p.Invoice_ID != "default" && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date
                                                                     //&& !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque && p.OtherTaxTotal == 0).ToList();
                                                                     && !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque && p.OtherTaxTotal == 0 && !(!p.IsVatInvoice && !p.IsSVatInvoice)).ToList();

                                        foreach (tbl_sasInvoice oInvoice in Query)
                                        {
                                            //Added by Gayan 2016-08-26 - Reason : Note Type filter is not working
                                            if (bSalesNoteTypeSelected)
                                                if (txtSalesNoteType.Tag.ToString() != oInvoice.SalesNoteType_ID)
                                                    continue;
                                            //*******************************************************************//

                                            if (bCustomerSelected)
                                            {
                                                if (oInvoice.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            tbl_genCustomerMaster CusDetail = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                            if (CusDetail != null)
                                            {
                                                #region Route
                                                if (bRouteSelected)
                                                {
                                                    if (!chkUseCustomerMasterRoute.Checked)
                                                    {
                                                        sRouteID = oInvoice.Route_ID.ToString();
                                                    }
                                                    else
                                                    {
                                                        foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oInvoice.Customer_ID))
                                                        {
                                                            sRouteID = oRoute.Route_ID.ToString();
                                                            if (txtRoute.Tag.ToString() == sRouteID)
                                                                break;
                                                        }
                                                    }

                                                    if (txtRoute.Tag.ToString() != sRouteID)
                                                        continue;
                                                }
                                                #endregion

                                                if (bCustomerClassSelected)
                                                {
                                                    if (CusDetail.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (CusDetail.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (CusDetail.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }
                                            }

                                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                            //tbl_pmsProductionJobRegister oProductionRegister = tbl_pmsProductionJobRegister.Select(oInvoice.Job_ID);

                                            #region filter - DO type
                                            //string sDoType = "";
                                            //if (oProductionRegister != null)
                                            //{
                                            //    if (oProductionRegister.ProductionJobType_ID == "PJT/001" || oProductionRegister.ProductionJobType_ID == "PJT/002")
                                            //        sDoType = "Kandana";
                                            //    else if (oProductionRegister.ProductionJobType_ID == "PJT/003" || oProductionRegister.ProductionJobType_ID == "PJT/004")
                                            //        sDoType = "Pettah";
                                            //    else if (oProductionRegister.ProductionJobType_ID == "PJT/009" || oProductionRegister.ProductionJobType_ID == "PJT/010")
                                            //        sDoType = "Direct";
                                            //    else if (oProductionRegister.ProductionJobType_ID == "PJT/013" || oProductionRegister.ProductionJobType_ID == "PJT/014")
                                            //        sDoType = "Block";
                                            //    else if (oProductionRegister.ProductionJobType_ID == "PJT/011" || oProductionRegister.ProductionJobType_ID == "PJT/012")
                                            //        sDoType = "Chemical";
                                            //    else
                                            //        sDoType = "-";

                                            //    if (cmbDOType.Text != "<All Type>")
                                            //    {
                                            //        if (cmbDOType.Text.Trim() != sDoType)
                                            //            continue;
                                            //    }
                                            //}
                                            #endregion

                                            //for fillter Job Code type
                                            //if (txtJobType.Tag != null && txtJobType.Tag.ToString().Length > 0 && txtJobType.Tag.ToString().Trim() != "default")
                                            //{
                                            //    if (oProductionRegister != null)
                                            //    {
                                            //        if (oProductionRegister.ProductionJobType_ID != txtJobType.Tag.ToString().Trim())
                                            //            continue;
                                            //    }
                                            //}

                                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                            {
                                                if (oInvoice.Job_ID != "default") //With Job
                                                {
                                                    //tbl_pmsProductionJobRegister oJob = tbl_pmsProductionJobRegister.Select(oInvoice.Job_ID);
                                                    //if (oJob != null)
                                                    //    sInvoiceType = clsGenaralName.getName_ProductionJobType(oJob.ProductionJobType_ID);
                                                }
                                                else if (oInvoice.DeliveryOrder_ID != "default") //Direct Sales
                                                {
                                                    sInvoiceType = "Direct Sales";
                                                }
                                                else
                                                    sInvoiceType = (oInvoice.IsVatInvoice) ? "Vat Invoice" : (oInvoice.IsSVatInvoice) ? "SVat Invoice" : "Non Tax Invoice";

                                                if (oInvoice.Quotation_ID != "default") //Block Sales
                                                    sInvoiceType = "Block Invoice";
                                            }
                                            else
                                            {
                                                if (clsConfig.bSalesNoteType_SerialNoActiveFor_Invoice)
                                                    sInvoiceType = clsGenaralName.getName_SalesNoteType(oInvoice.SalesNoteType_ID);
                                                else
                                                    sInvoiceType = (oInvoice.IsVatInvoice) ? "Vat Invoice" : (oInvoice.IsSVatInvoice) ? "SVat Invoice" : "Non Tax Invoice";
                                            }

                                            //if (oProductionRegister != null & oCustomer != null)
                                            //{
                                            //    // if (oCustomer.CustomerType_ID != "2") //Local Customers Only
                                            //    {
                                            //        string sPONo = "";
                                            //        if (oInvoice.Job_ID == "default" && oInvoice.DeliveryOrder_ID != "default") //Direct Sales
                                            //            sPONo = clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID);
                                            //        else if (oInvoice.Quotation_ID != "default" && oInvoice.DeliveryOrder_ID == "default") //Block Invoice
                                            //            sPONo = clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID);
                                            //        else if (oInvoice.Job_ID != "default" && oInvoice.DeliveryOrder_ID != "default") //Normal Invoice
                                            //            sPONo = clsHelpMethods_Local.GetPONoByProductionJobID(oInvoice.Job_ID);

                                            //        decimal dWithNBTAmount = 0, dSubTotal = 0, dNBTAmount = 0, dVatAmount = 0, dCurrencyTotal = 0, dCurrencyVat = 0;
                                            //        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvoice.GrandTotal, oInvoice.VatPercentage, oInvoice.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                            //        dCurrencyTotal = oInvoice.GrandTotal;
                                            //        dCurrencyVat = dVatAmount / oInvoice.CurrencyRate;

                                            //        if (cmbTaxType.Text.Trim() == "Local VAT (Excluding: NBT)")
                                            //        {
                                            //            dSubTotal = dWithNBTAmount;
                                            //            dNBTAmount = 0;
                                            //            if (oInvoice.SalesNoteType_ID == clsConfig.sHC_NonVatSalesNoteTypeID)
                                            //            {
                                            //                dSubTotal += dVatAmount;
                                            //                dWithNBTAmount = dSubTotal;
                                            //                dVatAmount = 0;
                                            //            }
                                            //        }
                                            //        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                            //        {
                                            //            if (oInvoice.Quotation_ID != "default")//for block invoice
                                            //            {
                                            //                dSubTotal = dWithNBTAmount;
                                            //                dNBTAmount = 0;
                                            //            }
                                            //        }
                                            //        //glb_dtsSales.dt_sasTaxDetails_Invoice.Adddt_sasTaxDetails_InvoiceRow(oInvoice.Invoice_ID, oInvoice.InvoiceDate, 
                                            //        //    clsGenaralName.getName_Customer(oInvoice.Customer_ID), 
                                            //        //    oInvoice.GrandTotal, dSubTotal, dNBTAmount, dVatAmount, dWithNBTAmount, sPONo, oInvoice.DeliveryOrder_ID, oInvoice.Job_ID,  oInvoice.CurrencyRate, clsGenaralName.getName_CurrencyCode(oInvoice.Currency_ID),
                                            //        //    clsGenaralName.getName_ProductionJobType(oProductionRegister.ProductionJobType_ID), 
                                            //        //    oInvoice.DateCreate, dCurrencyTotal, dCurrencyVat, sInvoiceType);
                                            //        glb_dtsSales.dt_sasTaxDetails_Invoice.Adddt_sasTaxDetails_InvoiceRow(oInvoice.Invoice_ID, oInvoice.InvoiceDate,
                                            //           oCustomer.VatRegistrationNo != "" ? clsGenaralName.getName_Customer(oInvoice.Customer_ID) + "\nVAT Reg : " + oCustomer.VatRegistrationNo : clsGenaralName.getName_Customer(oInvoice.Customer_ID), clsGenaralName.getName_BranchCustomer(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID)),
                                            //            oInvoice.GrandTotal, dSubTotal, dNBTAmount, dVatAmount, dWithNBTAmount, sPONo, oInvoice.DeliveryOrder_ID, oInvoice.Job_ID, oInvoice.CurrencyRate, clsGenaralName.getName_CurrencyCode(oInvoice.Currency_ID),
                                            //            "",
                                            //            oInvoice.DateCreate, dCurrencyTotal, dCurrencyVat, sInvoiceType);
                                            //    }
                                            //}
                                            clsHelpMethods_Local.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
                                        }
                                        if (cmbTaxType.Text.Trim() == "Local VAT (Excluding: NBT)")
                                            sReportTitle_Main = "Tax Report Detail - Invoice [Local VAT]";
                                        else
                                            sReportTitle_Main = "Tax Report Detail - Invoice [Local NBT/VAT]";

                                        sReportPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(Report));
                                        if (sReportPath == null || sReportPath.Length == 0)
                                        {
                                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                                sReportPath = "\\reports\\SAS\\Standard\\rpt_sas_TaxReportDetail_InvoiceLocal_NBT_VAT.rpt";
                                            else
                                                sReportPath = "\\reports\\SAS\\Standard\\rpt_sas_TaxReportDetail_InvoiceLocal_NBT_VAT_AKI.rpt";
                                        }
                                        //}
                                    }
                                    #endregion

                                    #region Export VAT
                                    else if (cmbTaxType.Text.Trim() == "Export VAT" || cmbTaxType.Text.Trim() == "DSE Zero Rated")
                                    {
                                        //if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Tax_Report_Invoice_DetailExportVAT)))
                                        //{
                                        //    bPermissionValid = true;
                                        List<tbl_sasInvoice> Query = tbl_sasInvoice.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => !p.IsDeleted && p.Invoice_ID != "default" && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date
                                                                     //&& !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque && p.VatTotal >= 0 && p.OtherTaxTotal == 0).ToList();
                                                                     && !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque && p.VatTotal >= 0 && p.OtherTaxTotal == 0 && !(!p.IsVatInvoice && !p.IsSVatInvoice)).ToList();

                                        foreach (tbl_sasInvoice oInvoice in Query)
                                        {
                                            //Added by Gayan 2016-08-26 - Reason : Note Type filter is not working
                                            if (bSalesNoteTypeSelected)
                                                if (txtSalesNoteType.Tag.ToString() != oInvoice.SalesNoteType_ID)
                                                    continue;
                                            //*******************************************************************//

                                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                            {
                                                if (oInvoice.Quotation_ID != "default")
                                                    sInvoiceType = "Block Invoice";
                                            }

                                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                          //  tbl_pmsProductionJobRegister oProductionRegister = tbl_pmsProductionJobRegister.Select(oInvoice.Job_ID);

                                            #region filter - DO type
                                            string sDoType = "";
                                            //if (oProductionRegister != null)
                                            //{
                                            //    if (oProductionRegister.ProductionJobType_ID == "PJT/001" || oProductionRegister.ProductionJobType_ID == "PJT/002")
                                            //        sDoType = "Kandana";
                                            //    else if (oProductionRegister.ProductionJobType_ID == "PJT/003" || oProductionRegister.ProductionJobType_ID == "PJT/004")
                                            //        sDoType = "Pettah";
                                            //    else if (oProductionRegister.ProductionJobType_ID == "PJT/009" || oProductionRegister.ProductionJobType_ID == "PJT/010")
                                            //        sDoType = "Direct";
                                            //    else if (oProductionRegister.ProductionJobType_ID == "PJT/013" || oProductionRegister.ProductionJobType_ID == "PJT/014")
                                            //        sDoType = "Block";
                                            //    else if (oProductionRegister.ProductionJobType_ID == "PJT/011" || oProductionRegister.ProductionJobType_ID == "PJT/012")
                                            //        sDoType = "Chemical";
                                            //    else
                                            //        sDoType = "-";



                                            //    if (cmbDOType.Text != "<All Type>")
                                            //    {
                                            //        if (cmbDOType.Text.Trim() != sDoType)
                                            //            continue;
                                            //    }
                                            //}
                                            #endregion

                                            //for fillter Job Code type
                                            if (txtJobType.Tag != null && txtJobType.Tag.ToString().Length > 0 && txtJobType.Tag.ToString().Trim() != "default")
                                            {
                                                //if (oProductionRegister != null)
                                                //{
                                                //    if (oProductionRegister.ProductionJobType_ID != txtJobType.Tag.ToString().Trim())
                                                //        continue;
                                                //}
                                            }

                                            string sPONo = "";
                                            if (oInvoice.Job_ID == "default" && oInvoice.DeliveryOrder_ID != "default") //Direct Sales
                                                sPONo = clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID);
                                            else if (oInvoice.Quotation_ID != "default" && oInvoice.DeliveryOrder_ID == "default") //Block Invoice
                                                sPONo = clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID);
                                            else if (oInvoice.Job_ID != "default" && oInvoice.DeliveryOrder_ID != "default") //Normal Invoice
                                                sPONo = clsHelpMethods_Local.GetPONoByProductionJobID(oInvoice.Job_ID);

                                            decimal dWithNBTAmount = 0, dSubTotal = 0, dNBTAmount = 0, dVatAmount = 0, dCurrencyTotal = 0, dCurrencyVat = 0;
                                            //if (oProductionRegister != null & oCustomer != null)
                                            //{
                                            //    if (oCustomer.CustomerType_ID == "2") //Export Customers Only
                                            //    {
                                            //        #region If Export VAT Selected
                                            //        if (cmbTaxType.Text.Trim() == "Export VAT")
                                            //        {
                                            //            if (oCustomer.IsVATenable && !oCustomer.IsSVATenable && !oCustomer.IsNBTenable)
                                            //            {
                                            //                dSubTotal = oInvoice.GrandTotal;
                                            //                dNBTAmount = 0;
                                            //                dVatAmount = 0;
                                            //                dWithNBTAmount = oInvoice.GrandTotal;
                                            //                dCurrencyVat = 0;
                                            //                dCurrencyTotal = oInvoice.GrandTotal;
                                            //            }
                                            //            else
                                            //                continue;
                                            //        }
                                            //        #endregion

                                            //        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvoice.GrandTotal, oInvoice.VatPercentage, oInvoice.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                            //        dCurrencyTotal = dSubTotal / oInvoice.CurrencyRate;
                                            //        dCurrencyVat = dVatAmount / oInvoice.CurrencyRate;

                                            //        #region Only For AKT
                                            //        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                            //        {
                                            //            if (oInvoice.Quotation_ID != "default")//for block invoice
                                            //            {
                                            //                dSubTotal = dWithNBTAmount;
                                            //                dNBTAmount = 0;
                                            //            }
                                            //        }
                                            //        #endregion

                                            //        #region If Zero Rated Selected
                                            //        if (cmbTaxType.Text.Trim() == "DSE Zero Rated")
                                            //        {
                                            //            if (!oCustomer.IsVATenable && !oCustomer.IsSVATenable && !oCustomer.IsNBTenable)
                                            //            {
                                            //                dSubTotal = oInvoice.GrandTotal;
                                            //                dNBTAmount = 0;
                                            //                dVatAmount = 0;
                                            //                dWithNBTAmount = oInvoice.GrandTotal;
                                            //                dCurrencyVat = 0;
                                            //                dCurrencyTotal = oInvoice.GrandTotal;
                                            //            }
                                            //            else
                                            //                continue;
                                            //        }
                                            //        #endregion

                                            //        glb_dtsSales.dt_sasTaxDetails_Invoice.Adddt_sasTaxDetails_InvoiceRow(oInvoice.Invoice_ID, oInvoice.InvoiceDate,
                                            //            oCustomer.VatRegistrationNo != "" ? clsGenaralName.getName_Customer(oInvoice.Customer_ID) + "\nVAT Reg : " + oCustomer.VatRegistrationNo : clsGenaralName.getName_Customer(oInvoice.Customer_ID), clsGenaralName.getName_BranchCustomer(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID)),
                                            //            oInvoice.GrandTotal, dSubTotal,
                                            //            dNBTAmount, dVatAmount, dWithNBTAmount, sPONo, oInvoice.DeliveryOrder_ID, oInvoice.Job_ID, oInvoice.CurrencyRate, clsGenaralName.getName_CurrencyCode(oInvoice.Currency_ID),
                                            //            clsGenaralName.getName_ProductionJobType(oProductionRegister.ProductionJobType_ID), oInvoice.DateCreate, dCurrencyTotal, dCurrencyVat, sInvoiceType);

                                            //    }
                                            //}
                                            clsHelpMethods_Local.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
                                        }

                                        if (cmbTaxType.Text.Trim() == "DSE Zero Rated")
                                            sReportTitle_Main = "Tax Report Detail - Invoice [Zero Rated]";
                                        else
                                            sReportTitle_Main = "Tax Report Detail - Invoice [Export VAT]";

                                        sReportPath = "\\reports\\SAS\\Standard\\rpt_sas_TaxReportDetail_InvoiceExport_VAT.rpt";
                                        //}
                                    }
                                    #endregion

                                    #region Export SVAT
                                    else if (cmbTaxType.Text.Trim() == "Export SVAT")
                                    {
                                        //if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Tax_Report_Invoice_DetailExportSVAT)))
                                        //{
                                        //    bPermissionValid = true;
                                        int iInvoicecount = 0;
                                        decimal dTotalAmount = 0;
                                        Invoice_ExportSvat(ref sReportPath, ref sReportTitle_Main, ref sInvoiceType, ref iInvoicecount, ref dTotalAmount);
                                        //}
                                    }
                                    #endregion

                                    //if (bPermissionValid)
                                    glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                    frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    rpt.print(sReportPath, glb_dtsSales, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    // print(sReportPath, sReportTitle, glb_dtsSales.dt_sasTaxDetails_Invoice, sFilter);
                                }
                                #endregion

                                #region Tax  Reports (Credit Note-Local)
                                else if (Report == enum_ReportName.ST_Tax_Report_CreditNote)
                                {
                                    //if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Tax_Report_CreditNote)))
                                    //{
                                    //clear the data table
                                    glb_dtsSales.dt_sasTaxDetails_CreditNote.Rows.Clear();
                                    glb_dtsSales.dt_sasCreditNote_InvoiceAllocation.Rows.Clear();

                                    bool bSVAT = false;
                                    string sSalesmanID = "";
                                    //bool bPermissionValid = false;
                                    if (cmbTaxType.Text.Trim() == "Local NBT/VAT")
                                    {
                                        //if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Tax_Reports_Invoice_LocalNBTCreditNote)))
                                        //{
                                        //bPermissionValid = true;
                                        #region Local NBT/VAT
                                        List<tbl_bpsCreditNote> Query = tbl_bpsCreditNote.SelectAll().Where(p => !p.IsDeleted && p.CreditNote_ID != "default" && p.Currency_ID == clsConfig.sLocalCurrencyCode
                                           && p.CreditNoteDate.Date >= dtpFrom.Value.Date && p.CreditNoteDate.Date <= dtpTo.Value.Date
                                           && p.CreditNoteType_ID != clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit) && p.CreditNoteType_ID != clsAutocode.getCreditNoteTypeID(CreditNoteType.BadDebts)
                                           && p.CompanyBranch_ID == txtBranch.Tag.ToString()).ToList();

                                        foreach (tbl_bpsCreditNote oCreditNote in Query)
                                        {
                                            if (bCustomerSelected)
                                            {
                                                if (oCreditNote.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oCreditNote.Customer_ID);
                                            if (oCustomer != null)
                                            {
                                                #region Sales Rep
                                                if (chkUseCustomerMastorSaleRep.Checked)
                                                    sSalesmanID = oCustomer.SalesRep_ID;
                                                else
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oCreditNote.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }

                                                if (bSelesRepSelected)
                                                {
                                                    if (sSalesmanID != txtSalesRep.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                #endregion

                                                #region Customer Filters
                                                if (bCustomerClassSelected)
                                                {
                                                    if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                #endregion

                                                if (oCustomer.CustomerType_ID != "2")
                                                {
                                                    decimal dWithNBTAmount = 0, dSubTotal = 0, dNBTAmount = 0, dVatAmount = 0;
                                                    int iRecordCount = 0;

                                                    foreach (tbl_bpsCreditNote_Invoice oCRNInvoice in tbl_bpsCreditNote_Invoice.SelectAllByCreditNote_ID(oCreditNote.CreditNote_ID))
                                                    {
                                                        tbl_sasInvoice_Sattled oInvStl = tbl_sasInvoice_Sattled.Select(oCRNInvoice.Invoice_ID, "default", "default", oCreditNote.CreditNote_ID, "default", "default", "default");
                                                        if (oInvStl != null)
                                                        {
                                                            tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oCRNInvoice.Invoice_ID);
                                                            if (oInvoice != null)
                                                            {
                                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvStl.SattledAmount, oInvoice.VatPercentage, oInvoice.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                                                glb_dtsSales.dt_sasTaxDetails_CreditNote.Adddt_sasTaxDetails_CreditNoteRow(oCreditNote.CreditNote_ID, oCreditNote.CreditNoteDate, oCustomer.VatRegistrationNo != "" ? clsGenaralName.getName_Customer(oCreditNote.Customer_ID) + "\nVAT Reg : " + oCustomer.VatRegistrationNo : clsGenaralName.getName_Customer(oCreditNote.Customer_ID), oInvStl.SattledAmount,
                                                                    dSubTotal, clsGenaralName.getName_CreditNoteType(oCreditNote.CreditNoteType_ID), oCreditNote.Invoice_ID, oInvoice.InvoiceDate, dVatAmount, dNBTAmount, dWithNBTAmount, clsGenaralName.getName_CurrencyCode(oCreditNote.Currency_ID),
                                                                    oCreditNote.CurrencyRate, clsHelpMethods_Local.getDisplayPrice(dSubTotal, oCreditNote.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(dVatAmount, oCreditNote.CurrencyRate),
                                                                    dSubTotal, "", oCreditNote.IsDeleted, oCreditNote.PrintCount, oCRNInvoice.Invoice_ID, oInvStl.SattledAmount, oCreditNote.Remark, "", clsSecurity.getServerDateTime().Date,
                                                                    oCreditNote.TotalAmount, oCreditNote.VatTotal, oCreditNote.NbtTotal, oCreditNote.SubTotal, iRecordCount, "", "", 0, 0, "");
                                                                iRecordCount++;
                                                            }
                                                        }
                                                    }
                                                    if (iRecordCount == 0)// If No Invoice record available
                                                    {
                                                        string sInvoiceID = "-";
                                                        DateTime dtmInvoiceDate = new DateTime();

                                                        tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oCreditNote.Invoice_ID);
                                                        if (oInvoice != null || oInvoice.Invoice_ID == "default")
                                                        {
                                                            //  sInvoiceID = oInvoice.Invoice_ID;
                                                            //  dtmInvoiceDate = oInvoice.InvoiceDate;
                                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oCreditNote.TotalAmount, oInvoice.VatPercentage, oInvoice.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                                        }
                                                        else
                                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oCreditNote.TotalAmount, oCreditNote.VatPercentage, oCreditNote.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);

                                                        glb_dtsSales.dt_sasTaxDetails_CreditNote.Adddt_sasTaxDetails_CreditNoteRow(oCreditNote.CreditNote_ID, oCreditNote.CreditNoteDate, oCustomer.VatRegistrationNo != "" ? clsGenaralName.getName_Customer(oCreditNote.Customer_ID) + "\nVAT Reg : " + oCustomer.VatRegistrationNo : clsGenaralName.getName_Customer(oCreditNote.Customer_ID), oCreditNote.TotalAmount,
                                                                dSubTotal, clsGenaralName.getName_CreditNoteType(oCreditNote.CreditNoteType_ID), sInvoiceID, dtmInvoiceDate, dVatAmount, dNBTAmount, dWithNBTAmount, clsGenaralName.getName_CurrencyCode(oCreditNote.Currency_ID),
                                                                oCreditNote.CurrencyRate, clsHelpMethods_Local.getDisplayPrice(dSubTotal, oCreditNote.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(dVatAmount, oCreditNote.CurrencyRate), dSubTotal, "",
                                                                oCreditNote.IsDeleted, oCreditNote.PrintCount, oCreditNote.Invoice_ID, 0, oCreditNote.Remark, "", clsSecurity.getServerDateTime().Date,
                                                                oCreditNote.TotalAmount, oCreditNote.VatTotal, oCreditNote.NbtTotal, oCreditNote.SubTotal, iRecordCount, "", "", 0, 0, "");
                                                    }
                                                }
                                            }
                                            clsHelpMethods_Local.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
                                        }

                                        sReportTitle_Main = "Tax Report Detail - Credit Note [Local NBT/VAT]";
                                        sReportPath = "\\reports\\SAS\\Standard\\rpt_sas_TaxReportDetail_CreditNoteLocal_NBT_VAT.rpt";
                                        #endregion
                                        //}
                                    }
                                    else if (cmbTaxType.Text.Trim() == "Export VAT")
                                    {
                                        //if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Tax_Reports_Invoice_LocalSVATCreditNote)))
                                        //{
                                        //bPermissionValid = true;
                                        #region Local SVAT
                                        List<tbl_bpsCreditNote> Query = tbl_bpsCreditNote.SelectAll().Where(p => !p.IsDeleted && p.CreditNote_ID != "default" && p.OtherTaxTotal == 0
                                            && p.CreditNoteDate.Date >= dtpFrom.Value.Date && p.CreditNoteDate.Date <= dtpTo.Value.Date && p.CreditNoteType_ID != clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit) && p.CreditNoteType_ID != clsAutocode.getCreditNoteTypeID(CreditNoteType.BadDebts) && p.CompanyBranch_ID == txtBranch.Tag.ToString()).ToList();

                                        foreach (tbl_bpsCreditNote oCreditNote in Query)
                                        {
                                            decimal dWithNBTAmount = 0, dSubTotal = 0, dNBTAmount = 0, dVatAmount = 0;
                                            int iRecordCount = 0;

                                            if (bCustomerSelected)
                                            {
                                                if (oCreditNote.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oCreditNote.Customer_ID);
                                            if (oCustomer != null)
                                            {
                                                #region Customer Filters
                                                if (bCustomerClassSelected)
                                                {
                                                    if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                #endregion
                                                if (oCustomer.CustomerType_ID == "2")
                                                {
                                                    foreach (tbl_bpsCreditNote_Invoice oCRNInvoice in tbl_bpsCreditNote_Invoice.SelectAllByCreditNote_ID(oCreditNote.CreditNote_ID))
                                                    {
                                                        tbl_sasInvoice_Sattled oInvStl = tbl_sasInvoice_Sattled.Select(oCRNInvoice.Invoice_ID, "default", "default", oCreditNote.CreditNote_ID, "default", "default", "default");
                                                        if (oInvStl != null)
                                                        {
                                                            tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oCRNInvoice.Invoice_ID);
                                                            if (oInvoice != null)
                                                            {
                                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvStl.SattledAmount, oCreditNote.VatPercentage, oCreditNote.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                                                glb_dtsSales.dt_sasTaxDetails_CreditNote.Adddt_sasTaxDetails_CreditNoteRow(oCreditNote.CreditNote_ID, oCreditNote.CreditNoteDate, oCustomer.VatRegistrationNo != "" ? clsGenaralName.getName_Customer(oCreditNote.Customer_ID) + "\nVAT Reg : " + oCustomer.VatRegistrationNo : clsGenaralName.getName_Customer(oCreditNote.Customer_ID), oInvStl.SattledAmount,
                                                                    dSubTotal, oCreditNote.CreditNoteType_ID, oCreditNote.Invoice_ID, oInvoice.InvoiceDate, dVatAmount, dNBTAmount, dWithNBTAmount, clsGenaralName.getName_CurrencyCode(oCreditNote.Currency_ID),
                                                                    oCreditNote.CurrencyRate, clsHelpMethods_Local.getDisplayPrice(dSubTotal, oCreditNote.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(dVatAmount, oCreditNote.CurrencyRate),
                                                                    dSubTotal, "", oCreditNote.IsDeleted, oCreditNote.PrintCount, oCRNInvoice.Invoice_ID, oInvStl.SattledAmount, oCreditNote.Remark, "", clsSecurity.getServerDateTime().Date,
                                                                    oCreditNote.TotalAmount, oCreditNote.VatTotal, oCreditNote.NbtTotal, oCreditNote.SubTotal, iRecordCount, "", "", 0, 0, "");
                                                                iRecordCount++;
                                                            }
                                                        }
                                                    }
                                                    if (iRecordCount == 0 && oCreditNote.Invoice_ID != "default")// If No record available
                                                    {
                                                        tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oCreditNote.Invoice_ID);
                                                        if (oInvoice != null)
                                                        {
                                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oCreditNote.TotalAmount, oCreditNote.VatPercentage, oCreditNote.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                                            glb_dtsSales.dt_sasTaxDetails_CreditNote.Adddt_sasTaxDetails_CreditNoteRow(oCreditNote.CreditNote_ID, oCreditNote.CreditNoteDate, oCustomer.VatRegistrationNo != "" ? clsGenaralName.getName_Customer(oCreditNote.Customer_ID) + "\nVAT Reg : " + oCustomer.VatRegistrationNo : clsGenaralName.getName_Customer(oCreditNote.Customer_ID), oCreditNote.TotalAmount,
                                                                dSubTotal, oCreditNote.CreditNoteType_ID, oCreditNote.Invoice_ID, oInvoice.InvoiceDate, dVatAmount, dNBTAmount, dWithNBTAmount, clsGenaralName.getName_CurrencyCode(oCreditNote.Currency_ID),
                                                                oCreditNote.CurrencyRate, clsHelpMethods_Local.getDisplayPrice(dSubTotal, oCreditNote.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(dVatAmount, oCreditNote.CurrencyRate),
                                                                dSubTotal, "", oCreditNote.IsDeleted, oCreditNote.PrintCount, oCreditNote.Invoice_ID, oCreditNote.TotalAmount, oCreditNote.Remark, "", clsSecurity.getServerDateTime().Date,
                                                                oCreditNote.TotalAmount, oCreditNote.VatTotal, oCreditNote.NbtTotal, oCreditNote.SubTotal, iRecordCount, "", "", 0, 0, "");
                                                        }
                                                    }
                                                }
                                            }
                                            clsHelpMethods_Local.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
                                        }

                                        sReportTitle_Main = "Tax Report Detail - Credit Note [Export VAT]";
                                        sReportPath = "\\reports\\SAS\\Standard\\rpt_sas_TaxReportDetail_CreditNoteLocal_SVAT.rpt";

                                        #endregion
                                        //}
                                    }
                                    else if (cmbTaxType.Text.Trim() == "Export SVAT")
                                    {
                                        //if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Tax_Reports_Invoice_ExportSVATCreditNote)))
                                        //{
                                        //bPermissionValid = true;
                                        #region Export SVAT
                                        int iCreditnotecount = 0;
                                        decimal dTotalAmount = 0;
                                        Creditnote_ExportSvat(ref sReportPath, ref sReportTitle_Main, ref bSVAT, ref iCreditnotecount, ref dTotalAmount);
                                        #endregion
                                        //}
                                    }
                                    else if (cmbTaxType.Text.Trim() == "Local VAT (Excluding: NBT)")
                                    {
                                        //if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.ST_Tax_Reports_Invoice_LocalNBTCreditNote)))
                                        //{
                                        //bPermissionValid = true;
                                        #region Local VAT (Excluding: NBT)
                                        List<tbl_bpsCreditNote> Query = tbl_bpsCreditNote.SelectAll().Where(p => !p.IsDeleted && p.CreditNote_ID != "default" && p.Currency_ID == clsConfig.sLocalCurrencyCode
                                           && p.CreditNoteDate.Date >= dtpFrom.Value.Date && p.CreditNoteDate.Date <= dtpTo.Value.Date && p.CreditNoteType_ID != "'" + clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit) + "'" && p.CreditNoteType_ID != clsAutocode.getCreditNoteTypeID(CreditNoteType.BadDebts) && p.CompanyBranch_ID == txtBranch.Tag.ToString()).ToList();

                                        foreach (tbl_bpsCreditNote oCreditNote in Query)
                                        {
                                            if (bCustomerSelected)
                                            {
                                                if (oCreditNote.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oCreditNote.Customer_ID);
                                            if (oCustomer != null)
                                            {
                                                #region Customer Filters
                                                if (bCustomerClassSelected)
                                                {
                                                    if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                #endregion
                                                if (oCustomer.CustomerType_ID != "2")
                                                {
                                                    decimal dWithNBTAmount = 0, dSubTotal = 0, dNBTAmount = 0, dVatAmount = 0;
                                                    int iRecordCount = 0;
                                                    string sCreditNoteType = "";

                                                    foreach (tbl_bpsCreditNote_Invoice oCRNInvoice in tbl_bpsCreditNote_Invoice.SelectAllByCreditNote_ID(oCreditNote.CreditNote_ID))
                                                    {
                                                        tbl_sasInvoice_Sattled oInvStl = tbl_sasInvoice_Sattled.Select(oCRNInvoice.Invoice_ID, "default", "default", oCreditNote.CreditNote_ID, "default", "default", "default");
                                                        if (oInvStl != null)
                                                        {
                                                            tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oCRNInvoice.Invoice_ID);
                                                            if (oInvoice != null && oInvoice.Invoice_ID != "default")
                                                            {
                                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvStl.SattledAmount, oInvoice.VatPercentage, oInvoice.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                                                if (oInvoice.SalesNoteType_ID == clsConfig.sHC_NonVatSalesNoteTypeID)//"SN001") //SN001 = VAT Sales                                                            
                                                                {
                                                                    dVatAmount = 0;
                                                                    dWithNBTAmount = oInvStl.SattledAmount;
                                                                }
                                                                sCreditNoteType = clsGenaralName.getName_SalesNoteType(oInvoice.SalesNoteType_ID);
                                                                dSubTotal = dWithNBTAmount;
                                                                dNBTAmount = 0;

                                                                glb_dtsSales.dt_sasTaxDetails_CreditNote.Adddt_sasTaxDetails_CreditNoteRow(oCreditNote.CreditNote_ID, oCreditNote.CreditNoteDate, oCustomer.VatRegistrationNo != "" ? clsGenaralName.getName_Customer(oCreditNote.Customer_ID) + "\nVAT Reg : " + oCustomer.VatRegistrationNo : clsGenaralName.getName_Customer(oCreditNote.Customer_ID), oInvStl.SattledAmount,
                                                                dSubTotal, sCreditNoteType, oCreditNote.Invoice_ID, oInvoice.InvoiceDate, dVatAmount, dNBTAmount, dWithNBTAmount, clsGenaralName.getName_CurrencyCode(oCreditNote.Currency_ID),
                                                                oCreditNote.CurrencyRate, clsHelpMethods_Local.getDisplayPrice(dSubTotal, oCreditNote.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(dVatAmount, oCreditNote.CurrencyRate),
                                                                dSubTotal, "", oCreditNote.IsDeleted, oCreditNote.PrintCount, oCRNInvoice.Invoice_ID, oInvStl.SattledAmount, oCreditNote.Remark, "", clsSecurity.getServerDateTime().Date,
                                                                oCreditNote.TotalAmount, oCreditNote.VatTotal, oCreditNote.NbtTotal, oCreditNote.SubTotal, iRecordCount, "", "", 0, 0, "");
                                                                iRecordCount++;
                                                            }
                                                        }
                                                    }
                                                    if (iRecordCount == 0 && oCreditNote.Invoice_ID != "default")// If No Invoice record available
                                                    {
                                                        string sInvoiceID = "";
                                                        DateTime dtmInvoiceDate = new DateTime();
                                                        tbl_sasInvoice oInvoice1 = tbl_sasInvoice.Select(oCreditNote.Invoice_ID);
                                                        if (oInvoice1 != null && oInvoice1.Invoice_ID != "default")
                                                        {
                                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oCreditNote.TotalAmount, oInvoice1.VatPercentage, oInvoice1.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                                            sInvoiceID = oInvoice1.Invoice_ID;
                                                            dtmInvoiceDate = oInvoice1.InvoiceDate;
                                                            sCreditNoteType = clsGenaralName.getName_SalesNoteType(oInvoice1.SalesNoteType_ID);

                                                            if (oCreditNote.SalesNoteType_ID != "SN001") //SN001 = VAT Sales                                                            
                                                            {
                                                                dVatAmount = 0;
                                                                dWithNBTAmount = oCreditNote.TotalAmount * 100 / (100 + oInvoice1.VatPercentage);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oCreditNote.TotalAmount, oCreditNote.VatPercentage, oCreditNote.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                                            sCreditNoteType = clsGenaralName.getName_SalesNoteType(oCreditNote.SalesNoteType_ID);
                                                            if (oCreditNote.SalesNoteType_ID != "SN001") //SN001 = VAT Sales                                                            
                                                            {
                                                                dVatAmount = 0;
                                                                dWithNBTAmount = oCreditNote.TotalAmount * 100 / (100 + oCreditNote.VatPercentage);
                                                            }
                                                        }
                                                        dSubTotal = dWithNBTAmount;
                                                        dNBTAmount = 0;
                                                        if (oCreditNote.SalesNoteType_ID == clsConfig.sHC_NonVatSalesNoteTypeID)
                                                        {
                                                            dSubTotal += dVatAmount;
                                                            dVatAmount = 0;
                                                        }
                                                        glb_dtsSales.dt_sasTaxDetails_CreditNote.Adddt_sasTaxDetails_CreditNoteRow(oCreditNote.CreditNote_ID, oCreditNote.CreditNoteDate, oCustomer.VatRegistrationNo != "" ? clsGenaralName.getName_Customer(oCreditNote.Customer_ID) + "\nVAT Reg : " + oCustomer.VatRegistrationNo : clsGenaralName.getName_Customer(oCreditNote.Customer_ID), oCreditNote.TotalAmount,
                                                            dSubTotal, sCreditNoteType, sInvoiceID, dtmInvoiceDate, dVatAmount, dNBTAmount, dWithNBTAmount, clsGenaralName.getName_CurrencyCode(oCreditNote.Currency_ID),
                                                            oCreditNote.CurrencyRate, clsHelpMethods_Local.getDisplayPrice(dSubTotal, oCreditNote.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(dVatAmount, oCreditNote.CurrencyRate), dSubTotal, "",
                                                            oCreditNote.IsDeleted, oCreditNote.PrintCount, oCreditNote.Invoice_ID, oCreditNote.TotalAmount, oCreditNote.Remark, "", clsSecurity.getServerDateTime().Date,
                                                            oCreditNote.TotalAmount, oCreditNote.VatTotal, oCreditNote.NbtTotal, oCreditNote.SubTotal, iRecordCount, "", "", 0, 0, "");
                                                    }
                                                }
                                            }
                                            clsHelpMethods_Local.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
                                        }

                                        sReportTitle_Main = "Tax Report Detail - Credit Note - Local VAT (Excluding: NBT)";
                                        sReportPath = "\\reports\\SAS\\Standard\\rpt_sas_TaxReportDetail_CreditNoteLocal_NBT_VAT.rpt";
                                        #endregion
                                        //}
                                    }
                                    //if (bPermissionValid)
                                    //{
                                    if (cmbTaxType.Text.Trim() == "Export SVAT" && txtCustomer.Tag != null)

                                        print(sReportPath, sReportTitle_Main, glb_dtsSales.dt_sasTaxDetails_CreditNote, sFilter);
                                    else
                                        print(sReportPath, sReportTitle_Main, glb_dtsSales, sFilter, clsAutocode.getReportID(Report));
                                    //}
                                    //}
                                }

                                #endregion

                                #region SVat 4
                                else if (Report == enum_ReportName.ST_Svat_04)
                                {
                                    try
                                    {
                                        if (txtCustomer.Tag != null)
                                        {
                                            #region Export SVAT Credit Note
                                            string sTemp1 = "", sTemp2 = "";
                                            bool bTemp3 = true;
                                            int iCreditnotecount = 0;
                                            decimal dTotalAmount = 0;
                                            Creditnote_ExportSvat(ref sTemp1, ref sTemp2, ref bTemp3, ref iCreditnotecount, ref dTotalAmount);
                                            #endregion

                                            #region Export SVAT Invoice
                                            int iInvoicecount = 0;
                                            decimal dTotalAmountInvoice = 0;
                                            string sTemp4 = "";
                                            Invoice_ExportSvat(ref sTemp1, ref sTemp2, ref sTemp4, ref iInvoicecount, ref dTotalAmountInvoice);
                                            #endregion

                                            #region For Cpnsignee
                                            bool isConsignee = false;
                                            tbl_genCustomerMaster_Consignee oConsignee = tbl_genCustomerMaster_Consignee.Select(1, (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Length > 0) ? txtCustomer.Tag.ToString() : "defult");
                                            if (oConsignee != null && oConsignee.Customer_ID != "default")
                                                isConsignee = true;
                                            #endregion

                                            Cursor = Cursors.WaitCursor;
                                            string s_Path = "", sHeaderTitle = "Standed Reports", sReportTitle = "Goods/Services Declaration under SVATS";
                                            CrystalDecisions.CrystalReports.Engine.ReportDocument objRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                            s_Path = Application.StartupPath.Replace("\\Mini ERP\\bin\\Debug", "\\ZION.ERP.Reports");

                                            s_Path += @"\Reports\SAS\Standard\rpt_sas_Svat_04.rpt";
                                            objRpt.Load(s_Path);

                                            objRpt.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                                            objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                                            objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "  To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                                            objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                                            objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                                            objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                                            objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                                            objRpt.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
                                            objRpt.DataDefinition.FormulaFields["CompanySVatNo"].Text = clsCommon.fncsetstring(clsCommon.getCompanySVAT());
                                            objRpt.DataDefinition.FormulaFields["CompanyVatNo"].Text = clsCommon.fncsetstring(clsCommon.getCompanyVAT());
                                            objRpt.DataDefinition.FormulaFields["sReportNo"].Text = clsCommon.fncsetstring(iReport.ToString());

                                            objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                                            objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                                            //objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);

                                            objRpt.DataDefinition.FormulaFields["CustomerName"].Text = isConsignee ? clsCommon.fncsetstring(oConsignee.ConsigneeName.ToString()) : clsCommon.fncsetstring(txtCustomer.Text.Trim());
                                            tbl_genCustomerMaster odetail = tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString().Trim());
                                            if (odetail != null && odetail.Customer_ID != "default")
                                            {
                                                objRpt.DataDefinition.FormulaFields["CustomeVatNo"].Text = isConsignee ? clsCommon.fncsetstring(oConsignee.VatRegistrationNo.ToString()) : clsCommon.fncsetstring(odetail.VatRegistrationNo);
                                                objRpt.DataDefinition.FormulaFields["CustomeSVatNo"].Text = isConsignee ? clsCommon.fncsetstring(oConsignee.SvatRegistrationNo.ToString()) : clsCommon.fncsetstring(odetail.SvatRegistrationNo);
                                                objRpt.DataDefinition.FormulaFields["CustomerAddress"].Text = isConsignee ? clsCommon.fncsetstring(oConsignee.ConsigneeAddress.ToString().Replace("\n", " ").Replace("\t", " ").Replace("\r", " ")) : clsCommon.fncsetstring(clsGenaralName.getName_CustomerRegisterAddress(odetail.Customer_ID).Replace("\n", " ").Replace("\t", " ").Replace("\r", " "));
                                                objRpt.DataDefinition.FormulaFields["CustomerEmail"].Text = clsCommon.fncsetstring(odetail.Email);
                                            }

                                            objRpt.DataDefinition.FormulaFields["CreditNoteTotal"].Text = clsCommon.fncsetstring(clsFormatter.FormatDecimalPlaces_Price(dTotalAmount).ToString());
                                            objRpt.DataDefinition.FormulaFields["CreditNoteCount"].Text = clsCommon.fncsetstring(iCreditnotecount.ToString());

                                            objRpt.DataDefinition.FormulaFields["TotalAmount"].Text = clsCommon.fncsetstring(clsFormatter.FormatDecimalPlaces_Price(dTotalAmountInvoice - dTotalAmount).ToString());
                                            objRpt.DataDefinition.FormulaFields["SvatAmount"].Text = clsCommon.fncsetstring(clsFormatter.FormatDecimalPlaces_Price((dTotalAmountInvoice - dTotalAmount) * clsCommon.getPesentageOtherTax() / 100).ToString());

                                            if (isConsignee)
                                            {
                                                objRpt.DataDefinition.FormulaFields["ConInvoiceTotal"].Text = clsCommon.fncsetstring(clsFormatter.FormatDecimalPlaces_Price(dTotalAmountInvoice).ToString());
                                                objRpt.DataDefinition.FormulaFields["InvoiceCount"].Text = clsCommon.fncsetstring(iInvoicecount.ToString());
                                                objRpt.DataDefinition.FormulaFields["InvoiceTotal"].Text = clsCommon.fncsetstring("-");

                                                // var field = objRpt.ReportDefinition.ReportObjects["InvoiceTotal"];
                                                //  field.ObjectFormat.HorizontalAlignment = Alignment.Justified;

                                            }
                                            else
                                            {
                                                objRpt.DataDefinition.FormulaFields["InvoiceTotal"].Text = clsCommon.fncsetstring(clsFormatter.FormatDecimalPlaces_Price(dTotalAmountInvoice).ToString());
                                                objRpt.DataDefinition.FormulaFields["InvoiceCount"].Text = clsCommon.fncsetstring(iInvoicecount.ToString());
                                                objRpt.DataDefinition.FormulaFields["ConInvoiceTotal"].Text = clsCommon.fncsetstring("-");

                                                // var field = objRpt.ReportDefinition.ReportObjects["ConInvoiceTotal"];
                                                // field.ObjectFormat.HorizontalAlignment = Alignment.Justified;
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
                                        else
                                            MessageBox.Show("Select The Customer", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);

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

                                #region Turn Over Statement
                                else if (Report == enum_ReportName.ST_Monthly_Turn_Over_Statement_CustomerWise || Report == enum_ReportName.ST_Monthly_Turn_Over_Statement_SalesmanWise)
                                {
                                    string sSalesmanID = "", sRouteID = "", sRepName = "";
                                    bool bIsSalesRepWise = false;

                                    if (Report == enum_ReportName.ST_Monthly_Turn_Over_Statement_CustomerWise)
                                    {
                                        if (sReportTitle_Main != "" && sReportTitle_Main != null)
                                            sRepName = sReportTitle_Main;
                                        else
                                            sRepName = " Turn Over Statement (Customer-Wise)";
                                    }
                                    else
                                    {
                                        if (sReportTitle_Main != "" && sReportTitle_Main != null)
                                            sRepName = sReportTitle_Main;
                                        else
                                            sRepName = " Turn Over Statement (Salesman-Wise)";

                                        bIsSalesRepWise = true;
                                    }

                                    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(Report)))
                                    {
                                        glb_dtsSales.Clear();
                                        //List<tbl_sasInvoice> oInvoices;
                                        List<tbl_sasInvoice> oInvoices = new List<tbl_sasInvoice>();
                                        oInvoices = bCustomerSelected ? tbl_sasInvoice.SelectAllByCustomer_ID(txtCustomer.Tag.ToString()) : tbl_sasInvoice.SelectAll();

                                        foreach (tbl_sasInvoice oInv in oInvoices.Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && !p.IsDeleted && p.Invoice_ID != "default" && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date && !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque).ToList())
                                        {
                                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInv.Customer_ID);
                                            if (oCustomer != null && oCustomer.CustomerCode != "default")
                                            {
                                                #region Route
                                                if (bRouteSelected)
                                                {
                                                    if (!chkUseCustomerMasterRoute.Checked)
                                                    {
                                                        sRouteID = oInv.Route_ID.ToString();
                                                    }
                                                    else
                                                    {
                                                        foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oInv.Customer_ID))
                                                        {
                                                            sRouteID = oRoute.Route_ID.ToString();
                                                            if (txtRoute.Tag.ToString() == sRouteID)
                                                                break;
                                                        }
                                                    }

                                                    if (txtRoute.Tag.ToString() != sRouteID)
                                                        continue;
                                                }
                                                #endregion

                                                #region Customer Filters
                                                if (bCustomerClassSelected)
                                                {
                                                    if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                #endregion

                                                bool bIsExport = oCustomer.CustomerType_ID == "2" ? true : false;
                                                bool bIsExportSvat = (bIsExport && oInv.IsSVatInvoice) ? true : false;
                                                string sJobType = "";

                                                #region Sales rep
                                                if (!chkUseCustomerMastorSaleRep.Checked)
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInv.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }
                                                else
                                                    sSalesmanID = oCustomer.SalesRep_ID;

                                                if (bSelesRepSelected)
                                                    if (txtSalesRep.Tag.ToString().Trim() != sSalesmanID)
                                                        continue;
                                                #endregion

                                                #region Job Type - AKT only
                                                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString() && (clsFormatter.DigiteqTitle == "SEACC ePack" || clsFormatter.DigiteqTitle == "SEACC ePack Test"))
                                                {
                                                    if (oInv.Job_ID != "default")
                                                    {
                                                        //string sInvType = clsHelpMethods_Local.getProductionJobType_Simple(oInv.Job_ID);
                                                        //if (oInv.Quotation_ID != "default")
                                                        //    sJobType = "B";
                                                        //else if (sInvType == "KDDN")
                                                        //    sJobType = "K";
                                                        //else if (sInvType == "PTDN")
                                                        //    sJobType = "P";
                                                    }
                                                    else if (oInv.Job_ID == "default" && oInv.DeliveryOrder_ID != "default")
                                                    {
                                                        if (bIsExport)
                                                            sJobType = "DE";
                                                        else
                                                            sJobType = "DL";
                                                    }
                                                    else if (oInv.Quotation_ID != "default")
                                                        sJobType = "B";
                                                }
                                                #endregion

                                                else
                                                {
                                                    if (clsConfig.bBranchMaster_SerialNoActiveFor_Invoice)
                                                        sJobType = clsGenaralName.getName_CompanyBranchMaster(oInv.Branch_ID);
                                                    else if (clsConfig.bSalesNoteType_SerialNoActiveFor_Invoice)
                                                        sJobType = clsGenaralName.getName_SalesNoteType(oInv.SalesNoteType_ID);
                                                    else
                                                        sJobType = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID);
                                                }

                                                decimal dWithNBTAmount = 0, dSubTotal = 0, dNBTAmount = 0, dVatAmount = 0;
                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInv.GrandTotal, oInv.VatPercentage, oInv.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);

                                                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString() && (clsFormatter.DigiteqTitle == "SEACC ePack" || clsFormatter.DigiteqTitle == "SEACC ePack Test"))
                                                {
                                                    string temp = oInv.Invoice_ID;//for testing 
                                                    if (sJobType == "DE" || bIsExportSvat)
                                                        dSubTotal = oInv.GrandTotal;
                                                    else if (sJobType == "B")
                                                        dSubTotal = (oInv.GrandTotal - dVatAmount);
                                                    else if (bIsExport && !bIsExportSvat)
                                                        dSubTotal = (oInv.GrandTotal - dVatAmount);
                                                }
                                                else
                                                {
                                                    if (oInv.IsSVatInvoice)
                                                        dSubTotal = oInv.GrandTotal;
                                                }

                                                if (!chkReduceNBTAndVatValue.Checked)
                                                {
                                                    dSubTotal += dNBTAmount + dVatAmount;
                                                }
                                                string sSalesNoteType = oInv.SalesNoteType_ID;

                                                glb_dtsSales.dt_sasTurnOver.Adddt_sasTurnOverRow(oInv.Invoice_ID, oInv.InvoiceDate, oInv.Customer_ID, clsGenaralName.getName_Customer(oInv.Customer_ID), clsGenaralName.getName_BranchCustomer(oInv.Customer_ID, int.Parse(oInv.Branch_ID)),
                                                      bIsExport, sJobType, dSubTotal, oInv.GrandTotal, clsGenaralName.getName_CurrencyCode(oInv.Currency_ID), oInv.CurrencyRate, bIsSalesRepWise ? clsGenaralName.getName_SalesRep(sSalesmanID) : "", sSalesNoteType);
                                            }
                                            clsHelpMethods_Local.startProgressBar(0, oInvoices.Count + 2, 1, ProgressBar);
                                        }
                                        glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sRepName, "", sDateRange, clsSecurity.UserNameLoged, sFilter);
                                        frm_ReportViewer_New rpt = new Digiteq.frm_ReportViewer_New();

                                        rpt.print(sReportPath, glb_dtsSales, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                        //  print(s_Path, sRepName, glb_dtsSales.dt_sasTurnOver, "");
                                    }
                                }
                                #endregion

                                #region Dilivery Listing
                                else if (Report == enum_ReportName.ST_Dilivery_Listing_Report)
                                {
                                    //clear the data table dts_Stock.xsd
                                    glb_dtsSales.Clear();
                                    string sSalesmanName = "", sSalesmanID = "", sRouteID = "";

                                    List<tbl_sasDeliveryOrder> Query = tbl_sasDeliveryOrder.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && !p.IsDeleted && p.DeliveryOrder_ID != "default" && p.DeliveryOrderDate.Date >= dtpFrom.Value.Date && p.DeliveryOrderDate.Date <= dtpTo.Value.Date).ToList();
                                    #region Filters
                                    if (cmbDOType.Text.Trim() != "<All Type>")
                                        sFilter += ",Job Type:" + cmbDOType.SelectedItem.ToString();
                                    if (chkIsReplasement.Checked)
                                        sFilter += " Replacement Orders Only";

                                    #endregion

                                    foreach (tbl_sasDeliveryOrder oDO in Query)
                                    {
                                        #region Filter - Replacememt Order
                                        if (chkIsReplasement.Checked)
                                        {
                                            if (!oDO.IsReplacementOrder)
                                                continue;
                                        }
                                        #endregion

                                        #region Filter - Customer
                                        string sDoType = "";
                                        if (bCustomerSelected)
                                        {
                                            if (txtCustomer.Tag.ToString().Trim() != oDO.Customer_ID)
                                                continue;
                                        }
                                        #endregion

                                        //#region filter - DO type
                                        //tbl_pmsProductionJobRegister oJob = tbl_pmsProductionJobRegister.Select(oDO.Job_ID);
                                        //if (oJob != null)
                                        //{
                                        //    if (oJob.ProductionJobType_ID == "PJT/001" || oJob.ProductionJobType_ID == "PJT/002")
                                        //        sDoType = "Kandana";
                                        //    else if (oJob.ProductionJobType_ID == "PJT/003" || oJob.ProductionJobType_ID == "PJT/004")
                                        //        sDoType = "Pettah";
                                        //    else if (oJob.ProductionJobType_ID == "PJT/009" || oJob.ProductionJobType_ID == "PJT/010")
                                        //        sDoType = "Direct";
                                        //    else if (oJob.ProductionJobType_ID == "PJT/013" || oJob.ProductionJobType_ID == "PJT/014")
                                        //        sDoType = "Block";
                                        //    else if (oJob.ProductionJobType_ID == "PJT/011" || oJob.ProductionJobType_ID == "PJT/012")
                                        //        sDoType = "Chemical";
                                        //    else
                                        //        sDoType = "-";

                                        //    #region To be delete
                                        //    //if (bJobTypeSelected)
                                        //    //{
                                        //    //    if (oJob.Job_ID == "default")
                                        //    //    {
                                        //    //        if (txtJobType.Tag.ToString().Trim() != "PJT/009" && txtJobType.Tag.ToString().Trim() != "PJT/010")
                                        //    //            continue;
                                        //    //    }
                                        //    //    else if (oJob.ProductionJobType_ID != txtJobType.Tag.ToString().Trim())
                                        //    //        continue;
                                        //    //}


                                        //    //if (cmbDOType.Text != "<All Type>")
                                        //    //{
                                        //    //    if (cmbDOType.Text.Trim() == "Kandana")
                                        //    //    {
                                        //    //        if (oJob.ProductionJobType_ID != "PJT/001" && oJob.ProductionJobType_ID != "PJT/002")
                                        //    //            continue;
                                        //    //    }
                                        //    //    else if (cmbDOType.Text.Trim() == "Pettah")
                                        //    //    {
                                        //    //        if (oJob.ProductionJobType_ID != "PJT/003" && oJob.ProductionJobType_ID != "PJT/004")
                                        //    //            continue;
                                        //    //    }
                                        //    //    else if (cmbDOType.Text.Trim() == "Direct")
                                        //    //    {
                                        //    //        if (oJob.ProductionJobType_ID != "PJT/009" && oJob.ProductionJobType_ID != "PJT/010")
                                        //    //            continue;
                                        //    //    }
                                        //    //    else if (cmbDOType.Text.Trim() == "Block")
                                        //    //    {
                                        //    //        if (oJob.ProductionJobType_ID != "PJT/013" && oJob.ProductionJobType_ID != "PJT/014")
                                        //    //            continue;
                                        //    //    }
                                        //    //    else if (cmbDOType.Text.Trim() == "Chemical")
                                        //    //    {
                                        //    //        if (oJob.ProductionJobType_ID != "PJT/011" && oJob.ProductionJobType_ID != "PJT/012")
                                        //    //            continue;
                                        //    //    }                                   

                                        //    //}

                                        //    #endregion

                                        //    if (cmbDOType.Text != "<All Type>")
                                        //    {
                                        //        if (cmbDOType.Text.Trim() != sDoType)
                                        //            continue;
                                        //    }
                                        //}
                                        //#endregion

                                        tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oDO.Customer_ID);
                                        if (oCustomer != null)
                                        {
                                            if (bCustomerClassSelected)
                                            {
                                                if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                    continue;
                                            }
                                            if (bCustomerTypeSelected)
                                            {
                                                if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                    continue;
                                            }
                                            if (bCustomerCategorySelected)
                                            {
                                                if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            #region sales rep
                                            if (chkUseCustomerMastorSaleRep.Checked)
                                            {
                                                sSalesmanName = clsGenaralName.getName_SalesRep(oCustomer.SalesRep_ID);
                                                sSalesmanID = oCustomer.SalesRep_ID;
                                            }
                                            else
                                            {
                                                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oDO.OrderRefNo_ID);
                                                if (oRef != null && oRef.OrderRefNo_ID != "default")
                                                {
                                                    sSalesmanName = clsGenaralName.getName_SalesRep(oRef.Employee_ID);
                                                    sSalesmanID = oRef.Employee_ID;
                                                }
                                            }

                                            if (bSelesRepSelected)
                                            {
                                                if (sSalesmanID != txtSalesRep.Tag.ToString().Trim())
                                                    continue;
                                            }
                                            #endregion

                                            #region Route
                                            if (bRouteSelected)
                                            {
                                                if (!chkUseCustomerMasterRoute.Checked)
                                                {
                                                    sRouteID = oDO.Route_ID.ToString();
                                                }
                                                else
                                                {
                                                    foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oDO.Customer_ID))
                                                    {
                                                        sRouteID = oRoute.Route_ID.ToString();
                                                        if (txtRoute.Tag.ToString() == sRouteID)
                                                            break;
                                                    }
                                                }

                                                if (txtRoute.Tag.ToString() != sRouteID)
                                                    continue;
                                            }
                                            #endregion

                                            string sInvoiceID = "", sSRNID = "", sPONo = "N/A";
                                            foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAllByDeliveryOrder_ID(oDO.DeliveryOrder_ID).Where(p => !p.IsDeleted && p.Invoice_ID != "default"))
                                                sInvoiceID += oInvoice.Invoice_ID;
                                            foreach (tbl_sasSalesReturnedNote oSRN in tbl_sasSalesReturnedNote.SelectAllByDeliveryOrder_ID(oDO.DeliveryOrder_ID).Where(p => !p.IsDeleted && p.SalesReturnedNote_ID != "default"))
                                                sSRNID += oSRN.SalesReturnedNote_ID;

                                            sPONo = clsHelpMethods_Local.GetPONoByDeliveryOrderID(oDO.DeliveryOrder_ID);
                                            sPONo = sPONo == "default" ? "N/A" : sPONo;
                                            string sJobNo = oDO.Job_ID == "default" ? "N/A" : oDO.Job_ID;

                                            foreach (tbl_sasDeliveryOrder_Detail detail in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDO.DeliveryOrder_ID))
                                            {
                                                if (bItemSelected)
                                                    if (txtItemID.Tag.ToString().Trim() != detail.Item_ID.Trim())
                                                        continue;
                                                decimal dQty = 0;
                                                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                                    dQty = detail.IsWeightCalculation ? detail.Weight : detail.Qty;
                                                else
                                                    dQty = detail.Qty;

                                                string sUom = "default";
                                                tbl_genItemMaster oItem = tbl_genItemMaster.Select(detail.Item_ID);
                                                if (oItem != null)
                                                {
                                                    sUom = oItem.Uom_ID;
                                                }
                                                glb_dtsSales.dt_sasDiliveryListing.Adddt_sasDiliveryListingRow(oDO.DeliveryOrder_ID, oDO.DeliveryOrderDate, oCustomer.CustomerName, oDO.Customer_ID, clsGenaralName.getName_Item(detail.Item_ID),
                                                "", detail.Qty, detail.Weight, sUom, "", oDO.IsWeightCalculation, sInvoiceID, sSRNID, "", sJobNo, sPONo, sSalesmanID, sSalesmanName, sDoType, oDO.Remark);
                                            }
                                            clsHelpMethods_Local.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
                                        }
                                    }


                                    if (sReportPath != null && sReportPath.Length > 0)
                                    { }
                                    else
                                        sReportPath = "\\Reports\\SAS\\Custom\\rpt_sas_DiliveryListing.rpt";
                                    // print(sGetRptPath, "Delivery Listing Report", glb_dtsSales.dt_sasDiliveryListing, sFilter);
                                    glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Delivery Listing Report", "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                    frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    rpt.print(sReportPath, glb_dtsSales, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                }

                                #endregion

                                #region Invoice Listing
                                else if (Report == enum_ReportName.ST_Invoice_Listing_Report)
                                {
                                    //clear the data table dts_Stock.xsd
                                    glb_dtsSales.dt_sasInvoiceListing.Rows.Clear();
                                    glb_dtsSales.dt_Company.Rows.Clear();

                                    List<tbl_sasInvoice> Query = tbl_sasInvoice.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => !p.IsDeleted && p.Invoice_ID != "default" && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date && !p.IsReturnedCheque && !p.IsDebitNote).ToList();
                                    foreach (tbl_sasInvoice oInvoice in Query)
                                    {
                                        if (bCustomerSelected)
                                            if (txtCustomer.Tag.ToString().Trim() != oInvoice.Customer_ID)
                                                continue;

                                        #region Sales Note Type
                                        if (bSalesNoteTypeSelected)
                                            if (oInvoice.SalesNoteType_ID != txtSalesNoteType.Tag.ToString().Trim())
                                                continue;
                                        #endregion

                                        string sDOID = "", sCOID = "", sCRNo = "", sPONo = "N/A";
                                        sPONo = clsHelpMethods_Local.GetPONoByDeliveryOrderID(oInvoice.DeliveryOrder_ID);
                                        sPONo = sPONo == "default" ? "N/A" : sPONo;
                                        string sJobType = "N/A";
                                        string sJobNo = oInvoice.Job_ID == "default" ? "N/A" : oInvoice.Job_ID, sSalesmanName = "", sSalesmanID = "", sRouteID = "";
                                        decimal dStdWeight = 0;

                                        //sDOID = oInvoice.DeliveryOrder_ID == "default" ? "N/A" : oInvoice.DeliveryOrder_ID;

                                        tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                        if (oCustomer != null)
                                        {
                                            if (bCustomerClassSelected)
                                            {
                                                if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                    continue;
                                            }
                                            if (bCustomerTypeSelected)
                                            {
                                                if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                    continue;
                                            }
                                            if (bCustomerCategorySelected)
                                            {
                                                if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            #region Sales Rep
                                            if (chkUseCustomerMastorSaleRep.Checked)
                                            {
                                                sSalesmanName = clsGenaralName.getName_SalesRep(oCustomer.SalesRep_ID);
                                                sSalesmanID = oCustomer.SalesRep_ID;
                                            }
                                            else
                                            {
                                                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                                if (oRef != null && oRef.OrderRefNo_ID != "default")
                                                {
                                                    sSalesmanName = clsGenaralName.getName_SalesRep(oRef.Employee_ID);
                                                    sSalesmanID = oRef.Employee_ID;
                                                }
                                            }

                                            if (bSelesRepSelected)
                                            {
                                                if (sSalesmanID != txtSalesRep.Tag.ToString().Trim())
                                                    continue;
                                            }
                                            #endregion

                                            #region Route
                                            if (bRouteSelected)
                                            {
                                                if (!chkUseCustomerMasterRoute.Checked)
                                                {
                                                    sRouteID = oInvoice.Route_ID.ToString();
                                                }
                                                else
                                                {
                                                    foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oInvoice.Customer_ID))
                                                    {
                                                        sRouteID = oRoute.Route_ID.ToString();
                                                        if (txtRoute.Tag.ToString() == sRouteID)
                                                            break;
                                                    }
                                                }

                                                if (txtRoute.Tag.ToString() != sRouteID)
                                                    continue;
                                            }
                                            #endregion

                                            #region Job
                                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                            {
                                                #region AKT Customer
                                                if (oInvoice.Quotation_ID != "default")
                                                {
                                                    sJobType = "Block Sales";
                                                    if (bJobTypeSelected)
                                                    {
                                                        if (txtJobType.Tag.ToString().Trim() != "PJT/013" && txtJobType.Tag.ToString().Trim() != "PJT/014")
                                                            continue;
                                                    }
                                                }
                                                else if (oInvoice.DeliveryOrder_ID != "default" && oInvoice.Job_ID == "default")
                                                {
                                                    sJobType = "Direct Sales";
                                                    if (bJobTypeSelected)
                                                    {
                                                        if (txtJobType.Tag.ToString().Trim() != "PJT/009" && txtJobType.Tag.ToString().Trim() != "PJT/010")
                                                            continue;
                                                    }
                                                }
                                                else if (oInvoice.Job_ID != "default")
                                                {
                                                    //tbl_pmsProductionJobRegister oJob = tbl_pmsProductionJobRegister.Select(oInvoice.Job_ID);
                                                    //if (oJob != null)
                                                    //{
                                                    //    tbl_sasJobRegister oSjob = tbl_sasJobRegister.Select(oJob.Job_ID);
                                                    //    if (oSjob != null)
                                                    //    {
                                                    //        #region For Set StdWeight As Weight1000Qty in Job card
                                                    //        tbl_sasCustomerOrder oCo = tbl_sasCustomerOrder.Select(oJob.CustomerOrder_ID);
                                                    //        if (oCo != null && oCo.CustomerOrder_ID != "default")
                                                    //        {
                                                    //            decimal dOrderQty = 0, dOrderWeight = 0;
                                                    //            foreach (tbl_sasCustomerOrder_Detail oItem in tbl_sasCustomerOrder_Detail.SelectAllByJob_ID(oJob.Job_ID))
                                                    //            {
                                                    //                dOrderQty = oItem.Qty;
                                                    //                dOrderWeight = oItem.Weight;
                                                    //                //foreach (tbl_sasJobRegister_Material item in tbl_sasJobRegister_Material.SelectAllByJob_ID(oJob.Job_ID).OrderBy(x => x.Line_No))
                                                    //                //{
                                                    //                //    decimal dWeight = oCo.IsWeightCalculation ? dOrderWeight : dOrderQty;
                                                    //                //    dStdWeight += (item.Width / dWeight) * 1000;

                                                    //                //}
                                                    //                // dStdWeight = oSjob.Weight;
                                                    //            }

                                                    //        }
                                                    //        #endregion
                                                    //    }

                                                    //    sJobType = clsGenaralName.getName_ProductionJobType(oJob.ProductionJobType_ID);
                                                    //    if (bJobTypeSelected)
                                                    //    {
                                                    //        if (oJob.ProductionJobType_ID != txtJobType.Tag.ToString().Trim())
                                                    //            continue;
                                                    //    }
                                                    //}
                                                }
                                                #endregion
                                            }
                                            else
                                            {
                                                if (clsConfig.bSalesNoteType_SerialNoActiveFor_Invoice)
                                                    sJobType = clsGenaralName.getName_SalesNoteType(oInvoice.SalesNoteType_ID);
                                                else
                                                    sJobType = (oInvoice.IsVatInvoice) ? "Vat Invoice" : (oInvoice.IsSVatInvoice) ? "SVat Invoice" : "Non Tax Invoice";
                                            }
                                            #endregion
                                            int iItemCount = 0;
                                            foreach (tbl_sasInvoice_Detail detail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID))
                                            {
                                                if (bItemSelected)
                                                    if (txtItemID.Tag.ToString().Trim() != detail.Item_ID.Trim())
                                                        continue;

                                                string sItemSize = clsHelpMethods_Local.GetItemSizeByItemID(detail.Item_ID);
                                                decimal dUnitPrice = oInvoice.IsWeightCalculation ? detail.WeightPrice : detail.UnitPrice;
                                                decimal dQty = 0;

                                                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                                    dQty = oInvoice.IsWeightCalculation ? detail.Weight : detail.Qty;
                                                else
                                                    dQty = detail.Qty;

                                                #region Get DO No
                                                if (detail.DeliveryOrder_ID == "default")
                                                {
                                                    if (oInvoice.DeliveryOrder_ID == "default")
                                                    {
                                                        sDOID = "N/A";
                                                    }
                                                    else
                                                    {
                                                        sDOID = oInvoice.DeliveryOrder_ID;
                                                    }
                                                }
                                                else
                                                {
                                                    sDOID = detail.DeliveryOrder_ID;
                                                }
                                                #endregion

                                                #region Get CO No
                                                if (detail.CustomerOrder_ID == "default")
                                                {
                                                    if (oInvoice.CustomerOrder_ID == "default")
                                                    {
                                                        sCOID = "N/A";
                                                    }
                                                    else
                                                    {
                                                        sCOID = oInvoice.CustomerOrder_ID;
                                                    }
                                                }
                                                else
                                                {
                                                    sCOID = detail.CustomerOrder_ID;
                                                }
                                                #endregion

                                                tbl_genItemMaster detItem = tbl_genItemMaster.Select(detail.Item_ID);

                                                //DateTime dateDO;
                                                //if (sDOID != "N/A")
                                                //{
                                                tbl_sasDeliveryOrder dtDO = tbl_sasDeliveryOrder.Select(detail.DeliveryOrder_ID);
                                                //dateDO = dtDO.DeliveryOrderDate;
                                                // }

                                                glb_dtsSales.dt_sasInvoiceListing.Adddt_sasInvoiceListingRow(oInvoice.Invoice_ID, oInvoice.InvoiceDate, oCustomer.CustomerName, oInvoice.Customer_ID, clsGenaralName.getName_BranchCustomer(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID)), clsGenaralName.getName_Item(detail.Item_ID), clsGenaralName.getName_Tag1(detItem.Tag1_ID), clsGenaralName.getName_Tag2(detItem.Tag2_ID),
                                                    sItemSize, dQty, detail.Weight, dUnitPrice, (iItemCount == 0) ? oInvoice.GrandTotal : 0, oInvoice.IsWeightCalculation, sDOID, dtDO.DeliveryOrderDate, sCRNo, sCOID, sPONo, sJobType, sSalesmanID, sSalesmanName, dStdWeight, clsGenaralName.getName_SalesNoteType(oInvoice.SalesNoteType_ID));
                                                iItemCount++;
                                            }
                                        }
                                        clsHelpMethods_Local.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
                                    }
                                    glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Invoice Listing Report", sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);

                                    frm_ReportViewer_New rpt = new frm_ReportViewer_New();

                                    if (sReportPath != null && sReportPath.Length > 0)
                                        //print(sGetRptPath, "Invoice Listing Report", glb_dtsSales.dt_sasInvoiceListing, sFilter);
                                        rpt.print(sReportPath, glb_dtsSales, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    else
                                        //print("\\Reports\\SAS\\Custom\\rpt_sas_InvoiceListing.rpt", "Invoice Listing Report", glb_dtsSales, sFilter);                            
                                        rpt.print("\\Reports\\SAS\\Custom\\rpt_sas_InvoiceListing.rpt", glb_dtsSales, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                }
                                #endregion

                                #region Outstanding Orders - Customer Wise
                                else if (Report == enum_ReportName.ST_OutstandingOrders_CustomerWise)
                                {
                                    //if (true)
                                    //    MessageBox.Show("Report is under construction....");
                                    //else
                                    {
                                        fillDataforDataTable(true);
                                    }

                                }
                                #endregion

                                #region Delivery Tracking Report (Job-Wise)
                                else if (Report == enum_ReportName.St_DelevaryTrackingReport)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsSasDeliveryTracking.dt_sasDeliveryTrackingJobWise.Rows.Clear();
                                        glb_dtsSasDeliveryTracking.dt_sasDeliveryTrackingJobWise_Detail.Rows.Clear();

                                        //foreach (tbl_pmsProductionJobRegister oJob in tbl_pmsProductionJobRegister.SelectAll().Where(p => p.ProductionJob_ID != "default" && !p.IsDeleted && p.ProductionOrderDate.Date >= dtpFrom.Value.Date && p.ProductionOrderDate.Date <= dtpTo.Value.Date))
                                        //{
                                        //    decimal dPresentage = 0, dQty = 0, dReturndQty = 0, dJobQty = 0, dCoQty = 0, dCoWaight = 0;
                                        //    string sSrnCode = "";
                                        //    int iNoOfDays = 0;

                                        //    dPresentage = 0;
                                        //    string sSalesman_ID = "";

                                        //    if (bItemSelected)
                                        //    {
                                        //        if (txtItemID.Tag.ToString().Trim() != oJob.Item_ID)
                                        //            continue;
                                        //    }

                                        //    foreach (tbl_sasCustomerOrder_Detail oCust in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(oJob.CustomerOrder_ID))
                                        //    {
                                        //        dCoWaight += oCust.Weight;
                                        //        dCoQty += oCust.Qty;
                                        //    }

                                        //    foreach (tbl_sasDeliveryOrder oDo in tbl_sasDeliveryOrder.SelectAllByJob_ID(oJob.ProductionJob_ID).Where(p => p.DeliveryOrder_ID != "default" && !p.IsDeleted).OrderBy(q => q.DeliveryOrderDate))
                                        //    {
                                        //        if (bCustomerSelected)
                                        //            if (txtCustomer.Tag.ToString().Trim() != oDo.Customer_ID)
                                        //                continue;

                                        //        tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oDo.Customer_ID);
                                        //        if (oCustomer != null)
                                        //        {
                                        //            #region Sales Rep
                                        //            tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oDo.OrderRefNo_ID);
                                        //            sSalesman_ID = oRef.Employee_ID;
                                        //            if (chkUseCustomerMastorSaleRep.Checked)
                                        //                sSalesman_ID = oDo.Employee_ID;

                                        //            if (bSelesRepSelected)
                                        //            {
                                        //                if (chkUseCustomerMastorSaleRep.Checked)
                                        //                {
                                        //                    if (oDo.Employee_ID != txtSalesRep.Tag.ToString().Trim())
                                        //                        continue;
                                        //                }
                                        //                else
                                        //                {
                                        //                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                        //                    {
                                        //                        if (oRef.Employee_ID != txtSalesRep.Tag.ToString().Trim())
                                        //                            continue;
                                        //                    }
                                        //                }
                                        //            }
                                        //            #endregion

                                        //            if (bCustomerClassSelected)
                                        //            {
                                        //                if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                        //                    continue;
                                        //            }
                                        //            if (bCustomerTypeSelected)
                                        //            {
                                        //                if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                        //                    continue;
                                        //            }
                                        //            if (bCustomerCategorySelected)
                                        //            {
                                        //                if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                        //                    continue;
                                        //            }
                                        //        }

                                        //        dJobQty = oDo.IsWeightCalculation ? dCoWaight : dCoQty;
                                        //        if (dJobQty > 0)
                                        //        {
                                        //            dQty = 0;
                                        //            dReturndQty = 0;
                                        //            sSrnCode = "";

                                        //            iNoOfDays = clsCommon.getDays(oJob.ProductionOrderDate, oDo.DeliveryOrderDate);
                                        //            foreach (tbl_sasDeliveryOrder_Detail oDoDetail in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDo.DeliveryOrder_ID))
                                        //            {
                                        //                if (oDoDetail.WeightReturned > 0)
                                        //                { }
                                        //                dQty += oDo.IsWeightCalculation ? oDoDetail.Weight : oDoDetail.Qty;
                                        //                dReturndQty += oDo.IsWeightCalculation ? oDoDetail.WeightReturned : oDoDetail.QtyReturned;
                                        //            }
                                        //            if (dReturndQty > 0)
                                        //            {
                                        //                foreach (tbl_sasSalesReturnedNote oSrn in tbl_sasSalesReturnedNote.SelectAllByDeliveryOrder_ID(oDo.DeliveryOrder_ID))
                                        //                    sSrnCode += oSrn.SalesReturnedNote_ID + " - ";
                                        //            }
                                        //            else
                                        //                sSrnCode = "-";

                                        //            dPresentage += (dQty - dReturndQty) * 100 / dJobQty;
                                        //            glb_dtsSasDeliveryTracking.dt_sasDeliveryTrackingJobWise_Detail.Adddt_sasDeliveryTrackingJobWise_DetailRow(oJob.ProductionJob_ID, oDo.DeliveryOrder_ID, oDo.DeliveryOrderDate,
                                        //                oDo.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(dQty) : clsFormatter.FormatDecimalPlaces_Quantity(dQty),
                                        //                (dReturndQty == 0) ? "-" : (oDo.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(dReturndQty) : clsFormatter.FormatDecimalPlaces_Quantity(dReturndQty)),
                                        //                  sSrnCode, iNoOfDays, dPresentage);
                                        //        }
                                        //    }
                                        //    if (dJobQty > 0)
                                        //    {
                                        //        //foreach (tbl_sasJobRegister_Material oJobMeterial in tbl_sasJobRegister_Material.SelectAllByJob_ID(oJob.Job_ID))
                                        //        //{
                                        //        //    glb_dtsSasDeliveryTracking.dt_sasDeliveryTrackingJobWise_CombinationMeterial.Adddt_sasDeliveryTrackingJobWise_CombinationMeterialRow(oJob.ProductionJob_ID, oJobMeterial.IsLamination ? oJobMeterial.LaminationMaterailType_ID : oJobMeterial.PolytheneMaterailType_ID, oJobMeterial.IsLamination ? clsGenaralName.getName_LaminationMaterailType(oJobMeterial.LaminationMaterailType_ID) : clsGenaralName.getName_PolytheneMaterailType(oJobMeterial.PolytheneMaterailType_ID), oJobMeterial.IsLamination ? "Laminate Product" : "Polythene Product");
                                        //        //}
                                        //        string sCombinationMatirials = "";
                                        //        List<string> sMaterials = clsHelpMethods_Local.getCombinationMaterialListByProductionJobID(oJob.ProductionJob_ID, true);
                                        //        foreach (string sMaterial in sMaterials)
                                        //            sCombinationMatirials += "" + sMaterial + " " + "/";

                                        //        glb_dtsSasDeliveryTracking.dt_sasDeliveryTrackingJobWise.Adddt_sasDeliveryTrackingJobWiseRow(oJob.ProductionJob_ID, oJob.ProductionOrderDate, clsGenaralName.getName_Customer(oJob.Customer_ID), oJob.OrderRefNo_ID, dJobQty, clsGenaralName.getName_Uom(oJob.Uom_ID), clsGenaralName.getName_ProductionJobType(oJob.ProductionJobType_ID), clsGenaralName.getName_Item(oJob.Item_ID),
                                        //            (dPresentage == 100) ? true : false, sSalesman_ID != "default" ? clsGenaralName.getName_Employee(sSalesman_ID) : "", sCombinationMatirials, clsCommon.fncsetstring(clsHelpMethods_Local.GetItemSizeByItemID(oJob.Item_ID)));

                                        //    }
                                        //}
                                        //print("\\Reports\\SAS\\Standard\\rpt_sas_DeliveryTracking-jobWise.rpt", "Delivery Tracking Report (Job Wise)", glb_dtsSasDeliveryTracking, sFilter, clsAutocode.getReportID(Report));
                                  
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glb_dtsSasDeliveryTracking.dt_sasDeliveryTrackingJobWise.Rows.Clear();
                                        glb_dtsSasDeliveryTracking.dt_sasDeliveryTrackingJobWise_Detail.Rows.Clear();
                                    }
                                }
                                #endregion

                                #region Printing Sales Returned Tracking Report
                                else if (Report == enum_ReportName.ST_SalesReturnTrackingReport)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsSales.Clear();
                                        string sRouteID = "", sSalesmanID = "";

                                        List<tbl_sasSalesReturnedNote> oSRNs = tbl_sasSalesReturnedNote.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && !p.IsDeleted && p.SalesNoteType_ID != "default"
                                            && p.SalesReturnedNoteDate.Date >= dtpFrom.Value.Date && p.SalesReturnedNoteDate.Date <= dtpTo.Value.Date).ToList();

                                        //fill data table
                                        foreach (tbl_sasSalesReturnedNote oSRN in oSRNs)
                                        {
                                            decimal dDOAmount = 0, dInvoiceAmount = 0, dCRAmount = 0;
                                            string sDOCode = "", sInvoiceCode = "", sDODate = "", sInvoiceDate = "", sCRCode = "", sCRDate = "";

                                            if (bCustomerSelected)
                                            {
                                                if (txtCustomer.Tag.ToString() != oSRN.Customer_ID)
                                                    continue;
                                            }

                                            tbl_genCustomerMaster CusDetail = tbl_genCustomerMaster.Select(oSRN.Customer_ID);
                                            if (CusDetail != null)
                                            {
                                                if (bCustomerClassSelected)
                                                {
                                                    if (CusDetail.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (CusDetail.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (CusDetail.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }

                                                #region Sales Rep
                                                if (chkUseCustomerMastorSaleRep.Checked)
                                                    sSalesmanID = CusDetail.SalesRep_ID;
                                                else
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oSRN.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }

                                                if (bSelesRepSelected)
                                                {
                                                    if (sSalesmanID != txtSalesRep.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                #endregion

                                                #region Route
                                                if (bRouteSelected)
                                                {
                                                    if (!chkUseCustomerMasterRoute.Checked)
                                                    {
                                                        sRouteID = oSRN.Route_ID.ToString();
                                                    }
                                                    else
                                                    {
                                                        foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oSRN.Customer_ID))
                                                        {
                                                            sRouteID = oRoute.Route_ID.ToString();
                                                            if (txtRoute.Tag.ToString() == sRouteID)
                                                                break;
                                                        }
                                                    }

                                                    if (txtRoute.Tag.ToString() != sRouteID)
                                                        continue;
                                                }
                                                #endregion
                                            }

                                            tbl_sasDeliveryOrder oDO = tbl_sasDeliveryOrder.Select(oSRN.DeliveryOrder_ID);
                                            if (oDO != null && oDO.DeliveryOrder_ID != "default" && !oDO.IsDeleted)
                                            {
                                                sDOCode = oDO.DeliveryOrder_ID;
                                                sDODate = clsFormatter.FormatDate_Short(oDO.DeliveryOrderDate);
                                                dDOAmount = oDO.GrandTotal;
                                            }
                                            tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oSRN.Invoice_ID);
                                            if (oInvoice != null && oInvoice.Invoice_ID != "default" && !oInvoice.IsDeleted)
                                            {
                                                sInvoiceCode = oInvoice.Invoice_ID;
                                                sInvoiceDate = clsFormatter.FormatDate_Short(oInvoice.InvoiceDate);
                                                dInvoiceAmount = oInvoice.GrandTotal;
                                            }
                                            foreach (tbl_bpsCreditNote oCR in tbl_bpsCreditNote.SelectAllBySalesReturnedNote_ID(oSRN.SalesReturnedNote_ID).Where(p => !p.IsDeleted && p.CreditNote_ID != "default"))
                                                //if (oCR != null && oCR.Invoice_ID != "default" && !oCR.IsDeleted)
                                                if (oCR != null && !oCR.IsDeleted)
                                                {
                                                    string sSeperator = sCRCode.Length > 0 ? " | " : "";
                                                    sCRCode += sSeperator + oCR.CreditNote_ID;
                                                    sCRDate = sSeperator + clsFormatter.FormatDate_Short(oCR.CreditNoteDate);
                                                    dCRAmount += oCR.TotalAmount;
                                                }

                                            glb_dtsSales.dt_sasSalesReturnedTracking.Adddt_sasSalesReturnedTrackingRow(oSRN.SalesReturnedNote_ID, clsGenaralName.getName_Customer(oSRN.Customer_ID), clsGenaralName.getName_BranchCustomer(oSRN.Customer_ID, int.Parse(oSRN.Branch_ID)), oSRN.SalesReturnedNoteDate, oSRN.GrandTotal,
                                                sDOCode, sDODate, dDOAmount, sInvoiceCode, sInvoiceDate, dInvoiceAmount, sCRCode, sCRDate, dCRAmount);
                                            clsHelpMethods_Local.startProgressBar(0, oSRNs.Count + 2, 1, ProgressBar);
                                        }
                                        glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Sales Return Tracking(Summary)", "", sDateRange, clsSecurity.UserNameLoged, sFilter);
                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print("\\Reports\\SAS\\Standard\\rpt_sasSalesReturnTracking.rpt", glb_dtsSales, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                        // print("\\Reports\\SAS\\Standard\\rpt_sasSalesReturnTracking.rpt", " Sales Return Tracking (Summary)", glb_dtsSales.dt_sasSalesReturnedTracking, "");
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glb_dtsSales.Clear();
                                    }
                                }
                                #endregion

                                #region Customer Orders Tracking Report
                                else if (Report == enum_ReportName.ST_CustomerOrderTrackingReport)
                                {
                                    //SAS/ST/0043                                  
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsSales.Clear();

                                        string sRouteID = "";
                                        List<string> lstReceipt = new List<string>();

                                        List<tbl_sasCustomerOrder> oCOList = null;
                                        if (bCustomerSelected)
                                            oCOList = tbl_sasCustomerOrder.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && !p.IsDeleted && p.Customer_ID == txtCustomer.Tag.ToString() && p.CustomerOrderDate.Date >= dtpFrom.Value.Date && p.CustomerOrderDate.Date <= dtpTo.Value.Date).ToList();
                                        else
                                            oCOList = tbl_sasCustomerOrder.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && !p.IsDeleted && p.Customer_ID != "default" && p.CustomerOrderDate.Date >= dtpFrom.Value.Date && p.CustomerOrderDate.Date <= dtpTo.Value.Date).ToList();

                                        //fill data table
                                        foreach (tbl_sasCustomerOrder oCO in oCOList)
                                        {
                                            decimal dDOAmount = 0, dInvoiceAmount = 0, dCRAmount = 0;
                                            string sDOCode = "", sInvoiceCode = "", sDODate = "", sInvoiceDate = "", sCRCode = "", sCRDate = "";

                                            tbl_genCustomerMaster CusDetail = tbl_genCustomerMaster.Select(oCO.Customer_ID);
                                            if (CusDetail != null)
                                            {
                                                #region Route
                                                if (bRouteSelected)
                                                {
                                                    if (!chkUseCustomerMasterRoute.Checked)
                                                    {
                                                        sRouteID = oCO.Route_ID.ToString();
                                                    }
                                                    else
                                                    {
                                                        foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oCO.Customer_ID))
                                                        {
                                                            sRouteID = oRoute.Route_ID.ToString();
                                                            if (txtRoute.Tag.ToString() == sRouteID)
                                                                break;
                                                        }
                                                    }

                                                    if (txtRoute.Tag.ToString() != sRouteID)
                                                        continue;
                                                }
                                                #endregion

                                                if (bCustomerClassSelected)
                                                {
                                                    if (CusDetail.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (CusDetail.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (CusDetail.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }
                                            }

                                            foreach (tbl_sasDeliveryOrder oDO in tbl_sasDeliveryOrder.SelectAllByCustomerOrder_ID(oCO.CustomerOrder_ID))
                                            {
                                                string sSettledNo = "", sReceiptNo = "";
                                                foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAllByDeliveryOrder_ID(oDO.DeliveryOrder_ID))
                                                {
                                                    foreach (tbl_sasInvoice_Sattled oInvSettled in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(oInvoice.Invoice_ID))
                                                    {
                                                        if (oInvSettled.Receipt_ID != "default")
                                                            sReceiptNo = oInvSettled.Receipt_ID;
                                                        else if (oInvSettled.CreditNote_ID != "default")
                                                            sReceiptNo = oInvSettled.CreditNote_ID;
                                                        else
                                                            sReceiptNo = "";

                                                        lstReceipt.Add(sReceiptNo);

                                                    }
                                                    sSettledNo = String.Join(", ", lstReceipt.Distinct());

                                                    glb_dtsSales.dt_sasCustomerDetails_Tracking.Adddt_sasCustomerDetails_TrackingRow(oCO.CustomerOrder_ID, oCO.CustomerOrderDate, oCO.GrandTotal,
                                                        oCO.Customer_ID, clsGenaralName.getName_Customer(oCO.Customer_ID), clsGenaralName.getName_BranchCustomer(oDO.Customer_ID, int.Parse(oDO.Branch_ID)), oInvoice.Invoice_ID, oInvoice.InvoiceDate, oInvoice.GrandTotal,
                                                        oDO.DeliveryOrder_ID, oDO.DeliveryOrderDate, oDO.GrandTotal, oInvoice.SeattleAmount, sSettledNo);
                                                }
                                                lstReceipt.Clear();
                                            }
                                            clsHelpMethods_Local.startProgressBar(0, oCOList.Count + 2, 1, ProgressBar);
                                        }

                                        glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsSales, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glb_dtsSales.Clear();
                                    }
                                }
                                #endregion

                                #region Sales Return Value
                                else if (Report == enum_ReportName.ST_SalesReturnValue)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dtsSalesReturn.Clear();

                                        string sRouteID = "";

                                        //fill data table
                                        List<tbl_sasSalesReturnedNote> oSRNs = tbl_sasSalesReturnedNote.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && p.SalesReturnedNoteDate.Date >= dtpFrom.Value.Date && p.SalesReturnedNoteDate.Date <= dtpTo.Value.Date && !p.IsDeleted).ToList();
                                        foreach (tbl_sasSalesReturnedNote oSRN in oSRNs)
                                        {
                                            #region Filters
                                            bool bSalesRepOK = true;// bool bCustomerOK = true, bActiveOK = true;
                                            string sProductionJobID = "N/A", sDeliveryOrderID = oSRN.DeliveryOrder_ID;
                                            if (bCustomerSelected)
                                            {
                                                sFilter += " Customer Name : " + txtCustomer.Text.Trim();
                                                if (oSRN.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;
                                            }
                                            if (bSelesRepSelected)
                                            {
                                                sFilter += " Salesman Name : " + txtSalesRep.Text.Trim();
                                                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oSRN.OrderRefNo_ID);
                                                if (oRef != null)
                                                    bSalesRepOK = oRef.Employee_ID == txtSalesRep.Tag.ToString() ? true : false;
                                            }

                                            if (bSalesNoteTypeSelected)
                                            {
                                                if (txtSalesNoteType.Tag.ToString().Trim() != oSRN.SalesNoteType_ID)
                                                    continue;
                                            }

                                            if (bCustomerSelected)
                                            {
                                                if (oSRN.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            tbl_genCustomerMaster CusDetail = tbl_genCustomerMaster.Select(oSRN.Customer_ID);
                                            if (CusDetail != null)
                                            {
                                                #region Route
                                                if (bRouteSelected)
                                                {
                                                    if (!chkUseCustomerMasterRoute.Checked)
                                                    {
                                                        sRouteID = oSRN.Route_ID.ToString();
                                                    }
                                                    else
                                                    {
                                                        foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oSRN.Customer_ID))
                                                        {
                                                            sRouteID = oRoute.Route_ID.ToString();
                                                            if (txtRoute.Tag.ToString() == sRouteID)
                                                                break;
                                                        }
                                                    }

                                                    if (txtRoute.Tag.ToString() != sRouteID)
                                                        continue;
                                                }
                                                #endregion

                                                if (bCustomerClassSelected)
                                                {
                                                    if (CusDetail.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (CusDetail.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (CusDetail.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }
                                            }

                                            tbl_sasDeliveryOrder oDO = tbl_sasDeliveryOrder.Select(oSRN.DeliveryOrder_ID);
                                            string sJobId = "";
                                            if (oDO != null && oDO.DeliveryOrder_ID != "default")
                                            {
                                                sProductionJobID = oDO.Job_ID != "default" ? oDO.Job_ID : "";
                                                sJobId = oDO.Job_ID;
                                            }
                                            #endregion

                                            string sItemName = "", sUom = "";
                                            bool bNoValue = false;
                                            decimal dTotalWeight = 0, dTotalQty = 0, dTotalAmount = 0, dUnitPrice = 0;
                                            foreach (tbl_sasSalesReturnedNote_Detail oSalesReturnNoteDetail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSRN.SalesReturnedNote_ID).Where(p => p.SalesReturnedNote_ID != "default"))
                                            {
                                                if (bItemSelected)
                                                {
                                                    if (oSalesReturnNoteDetail.Item_ID != txtItemID.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                bNoValue = true;
                                                sUom = clsGenaralName.getName_ItemUOM(oSalesReturnNoteDetail.Item_ID);
                                                dTotalWeight += oSalesReturnNoteDetail.Weight;
                                                dTotalQty += oSalesReturnNoteDetail.Qty;
                                                dUnitPrice = oSalesReturnNoteDetail.UnitPrice;
                                                dTotalAmount += oSalesReturnNoteDetail.TatalAmount;
                                                sItemName = clsGenaralName.getName_Item(oSalesReturnNoteDetail.Item_ID) + ",";
                                            }
                                            if (sItemName.Count() > 0)
                                            {
                                                sItemName = sItemName.Substring(0, sItemName.Count() - 1);
                                            }

                                            glb_dtsSalesReturn.dt_sasSalesReturn.Adddt_sasSalesReturnRow(oSRN.SalesReturnedNote_ID, oSRN.SalesReturnedNoteDate,
                                            clsGenaralName.getName_Customer(oSRN.Customer_ID), clsGenaralName.getName_BranchCustomer(oSRN.Customer_ID, int.Parse(oSRN.Branch_ID)), oSRN.OrderRefNo_ID, oSRN.GrandTotal, dTotalWeight,
                                            dTotalQty, oSRN.IsReturnable, oSRN.IsRefundable, oSRN.IsExcess, sProductionJobID, sDeliveryOrderID,
                                            oSRN.Invoice_ID, oSRN.Remark, oSRN.IsWeightCalculation, 0, 0, 0, oSRN.IsDeleted, sJobId, "", clsGenaralName.getName_SalesNoteType(oSRN.SalesNoteType_ID), sItemName, dTotalAmount, dUnitPrice, sUom);

                                            if (!bNoValue)
                                                glb_dtsSalesReturn.Clear();
                                        }

                                        glb_dtsSalesReturn.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);
                                        clsHelpMethods_Local.startProgressBar(0, oSRNs.Count + 2, 1, ProgressBar);

                                        //print("\\Reports\\SAS\\Registry\\rpt_sas_SalesReturnValueReport.rpt", "Sales Return Value Report ", glb_dtsSalesReturn);
                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsSalesReturn, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        Cursor = Cursors.Default;
                                        glb_dtsSalesReturn.Clear();
                                    }
                                }
                                #endregion

                                #region Sales Reports (Item-wise Br)
                                //else if (rdoSalesReport_ItemWise_HTML.Checked)
                                else if ((Report == enum_ReportName.ST_SalesReport_ItemWise_HTML))
                                {
                                    MessageBox.Show("This report is under constructions", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                #endregion

                                #region Sales Reports
                                else if ((Report == enum_ReportName.ST_SalesReport_NoteTypeWise) ||
                                    //rdoSalesReport_ItemWise_HTML.Checked || 
                                    (Report == enum_ReportName.ST_SalesReport_ItemWise_Cr) || (Report == enum_ReportName.ST_SalesReport_SalesmanWise))
                                {
                                    //enum_ReportName enmRpt = enum_ReportName.ST_SalesReport_NoteTypeWise;
                                    //if (rdoSalesReport_ItemWise_HTML.Checked)
                                    //    enmRpt = enum_ReportName.ST_SalesReport_ItemWise_HTML;
                                    //else if (rdoSalesReport_ItemWise.Checked)
                                    //    enmRpt = enum_ReportName.ST_SalesReport_ItemWise_Cr;
                                    //else if (rdoSalesReportSalesmanWise.Checked)
                                    //    enmRpt = enum_ReportName.ST_SalesReport_SalesmanWise;

                                    try
                                    {
                                        bool bIsPOS_Active = false;
                                        tbl_cfgModule oPOS_Module = tbl_cfgModule.Select(clsConfig.sMod_POS);
                                        if (oPOS_Module != null && oPOS_Module.IsEnable)
                                            bIsPOS_Active = true;

                                        #region OLD REPORT
                                        if (!chkShowUpdatedReport.Checked)
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            glb_dtsReportExport.Clear();
                                            glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.Clear();

                                            //   string sDateRange = "From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "  To : " + dtpTo.Value.ToString("dd MMM yyyy");

                                            #region item wice report only
                                            List<SalesReport> oSalesReport = new List<SalesReport>();
                                            DataTable dt = new DataTable();
                                            if (Report == enum_ReportName.ST_SalesReport_ItemWise_HTML)
                                            {
                                                dt.Columns.Add("Customer");
                                                dt.Columns.Add("salesMen");

                                                foreach (tbl_genItemMaster oItem in tbl_genItemMaster.SelectAll().Where(p => p.Item_ID != "default"))
                                                {
                                                    dt.Columns.Add(oItem.Item_ID, typeof(decimal));
                                                }
                                            }
                                            #endregion

                                            //Add filter from Branch wise - Added by Gayan 2016-10-12
                                            string sSalesmanID = "", sSalesmanName = "", sRouteID = "";

                                            #region inv                                    
                                            foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => !p.IsDeleted && !p.IsOpeningBalance && !p.IsReturnedCheque && !p.IsDebitNote && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date))
                                            {
                                                #region Customer
                                                if (bCustomerSelected)
                                                {
                                                    if (oInvoice.Customer_ID != txtCustomer.Tag.ToString())
                                                        continue;
                                                }
                                                #endregion

                                                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                                if (oCustomer != null)
                                                {
                                                    if (bCustomerClassSelected)
                                                    {
                                                        if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                            continue;
                                                    }
                                                    if (bCustomerTypeSelected)
                                                    {
                                                        if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                            continue;
                                                    }
                                                    if (bCustomerCategorySelected)
                                                    {
                                                        if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                            continue;
                                                    }

                                                    #region Route
                                                    if (bRouteSelected)
                                                    {
                                                        if (!chkUseCustomerMasterRoute.Checked)
                                                        {
                                                            sRouteID = oInvoice.Route_ID.ToString();
                                                        }
                                                        else
                                                        {
                                                            foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oInvoice.Customer_ID))
                                                            {
                                                                sRouteID = oRoute.Route_ID.ToString();
                                                                if (txtRoute.Tag.ToString() == sRouteID)
                                                                    break;
                                                            }
                                                        }

                                                        if (txtRoute.Tag.ToString() != sRouteID)
                                                            continue;
                                                    }
                                                    #endregion
                                                }

                                                #region check rales rep
                                                if (!chkUseCustomerMastorSaleRep.Checked)
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }
                                                else
                                                    sSalesmanID = oCustomer.SalesRep_ID;

                                                if (bSelesRepSelected)
                                                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                        continue;

                                                sSalesmanName = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID);
                                                #endregion

                                                if (bSalesNoteTypeSelected)
                                                    if (txtSalesNoteType.Tag.ToString() != oInvoice.SalesNoteType_ID)
                                                        continue;

                                                //discount percentage VAT/NBT
                                                decimal dDisPercentage = 0;
                                                decimal dGrandTotal = 0;

                                                foreach (tbl_sasInvoice_Detail oDetail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID))
                                                {
                                                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oDetail.Item_ID);
                                                    if (oItem != null && oItem.Item_ID != "default")
                                                    {
                                                        #region Add VAT/ NBT
                                                        if (oInvoice.IsTaxExcludedInvoice)
                                                        {
                                                            if (oInvoice.SubTotal != 0)
                                                            {
                                                                dDisPercentage = (oInvoice.DiscountTotal + oInvoice.DiscountTotal1 + oInvoice.DiscountTotal2 + oInvoice.DiscountTotal3) / oInvoice.SubTotal * 100;
                                                                dGrandTotal = oDetail.TatalAmount - (oDetail.TatalAmount * dDisPercentage) / 100;
                                                            }

                                                        }
                                                        else if (!oInvoice.IsVatInvoice)
                                                        {
                                                            if (oInvoice.SubTotal != 0)
                                                            {
                                                                dDisPercentage = (oInvoice.DiscountTotal + oInvoice.DiscountTotal1 + oInvoice.DiscountTotal2 + oInvoice.DiscountTotal3) / oInvoice.SubTotal * 100;
                                                                dGrandTotal = oDetail.TatalAmount - (oDetail.TatalAmount * dDisPercentage) / 100;
                                                            }
                                                        }

                                                        //oInvoice.IsVatInvoice
                                                        else
                                                        {
                                                            if (oInvoice.SubTotal != 0)
                                                            {
                                                                dDisPercentage = (oInvoice.DiscountTotal + oInvoice.DiscountTotal1 + oInvoice.DiscountTotal2 + oInvoice.DiscountTotal3) / oInvoice.SubTotal * 100;
                                                                decimal dDiscountedTotal = oDetail.TatalAmount - (oDetail.TatalAmount * dDisPercentage) / 100;

                                                                decimal dNBT = 0;

                                                                if (oInvoice.NbtTotal != 0)
                                                                    dNBT = dDiscountedTotal + (dDiscountedTotal * 2) / 100;

                                                                else
                                                                    dNBT = dDiscountedTotal;

                                                                dGrandTotal = dNBT + (dNBT * 15) / 100;
                                                            }
                                                        }
                                                        #endregion

                                                        #region item Filters
                                                        #region Item Class
                                                        if (bItemClassSelected)
                                                        {
                                                            if (oItem.ItemClass_ID != txtItemClass.Tag.ToString())
                                                                continue;
                                                        }
                                                        #endregion

                                                        #region Item Type
                                                        if (bItemTypeSelected)
                                                        {
                                                            if (oItem.ItemType_ID != TxtItemType.Tag.ToString())
                                                                continue;
                                                        }
                                                        #endregion

                                                        #region Item Catagory
                                                        if (bItemcatagorySelected)
                                                        {
                                                            if (oItem.ItemCategory_ID != TxtItemCat.Tag.ToString())
                                                                continue;
                                                        }
                                                        #endregion

                                                        #region ItemFilter
                                                        if (bItemSelected)
                                                        {
                                                            if (oDetail.Item_ID != txtItemID.Tag.ToString())
                                                                continue;
                                                        }
                                                        #endregion
                                                        #endregion

                                                        if (rdoSalesReport_ItemWise_HTML.Checked)
                                                            oSalesReport.Add(new SalesReport("INV", oInvoice.Invoice_ID, oInvoice.InvoiceDate, oInvoice.SalesNoteType_ID, sSalesmanID, oCustomer.Customer_ID, oItem.Item_ID, oItem.ItemCategory_ID, oDetail.TatalAmount * (100 - oInvoice.DiscountPercentage) / 100));
                                                        else

                                                            //glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasSalesReport.Adddt_sasSalesReportRow("INV", oInvoice.Invoice_ID, oInvoice.InvoiceDate, oInvoice.SalesNoteType_ID, clsGenaralName.getName_SalesNoteType(oInvoice.SalesNoteType_ID), oInvoice.Customer_ID, oCustomer.CustomerName, sSalesmanID, sSalesmanName, oDetail.Item_ID, oItem.ItemName, clsGenaralName.getName_Tag1(oItem.Tag1_ID), clsGenaralName.getName_Tag2(oItem.Tag2_ID), oItem.ItemCategory_ID, oDetail.Qty,oDetail.TatalAmount * (100 - oInvoice.DiscountPercentage) / 100, 0, 0, clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID), 0, false, 0,0, 0, 0);

                                                            //New        
                                                            //glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasSalesReport.Adddt_sasSalesReportRow("INV", oInvoice.Invoice_ID, oInvoice.InvoiceDate, oInvoice.SalesNoteType_ID, clsGenaralName.getName_SalesNoteType(oInvoice.SalesNoteType_ID), oInvoice.Customer_ID, oCustomer.CustomerName, sSalesmanID, sSalesmanName, oDetail.Item_ID, oItem.ItemName, clsGenaralName.getName_Tag1(oItem.Tag1_ID), clsGenaralName.getName_Tag2(oItem.Tag2_ID), oItem.ItemCategory_ID, oDetail.Qty, oDetail.TatalAmount * (100 - dDisTotal) / 100, 0, 0, clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID), 0, false, 0, 0, 0, 0);
                                                            glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasSalesReport.Adddt_sasSalesReportRow("INV", oInvoice.Invoice_ID, oInvoice.InvoiceDate, oInvoice.SalesNoteType_ID,
                                                                clsGenaralName.getName_SalesNoteType(oInvoice.SalesNoteType_ID), oInvoice.Customer_ID, oCustomer.CustomerName, clsGenaralName.getName_BranchCustomer(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID)), sSalesmanID, sSalesmanName, oDetail.Item_ID,
                                                                oItem.ItemName, clsGenaralName.getName_Tag1(oItem.Tag1_ID), clsGenaralName.getName_Tag2(oItem.Tag2_ID), oItem.ItemCategory_ID, oDetail.Qty, dGrandTotal, 0, 0,
                                                                clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID), 0, false, 0, 0, 0, 0);

                                                    }//(distot+dis1tot+dis2tot+dis3tot)/subtot*100
                                                }
                                            }

                                            #endregion

                                            #region SRN
                                            foreach (tbl_sasSalesReturnedNote oSrn in tbl_sasSalesReturnedNote.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && !p.IsDeleted && !p.IsReturnable && p.SalesReturnedNoteDate.Date >= dtpFrom.Value.Date && p.SalesReturnedNoteDate.Date <= dtpTo.Value.Date))
                                            {
                                                #region Customer
                                                if (bCustomerSelected)
                                                {
                                                    if (oSrn.Customer_ID != txtCustomer.Tag.ToString())
                                                        continue;
                                                }
                                                #endregion

                                                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oSrn.Customer_ID);
                                                if (oCustomer != null)
                                                {
                                                    if (bCustomerClassSelected)
                                                    {
                                                        if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                            continue;
                                                    }
                                                    if (bCustomerTypeSelected)
                                                    {
                                                        if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                            continue;
                                                    }
                                                    if (bCustomerCategorySelected)
                                                    {
                                                        if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                            continue;
                                                    }

                                                    #region Route
                                                    if (bRouteSelected)
                                                    {
                                                        if (!chkUseCustomerMasterRoute.Checked)
                                                        {
                                                            sRouteID = oSrn.Route_ID.ToString();
                                                        }
                                                        else
                                                        {
                                                            foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oSrn.Customer_ID))
                                                            {
                                                                sRouteID = oRoute.Route_ID.ToString();
                                                                if (txtRoute.Tag.ToString() == sRouteID)
                                                                    break;
                                                            }
                                                        }

                                                        if (txtRoute.Tag.ToString() != sRouteID)
                                                            continue;
                                                    }
                                                    #endregion
                                                }

                                                #region check rales rep
                                                if (!chkUseCustomerMastorSaleRep.Checked)
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oSrn.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }
                                                else
                                                    sSalesmanID = oCustomer.SalesRep_ID;

                                                if (bSelesRepSelected)
                                                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                        continue;

                                                sSalesmanName = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID);
                                                #endregion

                                                if (bSalesNoteTypeSelected)
                                                    if (txtSalesNoteType.Tag.ToString() != oSrn.SalesNoteType_ID)
                                                        continue;

                                                decimal dDisPercentage = 0;
                                                decimal dGrandTotal = 0;

                                                foreach (tbl_sasSalesReturnedNote_Detail oDetail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSrn.SalesReturnedNote_ID))
                                                {
                                                    #region Add VAT/ NBT  
                                                    if (oSrn.VatTotal == 0)
                                                    {
                                                        if (oSrn.SubTotal != 0)
                                                        {
                                                            dDisPercentage = (oSrn.DiscountTotal) / oSrn.SubTotal * 100;
                                                            decimal dDiscountedTotal = oDetail.TatalAmount - (oDetail.TatalAmount * dDisPercentage) / 100;
                                                            dGrandTotal = dDiscountedTotal;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        decimal dNBT = 0;
                                                        decimal dDiscountedTotal = 0;
                                                        if (oSrn.SubTotal != 0)
                                                        {
                                                            dDisPercentage = (oSrn.DiscountTotal) / oSrn.SubTotal * 100;
                                                            dDiscountedTotal = oDetail.TatalAmount - (oDetail.TatalAmount * dDisPercentage) / 100;
                                                        }
                                                        if (oSrn.NbtTotal != 0)
                                                        {
                                                            dNBT = dDiscountedTotal + (dDiscountedTotal * 2) / 100;
                                                            dGrandTotal = dNBT + (dNBT * 15) / 100;
                                                        }
                                                        else
                                                            dGrandTotal = dDiscountedTotal + (dDiscountedTotal * 15) / 100;
                                                    }
                                                    #endregion

                                                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oDetail.Item_ID);
                                                    if (oItem != null && oItem.Item_ID != "default")
                                                    {
                                                        #region item Filters
                                                        #region Item Class
                                                        if (bItemClassSelected)
                                                        {
                                                            if (oItem.ItemClass_ID != txtItemClass.Tag.ToString())
                                                                continue;
                                                        }
                                                        #endregion

                                                        #region Item Type
                                                        if (bItemTypeSelected)
                                                        {
                                                            if (oItem.ItemType_ID != TxtItemType.Tag.ToString())
                                                                continue;
                                                        }
                                                        #endregion

                                                        #region Item Catagory
                                                        if (bItemcatagorySelected)
                                                        {
                                                            if (oItem.ItemCategory_ID != TxtItemCat.Tag.ToString())
                                                                continue;
                                                        }
                                                        #endregion

                                                        #region ItemFilter
                                                        if (bItemSelected)
                                                        {
                                                            if (oItem.Item_ID != txtItemID.Tag.ToString())
                                                                continue;
                                                        }
                                                        #endregion
                                                        #endregion
                                                        if (rdoSalesReport_ItemWise_HTML.Checked)
                                                            oSalesReport.Add(new SalesReport("SRN", oSrn.SalesReturnedNote_ID, oSrn.SalesReturnedNoteDate, oSrn.SalesNoteType_ID, sSalesmanID, oCustomer.Customer_ID, oItem.Item_ID, oItem.ItemCategory_ID, -oDetail.TatalAmount * (100 - oSrn.DiscountPercentage) / 100));
                                                        else

                                                            //2017-07-05
                                                            glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasSalesReport.Adddt_sasSalesReportRow("SRN", oSrn.SalesReturnedNote_ID, oSrn.SalesReturnedNoteDate,
                                                                oSrn.SalesNoteType_ID, clsGenaralName.getName_SalesNoteType(oSrn.SalesNoteType_ID), oSrn.Customer_ID, oCustomer.CustomerName, clsGenaralName.getName_BranchCustomer(oSrn.Customer_ID, int.Parse(oSrn.Branch_ID)), sSalesmanID, sSalesmanName,
                                                                oDetail.Item_ID, oItem.ItemName, clsGenaralName.getName_Tag1(oItem.Tag1_ID), clsGenaralName.getName_Tag2(oItem.Tag2_ID), oItem.ItemCategory_ID, -oDetail.Qty,
                                                                -dGrandTotal, 0, 0, clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID), 0, false, 0, 0, 0, 0);
                                                        //2017-07-05 - Old
                                                        //glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasSalesReport.Adddt_sasSalesReportRow("SRN", oSrn.SalesReturnedNote_ID, oSrn.SalesReturnedNoteDate, oSrn.SalesNoteType_ID, clsGenaralName.getName_SalesNoteType(oSrn.SalesNoteType_ID), oSrn.Customer_ID, oCustomer.CustomerName, sSalesmanID, sSalesmanName, oDetail.Item_ID, oItem.ItemName, clsGenaralName.getName_Tag1(oItem.Tag1_ID), clsGenaralName.getName_Tag2(oItem.Tag2_ID), oItem.ItemCategory_ID, -oDetail.Qty, -oDetail.TatalAmount * (100 - oSrn.DiscountPercentage) / 100, 0, 0, clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID), 0, false, 0, 0, 0, 0);
                                                    }
                                                }
                                            }
                                            #endregion

                                            #region POS

                                            if (bIsPOS_Active)
                                            {
                                                //foreach (tbl_posTransaction oPOS in tbl_posTransaction.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(
                                                //    p => !p.IsHold && !p.IsDeleted &&
                                                //        p.PosTransactiondate.Date >= dtpFrom.Value.Date &&
                                                //        p.PosTransactiondate.Date <= dtpTo.Value.Date))
                                                //{
                                                //    if (bRouteSelected)
                                                //        continue;

                                                //    #region Customer
                                                //    if (bCustomerSelected)
                                                //    {
                                                //        if (oPOS.Customer_ID != txtCustomer.Tag.ToString())
                                                //            continue;
                                                //    }
                                                //    #endregion

                                                //    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oPOS.Customer_ID);
                                                //    if (oCustomer != null)
                                                //    {
                                                //        if (bCustomerClassSelected)
                                                //        {
                                                //            if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                //                continue;
                                                //        }
                                                //        if (bCustomerTypeSelected)
                                                //        {
                                                //            if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                //                continue;
                                                //        }
                                                //        if (bCustomerCategorySelected)
                                                //        {
                                                //            if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                //                continue;
                                                //        }
                                                //    }

                                                //    #region Sales Rep Filter

                                                //    if (!chkUseCustomerMastorSaleRep.Checked)
                                                //    {
                                                //        tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oPOS.OrderRefNo_ID);
                                                //        if (oRef != null && oRef.OrderRefNo != "default")
                                                //            sSalesmanID = oRef.Employee_ID;
                                                //    }
                                                //    else
                                                //        sSalesmanID = oCustomer.SalesRep_ID;

                                                //    if (bSelesRepSelected)
                                                //        if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                //            continue;

                                                //    sSalesmanName = sSalesmanID == "default"
                                                //        ? "-"
                                                //        : clsGenaralName.getName_SalesRep(sSalesmanID);

                                                //    #endregion

                                                //    #region Sales note Filter

                                                //    if (bSalesNoteTypeSelected)
                                                //        if (txtSalesNoteType.Tag.ToString() != oPOS.SalesNoteType_ID)
                                                //            continue;

                                                //    #endregion

                                                //    if (bCustomerClassSelected)
                                                //        if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
                                                //            continue;
                                                //    if (bCustomerTypeSelected)
                                                //        if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
                                                //            continue;
                                                //    if (bCustomerCategorySelected)
                                                //        if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
                                                //            continue;

                                                //    decimal dSubTotal = 0,
                                                //        dWithNbtAmount = 0,
                                                //        dNbtAmount = 0,
                                                //        dVatAmount = 0;
                                                //    decimal dMultiplicationRate = 0;
                                                //    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oPOS.GrandTotal, oPOS.VatPercentage, oPOS.NbtPercentage, ref dWithNbtAmount, ref dSubTotal, ref dNbtAmount, ref dVatAmount);

                                                //    if (oPOS.SubTotal > 0)
                                                //        dMultiplicationRate = dSubTotal / oPOS.SubTotal;


                                                //    foreach (tbl_posTransaction_Detail oDetail in tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oPOS.PosTransaction_Index))
                                                //    {
                                                //        tbl_genItemMaster oItem = tbl_genItemMaster.Select(oDetail.Item_ID);
                                                //        if (oItem != null && oItem.Item_ID != "default")
                                                //        {
                                                //            #region item Filters

                                                //            #region Item Class

                                                //            if (bItemClassSelected)
                                                //            {
                                                //                if (oItem.ItemClass_ID != txtItemClass.Tag.ToString())
                                                //                    continue;
                                                //            }

                                                //            #endregion

                                                //            #region Item Type

                                                //            if (bItemTypeSelected)
                                                //            {
                                                //                if (oItem.ItemType_ID != TxtItemType.Tag.ToString())
                                                //                    continue;
                                                //            }

                                                //            #endregion

                                                //            #region Item Catagory

                                                //            if (bItemcatagorySelected)
                                                //            {
                                                //                if (oItem.ItemCategory_ID != TxtItemCat.Tag.ToString())
                                                //                    continue;
                                                //            }

                                                //            #endregion

                                                //            #region ItemFilter

                                                //            if (bItemSelected)
                                                //            {
                                                //                if (oDetail.Item_ID != txtItemID.Tag.ToString())
                                                //                    continue;
                                                //            }

                                                //            #endregion

                                                //            #endregion

                                                //            if (rdoSalesReport_ItemWise_HTML.Checked)
                                                //                oSalesReport.Add(new SalesReport("POS",
                                                //                    oPOS.PosTransaction_ID, oPOS.PosTransactiondate,
                                                //                    oPOS.SalesNoteType_ID, sSalesmanID,
                                                //                    oCustomer.Customer_ID, oItem.Item_ID,
                                                //                    oItem.ItemCategory_ID, oDetail.NetAmount));
                                                //            else
                                                //                glb_dts_sasSales_NoteTypeWise_ItemCategoryWise
                                                //                    .dt_sasSalesReport.Adddt_sasSalesReportRow("POS",
                                                //                        oPOS.PosTransaction_ID, oPOS.PosTransactiondate,
                                                //                        oPOS.SalesNoteType_ID,
                                                //                        clsGenaralName.getName_SalesNoteType(
                                                //                            oPOS.SalesNoteType_ID),
                                                //                        oPOS.Customer_ID,
                                                //                        (oPOS.Customer_ID != "default" ? oCustomer.CustomerName : "-"), "default",
                                                //                        sSalesmanID, sSalesmanName, oDetail.Item_ID, oItem.ItemName,
                                                //                        clsGenaralName.getName_Tag1(oItem.Tag1_ID),
                                                //                        clsGenaralName.getName_Tag2(oItem.Tag2_ID),
                                                //                        oItem.ItemCategory_ID, oDetail.Qty,
                                                //                        //oDetail.NetAmount * dMultiplicationRate, 0, 0,
                                                //                        oDetail.GrossAmount, 0, 0,
                                                //                        clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID), 0, false, 0, 0, 0, 0);
                                                //        }
                                                //    }
                                                //}
                                            }

                                            #endregion

                                            //Add filter from Branch wise - Added by Gayan 2016-10-14
                                            foreach (tbl_genStoreMaster oStore in tbl_genStoreMaster.SelectAll().Where(p => !p.IsDeleted && p.IsShowRoom && p.CompanyBranch_ID == txtBranch.Tag.ToString()))
                                            {
                                                #region iGin
                                                foreach (tbl_scsStoreGoodIssueNote oIgin in tbl_scsStoreGoodIssueNote.SelectAll().Where(p => !p.IsDeleted && p.ToStore_ID == oStore.Store_ID && p.StoreGoodIssueNoteDate.Date >= dtpFrom.Value.Date && p.StoreGoodIssueNoteDate.Date <= dtpTo.Value.Date))
                                                {
                                                    foreach (tbl_scsStoreGoodIssueNote_Detail oDetail in tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(oIgin.StoreGoodIssueNote_ID))
                                                    {
                                                        tbl_genItemMaster oItem = tbl_genItemMaster.Select(oDetail.Item_ID);
                                                        if (oItem != null && oItem.Item_ID != "default")
                                                        {
                                                            #region item Filters
                                                            #region Item Class
                                                            if (bItemClassSelected)
                                                            {
                                                                if (oItem.ItemClass_ID != txtItemClass.Tag.ToString())
                                                                    continue;
                                                            }
                                                            #endregion

                                                            #region Item Type
                                                            if (bItemTypeSelected)
                                                            {
                                                                if (oItem.ItemType_ID != TxtItemType.Tag.ToString())
                                                                    continue;
                                                            }
                                                            #endregion

                                                            #region Item Catagory
                                                            if (bItemcatagorySelected)
                                                            {
                                                                if (oItem.ItemCategory_ID != TxtItemCat.Tag.ToString())
                                                                    continue;
                                                            }
                                                            #endregion

                                                            #region ItemFilter
                                                            if (bItemSelected)
                                                            {
                                                                if (oDetail.Item_ID != txtItemID.Tag.ToString())
                                                                    continue;
                                                            }
                                                            #endregion
                                                            #endregion

                                                            if (rdoSalesReport_ItemWise_HTML.Checked)
                                                                oSalesReport.Add(new SalesReport("iGin", oIgin.StoreGoodIssueNote_ID, oIgin.StoreGoodIssueNoteDate, "csh", "SHS", oStore.Store_ID, oItem.Item_ID, oItem.ItemCategory_ID, oDetail.TotalAmount));
                                                            else
                                                                glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasSalesReport.Adddt_sasSalesReportRow("iGin", oIgin.StoreGoodIssueNote_ID, oIgin.StoreGoodIssueNoteDate, "csh", "Cash Sales", oIgin.ToStore_ID, oStore.StoreName, "default", "SHS", "SHOWROOM SALES",
                                                                    oDetail.Item_ID, oItem.ItemName, clsGenaralName.getName_Tag1(oItem.Tag1_ID), clsGenaralName.getName_Tag2(oItem.Tag2_ID), oItem.ItemCategory_ID, oDetail.Qty,
                                                                    oDetail.TotalAmount, 0, 0, clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID), 0, false, 0, 0, 0, 0);
                                                        }
                                                    }
                                                }
                                                #endregion

                                                #region igrn
                                                foreach (tbl_scsStoreGoodReceiveNote oGrn in tbl_scsStoreGoodReceiveNote.SelectAll().Where(p => !p.IsDeleted && p.ToStore_ID == oStore.Store_ID && p.StoreGoodReceiveNoteDate.Date >= dtpFrom.Value.Date && p.StoreGoodReceiveNoteDate.Date <= dtpTo.Value.Date))
                                                {
                                                    foreach (tbl_scsStoreGoodReceiveNote_Detail oDetail in tbl_scsStoreGoodReceiveNote_Detail.SelectAllByStoreGoodReceiveNote_ID(oGrn.StoreGoodReceiveNote_ID))
                                                    {
                                                        tbl_genItemMaster oItem = tbl_genItemMaster.Select(oDetail.Item_ID);
                                                        if (oItem != null && oItem.Item_ID != "default")
                                                        {
                                                            #region item Filters
                                                            #region Item Class
                                                            if (bItemClassSelected)
                                                            {
                                                                if (oItem.ItemClass_ID != txtItemClass.Tag.ToString())
                                                                    continue;
                                                            }
                                                            #endregion

                                                            #region Item Type
                                                            if (bItemTypeSelected)
                                                            {
                                                                if (oItem.ItemType_ID != TxtItemType.Tag.ToString())
                                                                    continue;
                                                            }
                                                            #endregion

                                                            #region Item Catagory
                                                            if (bItemcatagorySelected)
                                                            {
                                                                if (oItem.ItemCategory_ID != TxtItemCat.Tag.ToString())
                                                                    continue;
                                                            }
                                                            #endregion

                                                            #region ItemFilter
                                                            if (bItemSelected)
                                                            {
                                                                if (oDetail.Item_ID != txtItemID.Tag.ToString())
                                                                    continue;
                                                            }
                                                            #endregion
                                                            #endregion
                                                            if (rdoSalesReport_ItemWise_HTML.Checked)
                                                                oSalesReport.Add(new SalesReport("iGrn", oGrn.StoreGoodReceiveNote_ID, oGrn.StoreGoodReceiveNoteDate, "csh", "SHS", oStore.Store_ID, oItem.Item_ID, oItem.ItemCategory_ID, -oDetail.TotalAmount));
                                                            else
                                                                glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasSalesReport.Adddt_sasSalesReportRow("iGrn", oGrn.StoreGoodReceiveNote_ID, oGrn.StoreGoodReceiveNoteDate,
                                                                    "SRS", "Showroom Sales", "CSH", "Cash Sales", "default", oStore.Store_ID, oStore.StoreName, oDetail.Item_ID, oItem.ItemName, clsGenaralName.getName_Tag1(oItem.Tag1_ID),
                                                                    clsGenaralName.getName_Tag2(oItem.Tag2_ID), oItem.ItemCategory_ID, -oDetail.Qty, -oDetail.TotalAmount, 0, 0, clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID),
                                                                    0, false, 0, 0, 0, 0);
                                                        }
                                                    }
                                                }
                                                #endregion
                                            }

                                            //Add filter from Branch wise - Added by Gayan 2016-10-14
                                            if (rdoSalesReport_ItemWise_HTML.Checked)
                                            {
                                                #region Filters
                                                #region Customer
                                                List<tbl_genCustomerMaster> oCustomerL;
                                                if (bCustomerSelected)
                                                {
                                                    oCustomerL = new List<tbl_genCustomerMaster>();
                                                    oCustomerL.Add(tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString()));
                                                }
                                                else
                                                    oCustomerL = tbl_genCustomerMaster.SelectAll().ToList();
                                                #endregion
                                                #endregion

                                                #region Item Wice Report Only
                                                foreach (tbl_zSalesNoteType oSalesNote in tbl_zSalesNoteType.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString()))
                                                {
                                                    foreach (tbl_genCustomerMaster oCustomer in oCustomerL.Where(p => !p.IsDeleted))
                                                    {
                                                        foreach (tbl_ZEmpSalesRep oSalesrep in tbl_ZEmpSalesRep.SelectAll())
                                                        {
                                                            DataRow dr = dt.NewRow();
                                                            dr["Customer"] = oCustomer.CustomerName;
                                                            dr["salesMen"] = oSalesrep.SelesRepName;

                                                            bool brecordfound = false;
                                                            foreach (SalesReport oRPT in oSalesReport.Where(p => p.SalesNote_Type == oSalesNote.SalesNoteType_ID && p.Customer_Id == oCustomer.Customer_ID && p.Salesrep_Id == oSalesrep.SelesRep_ID))
                                                            {
                                                                brecordfound = true;
                                                                string sAmount = dr[oRPT.item_Id].ToString();

                                                                decimal dAmount = decimal.Parse(sAmount == "" ? "0" : sAmount);
                                                                dr[oRPT.item_Id] = dAmount + oRPT.Ammount;
                                                            }
                                                            if (brecordfound)
                                                                dt.Rows.Add(dr);
                                                        }
                                                    }
                                                }

                                                List<emailLine> lstEData = new List<emailLine>();
                                                EmailLineformating oEmailLineFormat = new EmailLineformating();

                                                string sBodyHTML = "";
                                                #region Create/Format Email Body

                                                #region Data
                                                string Header2 = "Sales Report - Item Wice";

                                                #region Detail
                                                //  DataTable tblEmailDetail = new DataTable();
                                                List<emailLine> lstEmailDetail = new List<emailLine>();

                                                lstEmailDetail.Add(new emailLine(LineType.TableColomn1, "Qty"));
                                                lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Unit Price"));

                                                #endregion
                                                #endregion

                                                #region Calculate Totals
                                                DataRow drTotals = dt.NewRow();
                                                drTotals[1] = "Totals";
                                                int columnIndex = 2;
                                                foreach (DataColumn dc in dt.Columns)
                                                {
                                                    if (dc.DataType == typeof(decimal) && columnIndex < dt.Columns.Count)
                                                    {
                                                        decimal sum = dt.AsEnumerable().Where(p => p.IsNull(dc.ColumnName) == false).Sum(row => row.Field<decimal>(dc.ColumnName));
                                                        drTotals[columnIndex] = sum;
                                                        columnIndex++;
                                                    }
                                                }
                                                dt.Rows.Add(drTotals);
                                                #endregion

                                                lstEData.Add(new emailLine(LineType.H1, ElementAlign.Left, clsSecurity.CompanyName));
                                                lstEData.Add(new emailLine(LineType.H2, ElementAlign.Left, Header2));
                                                lstEData.Add(new emailLine(LineType.Line1));
                                                //  lstEData.Add(new emailLine(LineType.Detail2, "Customer Name", sCustomerName));
                                                lstEData.Add(new emailLine(LineType.Detail2, "Date Range", sDateRange));
                                                lstEData.Add(new emailLine(LineType.Detail2, "Filters", sFilter));
                                                lstEData.Add(new emailLine(LineType.Line1));
                                                lstEData.Add(new emailLine(LineType.DataTable, dt, lstEmailDetail));
                                                lstEData.Add(new emailLine(LineType.Line1));
                                                lstEData.Add(new emailLine(LineType.Footer1, "Software Provider : Digiteq Solutions"));

                                                sBodyHTML = clsEmailConfig.CreateEmailBody(lstEData);

                                                string path = "HTMLReports";
                                                if (!Directory.Exists(path))
                                                {
                                                    Directory.CreateDirectory(path);
                                                }
                                                string fileName = "HTMLReports\\" + DateTime.Now.ToString("yyyymmddss") + "_SalesReport_" + clsSecurity.UserIDLoged + ".html";
                                                using (StreamWriter writetext = new StreamWriter(fileName))
                                                {
                                                    writetext.Write(sBodyHTML);
                                                }
                                                System.Diagnostics.Process.Start(fileName);
                                                #endregion
                                                #endregion
                                            }
                                            else
                                            {
                                                glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);
                                                //   print(sReportPath, "", glb_dts_sasSales_NoteTypeWise_ItemCategoryWise, sFilter);

                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Filter", sFilter, true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isQtyReport", chk_Qty.Checked ? "1" : "0", true);

                                                frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                                rpt.print(sReportPath, glb_dts_sasSales_NoteTypeWise_ItemCategoryWise, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));


                                            }
                                        }
                                        #endregion

                                        #region NEW
                                        else
                                        {
                                            glb_dtsReportExport.Clear();
                                            glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.Clear();

                                            #region item wice report only
                                            List<SalesReport> oSalesReport = new List<SalesReport>();
                                            DataTable dt = new DataTable();
                                            if (rdoSalesReport_ItemWise_HTML.Checked)
                                            {
                                                dt.Columns.Add("Customer");
                                                dt.Columns.Add("salesMen");

                                                foreach (tbl_genItemMaster oItem in tbl_genItemMaster.SelectAll().Where(p => p.Item_ID != "default"))
                                                {
                                                    dt.Columns.Add(oItem.Item_ID, typeof(decimal));
                                                }
                                            }
                                            #endregion

                                            List<tbl_sasInvoice> oInvoices = tbl_sasInvoice.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => !p.IsDeleted && !p.IsOpeningBalance && !p.IsReturnedCheque && !p.IsDebitNote && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date).ToList();
                                            List<tbl_sasSalesReturnedNote> oSrns = tbl_sasSalesReturnedNote.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && !p.IsDeleted && !p.IsReturnable && p.SalesReturnedNoteDate.Date >= dtpFrom.Value.Date && p.SalesReturnedNoteDate.Date <= dtpTo.Value.Date).ToList();

                                            string sSalesmanID = "", sSalesmanName = "", sRouteID = "";

                                            #region inv
                                            foreach (tbl_sasInvoice oInvoice in oInvoices)
                                            {
                                                #region Customer
                                                if (bCustomerSelected)
                                                {
                                                    if (oInvoice.Customer_ID != txtCustomer.Tag.ToString())
                                                        continue;
                                                }
                                                #endregion

                                                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                                if (oCustomer != null)
                                                {
                                                    if (bCustomerClassSelected)
                                                    {
                                                        if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                            continue;
                                                    }
                                                    if (bCustomerTypeSelected)
                                                    {
                                                        if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                            continue;
                                                    }
                                                    if (bCustomerCategorySelected)
                                                    {
                                                        if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                            continue;
                                                    }

                                                    #region Route
                                                    if (bRouteSelected)
                                                    {
                                                        if (!chkUseCustomerMasterRoute.Checked)
                                                        {
                                                            sRouteID = oInvoice.Route_ID.ToString();
                                                        }
                                                        else
                                                        {
                                                            foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oInvoice.Customer_ID))
                                                            {
                                                                sRouteID = oRoute.Route_ID.ToString();
                                                                if (txtRoute.Tag.ToString() == sRouteID)
                                                                    break;
                                                            }
                                                        }

                                                        if (txtRoute.Tag.ToString() != sRouteID)
                                                            continue;
                                                    }
                                                    #endregion
                                                }

                                                #region Sales Rep Filter
                                                if (!chkUseCustomerMastorSaleRep.Checked)
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }
                                                else
                                                    sSalesmanID = oCustomer.SalesRep_ID;

                                                if (bSelesRepSelected)
                                                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                        continue;

                                                sSalesmanName = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID);
                                                #endregion

                                                #region Sales note Filter
                                                if (bSalesNoteTypeSelected)
                                                    if (txtSalesNoteType.Tag.ToString() != oInvoice.SalesNoteType_ID)
                                                        continue;
                                                #endregion

                                                //if (bCustomerClassSelected)
                                                //    if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
                                                //        continue;
                                                //if (bCustomerTypeSelected)
                                                //    if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
                                                //        continue;
                                                //if (bCustomerCategorySelected)
                                                //    if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
                                                //        continue;

                                                decimal bVatPrecentage = oInvoice.VatPercentage, bSVatPrecentage = oInvoice.OtherTaxPercentage, bNbtPrecentage = oInvoice.NbtPercentage;
                                                if (oInvoice.IsVatInvoice && !oInvoice.IsSVatInvoice)
                                                {
                                                    bSVatPrecentage = 0;
                                                }
                                                else if (!oInvoice.IsVatInvoice && oInvoice.IsSVatInvoice)
                                                {
                                                    bVatPrecentage = 0;
                                                }
                                                else
                                                {
                                                    bVatPrecentage = 0;
                                                    bSVatPrecentage = 0;
                                                    bNbtPrecentage = 0;
                                                }

                                                decimal dSubTotal = 0, dWithNbtAmount = 0, dNbtAmount = 0, dVatAmount = 0;
                                                decimal dMultiplicationRate = 0;
                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvoice.GrandTotal, bVatPrecentage, bNbtPrecentage, ref dWithNbtAmount, ref dSubTotal, ref dNbtAmount, ref dVatAmount);

                                                if (oInvoice.SubTotal > 0)
                                                    dMultiplicationRate = dSubTotal / oInvoice.SubTotal;


                                                foreach (tbl_sasInvoice_Detail oDetail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID))
                                                {
                                                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oDetail.Item_ID);
                                                    if (oItem != null && oItem.Item_ID != "default")
                                                    {
                                                        #region item Filters
                                                        #region Item Class
                                                        if (bItemClassSelected)
                                                        {
                                                            if (oItem.ItemClass_ID != txtItemClass.Tag.ToString())
                                                                continue;
                                                        }
                                                        #endregion

                                                        #region Item Type
                                                        if (bItemTypeSelected)
                                                        {
                                                            if (oItem.ItemType_ID != TxtItemType.Tag.ToString())
                                                                continue;
                                                        }
                                                        #endregion

                                                        #region Item Catagory
                                                        if (bItemcatagorySelected)
                                                        {
                                                            if (oItem.ItemCategory_ID != TxtItemCat.Tag.ToString())
                                                                continue;
                                                        }
                                                        #endregion

                                                        #region ItemFilter
                                                        if (bItemSelected)
                                                        {
                                                            if (oDetail.Item_ID != txtItemID.Tag.ToString())
                                                                continue;
                                                        }
                                                        #endregion
                                                        #endregion

                                                        if (rdoSalesReport_ItemWise_HTML.Checked)
                                                            oSalesReport.Add(new SalesReport("INV", oInvoice.Invoice_ID, oInvoice.InvoiceDate, oInvoice.SalesNoteType_ID, sSalesmanID, oCustomer.Customer_ID, oItem.Item_ID, oItem.ItemCategory_ID, oDetail.TatalAmount * (100 - oInvoice.DiscountPercentage) / 100));
                                                        else
                                                            glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasSalesReport.Adddt_sasSalesReportRow("INV", oInvoice.Invoice_ID, oInvoice.InvoiceDate,
                                                                oInvoice.SalesNoteType_ID, clsGenaralName.getName_SalesNoteType(oInvoice.SalesNoteType_ID), oInvoice.Customer_ID, oCustomer.CustomerName, clsGenaralName.getName_BranchCustomer(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID)),
                                                                sSalesmanID, sSalesmanName, oDetail.Item_ID, oItem.ItemName, clsGenaralName.getName_Tag1(oItem.Tag1_ID), clsGenaralName.getName_Tag2(oItem.Tag2_ID),
                                                                oItem.ItemCategory_ID, oDetail.Qty, oDetail.TatalAmount * dMultiplicationRate, 0, 0, clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID), 0,
                                                                false, 0, 0, 0, 0);
                                                    }
                                                }

                                            }
                                            #endregion

                                            #region SRN
                                            foreach (tbl_sasSalesReturnedNote oSrn in oSrns)
                                            {
                                                #region Customer
                                                if (bCustomerSelected)
                                                {
                                                    if (oSrn.Customer_ID != txtCustomer.Tag.ToString())
                                                        continue;
                                                }
                                                #endregion

                                                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oSrn.Customer_ID);
                                                if (oCustomer != null)
                                                {
                                                    if (bCustomerClassSelected)
                                                    {
                                                        if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                            continue;
                                                    }
                                                    if (bCustomerTypeSelected)
                                                    {
                                                        if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                            continue;
                                                    }
                                                    if (bCustomerCategorySelected)
                                                    {
                                                        if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                            continue;
                                                    }

                                                    #region Route
                                                    if (bRouteSelected)
                                                    {
                                                        if (!chkUseCustomerMasterRoute.Checked)
                                                        {
                                                            sRouteID = oSrn.Route_ID.ToString();
                                                        }
                                                        else
                                                        {
                                                            foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oSrn.Customer_ID))
                                                            {
                                                                sRouteID = oRoute.Route_ID.ToString();
                                                                if (txtRoute.Tag.ToString() == sRouteID)
                                                                    break;
                                                            }
                                                        }

                                                        if (txtRoute.Tag.ToString() != sRouteID)
                                                            continue;
                                                    }
                                                    #endregion
                                                }

                                                #region Sales Rep Filter
                                                if (!chkUseCustomerMastorSaleRep.Checked)
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oSrn.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }
                                                else
                                                    sSalesmanID = oCustomer.SalesRep_ID;

                                                if (bSelesRepSelected)
                                                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                        continue;

                                                sSalesmanName = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID);
                                                #endregion

                                                #region Sales Note Filter
                                                if (bSalesNoteTypeSelected)
                                                    if (txtSalesNoteType.Tag.ToString() != oSrn.SalesNoteType_ID)
                                                        continue;
                                                #endregion

                                                decimal bVatPrecentage = oSrn.VatPercentage, bSVatPrecentage = oSrn.OtherTaxPercentage, bNbtPrecentage = oSrn.NbtPercentage;
                                                if (oSrn.VatTotal > 0 && oSrn.NbtTotal > 0)
                                                {
                                                    bSVatPrecentage = 0;
                                                }
                                                else if (oSrn.OtherTaxTotal > 0 && oSrn.NbtTotal > 0)
                                                {
                                                    bVatPrecentage = 0;
                                                }
                                                else
                                                {
                                                    bVatPrecentage = 0;
                                                    bSVatPrecentage = 0;
                                                    bNbtPrecentage = 0;
                                                }

                                                decimal dSubTotal = 0, dWithNbtAmount = 0, dNbtAmount = 0, dVatAmount = 0;
                                                decimal dMultiplicationRate = 0;

                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oSrn.GrandTotal, bVatPrecentage, bNbtPrecentage, ref dWithNbtAmount, ref dSubTotal, ref dNbtAmount, ref dVatAmount);
                                                if (oSrn.SubTotal > 0)
                                                    dMultiplicationRate = dSubTotal / oSrn.SubTotal;


                                                foreach (tbl_sasSalesReturnedNote_Detail oDetail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSrn.SalesReturnedNote_ID))
                                                {
                                                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oDetail.Item_ID);
                                                    if (oItem != null && oItem.Item_ID != "default")
                                                    {
                                                        #region item Filters
                                                        #region Item Class
                                                        if (bItemClassSelected)
                                                        {
                                                            if (oItem.ItemClass_ID != txtItemClass.Tag.ToString())
                                                                continue;
                                                        }
                                                        #endregion

                                                        #region Item Type
                                                        if (bItemTypeSelected)
                                                        {
                                                            if (oItem.ItemType_ID != TxtItemType.Tag.ToString())
                                                                continue;
                                                        }
                                                        #endregion

                                                        #region Item Catagory
                                                        if (bItemcatagorySelected)
                                                        {
                                                            if (oItem.ItemCategory_ID != TxtItemCat.Tag.ToString())
                                                                continue;
                                                        }
                                                        #endregion

                                                        #region ItemFilter
                                                        if (bItemSelected)
                                                        {
                                                            if (oItem.Item_ID != txtItemID.Tag.ToString())
                                                                continue;
                                                        }
                                                        #endregion
                                                        #endregion

                                                        if (rdoSalesReport_ItemWise_HTML.Checked)
                                                            oSalesReport.Add(new SalesReport("SRN", oSrn.SalesReturnedNote_ID, oSrn.SalesReturnedNoteDate, oSrn.SalesNoteType_ID, sSalesmanID, oCustomer.Customer_ID, oItem.Item_ID, oItem.ItemCategory_ID, -oDetail.TatalAmount * (100 - oSrn.DiscountPercentage) / 100));
                                                        else
                                                            glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasSalesReport.Adddt_sasSalesReportRow("SRN", oSrn.SalesReturnedNote_ID, oSrn.SalesReturnedNoteDate,
                                                                oSrn.SalesNoteType_ID, clsGenaralName.getName_SalesNoteType(oSrn.SalesNoteType_ID), oSrn.Customer_ID, oCustomer.CustomerName, clsGenaralName.getName_BranchCustomer(oSrn.Customer_ID, int.Parse(oSrn.Branch_ID)), sSalesmanID, sSalesmanName,
                                                                oDetail.Item_ID, oItem.ItemName, clsGenaralName.getName_Tag1(oItem.Tag1_ID), clsGenaralName.getName_Tag2(oItem.Tag2_ID), oItem.ItemCategory_ID,
                                                                -oDetail.Qty, -oDetail.TatalAmount * dMultiplicationRate, 0, 0, clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID), 0, false, 0, 0, 0, 0);
                                                    }
                                                }
                                            }
                                            #endregion

                                            #region POS

                                            if (bIsPOS_Active)
                                            {
                                                //foreach (tbl_posTransaction oPOS in tbl_posTransaction.SelectAll().Where(
                                                //    p => !p.IsHold &&
                                                //        !p.IsDeleted &&
                                                //        p.PosTransactiondate.Date >= dtpFrom.Value.Date &&
                                                //        p.PosTransactiondate.Date <= dtpTo.Value.Date))
                                                //{

                                                //    if (bRouteSelected)
                                                //        continue;

                                                //    #region Customer
                                                //    if (bCustomerSelected)
                                                //    {
                                                //        if (oPOS.Customer_ID != txtCustomer.Tag.ToString())
                                                //            continue;
                                                //    }
                                                //    #endregion

                                                //    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oPOS.Customer_ID);
                                                //    if (oCustomer != null)
                                                //    {
                                                //        if (bCustomerClassSelected)
                                                //        {
                                                //            if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                //                continue;
                                                //        }
                                                //        if (bCustomerTypeSelected)
                                                //        {
                                                //            if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                //                continue;
                                                //        }
                                                //        if (bCustomerCategorySelected)
                                                //        {
                                                //            if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                //                continue;
                                                //        }
                                                //    }

                                                //    #region Sales Rep Filter

                                                //    if (!chkUseCustomerMastorSaleRep.Checked)
                                                //    {
                                                //        tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oPOS.OrderRefNo_ID);
                                                //        if (oRef != null && oRef.OrderRefNo != "default")
                                                //            sSalesmanID = oRef.Employee_ID;
                                                //    }
                                                //    else
                                                //        sSalesmanID = oCustomer.SalesRep_ID;

                                                //    if (bSelesRepSelected)
                                                //        if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                //            continue;

                                                //    sSalesmanName = sSalesmanID == "default"
                                                //        ? "-"
                                                //        : clsGenaralName.getName_SalesRep(sSalesmanID);

                                                //    #endregion

                                                //    #region Sales note Filter

                                                //    if (bSalesNoteTypeSelected)
                                                //        if (txtSalesNoteType.Tag.ToString() != oPOS.SalesNoteType_ID)
                                                //            continue;

                                                //    #endregion

                                                //    //if (bCustomerClassSelected)
                                                //    //    if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
                                                //    //        continue;
                                                //    //if (bCustomerTypeSelected)
                                                //    //    if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
                                                //    //        continue;
                                                //    //if (bCustomerCategorySelected)
                                                //    //    if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
                                                //    //        continue;

                                                //    decimal bVatPrecentage = oPOS.VatPercentage, bSVatPrecentage = oPOS.OtherTaxPercentage, bNbtPrecentage = oPOS.NbtPercentage;
                                                //    if (oPOS.VatTotal > 0 && oPOS.NbtTotal > 0)
                                                //    {
                                                //        bSVatPrecentage = 0;
                                                //    }
                                                //    else if (oPOS.OtherTaxTotal > 0 && oPOS.NbtTotal > 0)
                                                //    {
                                                //        bVatPrecentage = 0;
                                                //    }
                                                //    else
                                                //    {
                                                //        bVatPrecentage = 0;
                                                //        bSVatPrecentage = 0;
                                                //        bNbtPrecentage = 0;
                                                //    }

                                                //    decimal dSubTotal = 0, dWithNbtAmount = 0, dNbtAmount = 0, dVatAmount = 0;
                                                //    decimal dMultiplicationRate = 0;
                                                //    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oPOS.GrandTotal, bVatPrecentage, bNbtPrecentage, ref dWithNbtAmount, ref dSubTotal, ref dNbtAmount, ref dVatAmount);

                                                //    if (oPOS.SubTotal > 0)
                                                //        dMultiplicationRate = dSubTotal / oPOS.SubTotal;


                                                //    foreach (tbl_posTransaction_Detail oDetail in tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oPOS.PosTransaction_Index))
                                                //    {
                                                //        tbl_genItemMaster oItem = tbl_genItemMaster.Select(oDetail.Item_ID);
                                                //        if (oItem != null && oItem.Item_ID != "default")
                                                //        {
                                                //            #region item Filters

                                                //            #region Item Class

                                                //            if (bItemClassSelected)
                                                //            {
                                                //                if (oItem.ItemClass_ID != txtItemClass.Tag.ToString())
                                                //                    continue;
                                                //            }

                                                //            #endregion

                                                //            #region Item Type

                                                //            if (bItemTypeSelected)
                                                //            {
                                                //                if (oItem.ItemType_ID != TxtItemType.Tag.ToString())
                                                //                    continue;
                                                //            }

                                                //            #endregion

                                                //            #region Item Catagory

                                                //            if (bItemcatagorySelected)
                                                //            {
                                                //                if (oItem.ItemCategory_ID != TxtItemCat.Tag.ToString())
                                                //                    continue;
                                                //            }

                                                //            #endregion

                                                //            #region ItemFilter

                                                //            if (bItemSelected)
                                                //            {
                                                //                if (oDetail.Item_ID != txtItemID.Tag.ToString())
                                                //                    continue;
                                                //            }

                                                //            #endregion

                                                //            #endregion

                                                //            if (rdoSalesReport_ItemWise_HTML.Checked)
                                                //                oSalesReport.Add(new SalesReport("POS",
                                                //                    oPOS.PosTransaction_ID, oPOS.PosTransactiondate,
                                                //                    oPOS.SalesNoteType_ID, sSalesmanID,
                                                //                    oCustomer.Customer_ID, oItem.Item_ID,
                                                //                    oItem.ItemCategory_ID, oDetail.NetAmount));
                                                //            else
                                                //                glb_dts_sasSales_NoteTypeWise_ItemCategoryWise
                                                //                    .dt_sasSalesReport.Adddt_sasSalesReportRow("POS",
                                                //                        oPOS.PosTransaction_ID, oPOS.PosTransactiondate,
                                                //                        oPOS.SalesNoteType_ID,
                                                //                        clsGenaralName.getName_SalesNoteType(
                                                //                            oPOS.SalesNoteType_ID),
                                                //                        oPOS.Customer_ID,
                                                //                        (oPOS.Customer_ID != "default" ? oCustomer.CustomerName : "-"), "default",
                                                //                        sSalesmanID, sSalesmanName, oDetail.Item_ID, oItem.ItemName,
                                                //                        clsGenaralName.getName_Tag1(oItem.Tag1_ID),
                                                //                        clsGenaralName.getName_Tag2(oItem.Tag2_ID),
                                                //                        oItem.ItemCategory_ID, oDetail.Qty,
                                                //                        oDetail.NetAmount * dMultiplicationRate, 0, 0,
                                                //                        clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID), 0, false, 0, 0, 0, 0);
                                                //        }
                                                //    }
                                                //}
                                            }

                                            #endregion

                                            if (chkShowShowrooms.Checked)
                                            {
                                                foreach (tbl_genStoreMaster oStore in tbl_genStoreMaster.SelectAll().Where(p => !p.IsDeleted && p.IsShowRoom && p.CompanyBranch_ID == txtBranch.Tag.ToString()))
                                                {
                                                    #region iGin
                                                    foreach (tbl_scsStoreGoodIssueNote oIgin in tbl_scsStoreGoodIssueNote.SelectAll().Where(p => !p.IsDeleted && p.ToStore_ID == oStore.Store_ID && p.StoreGoodIssueNoteDate.Date >= dtpFrom.Value.Date && p.StoreGoodIssueNoteDate.Date <= dtpTo.Value.Date))
                                                    {
                                                        foreach (tbl_scsStoreGoodIssueNote_Detail oDetail in tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(oIgin.StoreGoodIssueNote_ID))
                                                        {
                                                            tbl_genItemMaster oItem = tbl_genItemMaster.Select(oDetail.Item_ID);
                                                            if (oItem != null && oItem.Item_ID != "default")
                                                            {
                                                                #region item Filters
                                                                #region Item Class
                                                                if (bItemClassSelected)
                                                                {
                                                                    if (oItem.ItemClass_ID != txtItemClass.Tag.ToString())
                                                                        continue;
                                                                }
                                                                #endregion

                                                                #region Item Type
                                                                if (bItemTypeSelected)
                                                                {
                                                                    if (oItem.ItemType_ID != TxtItemType.Tag.ToString())
                                                                        continue;
                                                                }
                                                                #endregion

                                                                #region Item Catagory
                                                                if (bItemcatagorySelected)
                                                                {
                                                                    if (oItem.ItemCategory_ID != TxtItemCat.Tag.ToString())
                                                                        continue;
                                                                }
                                                                #endregion

                                                                #region ItemFilter
                                                                if (bItemSelected)
                                                                {
                                                                    if (oDetail.Item_ID != txtItemID.Tag.ToString())
                                                                        continue;
                                                                }
                                                                #endregion
                                                                #endregion

                                                                if (rdoSalesReport_ItemWise_HTML.Checked)
                                                                    oSalesReport.Add(new SalesReport("iGin", oIgin.StoreGoodIssueNote_ID, oIgin.StoreGoodIssueNoteDate, "csh", "SHS", oStore.Store_ID, oItem.Item_ID, oItem.ItemCategory_ID, oDetail.TotalAmount));
                                                                else
                                                                    glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasSalesReport.Adddt_sasSalesReportRow("iGin", oIgin.StoreGoodIssueNote_ID, oIgin.StoreGoodIssueNoteDate,
                                                                        "csh", "Cash Sales", oIgin.ToStore_ID, oStore.StoreName, "", "SHS", "SHOWROOM SALES", oDetail.Item_ID, oItem.ItemName, clsGenaralName.getName_Tag1(oItem.Tag1_ID), clsGenaralName.getName_Tag2(oItem.Tag2_ID), oItem.ItemCategory_ID, oDetail.Qty, oDetail.TotalAmount, 0, 0, clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID), 0, false, 0, 0, 0, 0);
                                                            }
                                                        }
                                                    }
                                                    #endregion

                                                    #region igrn
                                                    foreach (tbl_scsStoreGoodReceiveNote oGrn in tbl_scsStoreGoodReceiveNote.SelectAll().Where(p => !p.IsDeleted && p.ToStore_ID == oStore.Store_ID && p.StoreGoodReceiveNoteDate.Date >= dtpFrom.Value.Date && p.StoreGoodReceiveNoteDate.Date <= dtpTo.Value.Date))
                                                    {
                                                        foreach (tbl_scsStoreGoodReceiveNote_Detail oDetail in tbl_scsStoreGoodReceiveNote_Detail.SelectAllByStoreGoodReceiveNote_ID(oGrn.StoreGoodReceiveNote_ID))
                                                        {
                                                            tbl_genItemMaster oItem = tbl_genItemMaster.Select(oDetail.Item_ID);
                                                            if (oItem != null && oItem.Item_ID != "default")
                                                            {
                                                                #region item Filters
                                                                #region Item Class
                                                                if (bItemClassSelected)
                                                                {
                                                                    if (oItem.ItemClass_ID != txtItemClass.Tag.ToString())
                                                                        continue;
                                                                }
                                                                #endregion

                                                                #region Item Type
                                                                if (bItemTypeSelected)
                                                                {
                                                                    if (oItem.ItemType_ID != TxtItemType.Tag.ToString())
                                                                        continue;
                                                                }
                                                                #endregion

                                                                #region Item Catagory
                                                                if (bItemcatagorySelected)
                                                                {
                                                                    if (oItem.ItemCategory_ID != TxtItemCat.Tag.ToString())
                                                                        continue;
                                                                }
                                                                #endregion

                                                                #region ItemFilter
                                                                if (bItemSelected)
                                                                {
                                                                    if (oDetail.Item_ID != txtItemID.Tag.ToString())
                                                                        continue;
                                                                }
                                                                #endregion
                                                                #endregion

                                                                if (rdoSalesReport_ItemWise_HTML.Checked)
                                                                    oSalesReport.Add(new SalesReport("iGrn", oGrn.StoreGoodReceiveNote_ID, oGrn.StoreGoodReceiveNoteDate, "csh", "SHS", oStore.Store_ID, oItem.Item_ID, oItem.ItemCategory_ID, -oDetail.TotalAmount));
                                                                else
                                                                    glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasSalesReport.Adddt_sasSalesReportRow("iGrn", oGrn.StoreGoodReceiveNote_ID,
                                                                        oGrn.StoreGoodReceiveNoteDate, "SRS", "Showroom Sales", "CSH", "Cash Sales", "default", oStore.Store_ID, oStore.StoreName, oDetail.Item_ID,
                                                                        oItem.ItemName, clsGenaralName.getName_Tag1(oItem.Tag1_ID), clsGenaralName.getName_Tag2(oItem.Tag2_ID), oItem.ItemCategory_ID,
                                                                        -oDetail.Qty, -oDetail.TotalAmount, 0, 0, clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID), 0, false, 0, 0, 0, 0);
                                                            }
                                                        }
                                                    }
                                                    #endregion
                                                }
                                            }

                                            if (rdoSalesReport_ItemWise_HTML.Checked)
                                            {
                                                #region Filters
                                                #region Customer
                                                List<tbl_genCustomerMaster> oCustomerL;
                                                if (bCustomerSelected)
                                                {
                                                    oCustomerL = new List<tbl_genCustomerMaster>();
                                                    oCustomerL.Add(tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString()));
                                                }
                                                else
                                                    oCustomerL = tbl_genCustomerMaster.SelectAll().ToList();
                                                #endregion
                                                #endregion

                                                #region Item Wice Report Only
                                                foreach (tbl_zSalesNoteType oSalesNote in tbl_zSalesNoteType.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString()))
                                                {
                                                    foreach (tbl_genCustomerMaster oCustomer in oCustomerL.Where(p => !p.IsDeleted))
                                                    {
                                                        foreach (tbl_ZEmpSalesRep oSalesrep in tbl_ZEmpSalesRep.SelectAll())
                                                        {
                                                            DataRow dr = dt.NewRow();
                                                            dr["Customer"] = oCustomer.CustomerName;
                                                            dr["salesMen"] = oSalesrep.SelesRepName;

                                                            bool brecordfound = false;
                                                            foreach (SalesReport oRPT in oSalesReport.Where(p => p.SalesNote_Type == oSalesNote.SalesNoteType_ID && p.Customer_Id == oCustomer.Customer_ID && p.Salesrep_Id == oSalesrep.SelesRep_ID))
                                                            {
                                                                brecordfound = true;
                                                                string sAmount = dr[oRPT.item_Id].ToString();

                                                                decimal dAmount = decimal.Parse(sAmount == "" ? "0" : sAmount);
                                                                dr[oRPT.item_Id] = dAmount + oRPT.Ammount;
                                                            }
                                                            if (brecordfound)
                                                                dt.Rows.Add(dr);
                                                        }
                                                    }
                                                }

                                                List<emailLine> lstEData = new List<emailLine>();
                                                EmailLineformating oEmailLineFormat = new EmailLineformating();

                                                string sBodyHTML = "";
                                                #region Create/Format Email Body

                                                #region Data
                                                string Header2 = "Sales Report - Item Wice";

                                                #region Detail
                                                //  DataTable tblEmailDetail = new DataTable();
                                                List<emailLine> lstEmailDetail = new List<emailLine>();

                                                lstEmailDetail.Add(new emailLine(LineType.TableColomn1, "Qty"));
                                                lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Unit Price"));

                                                #endregion
                                                #endregion

                                                #region Calculate Totals
                                                DataRow drTotals = dt.NewRow();
                                                drTotals[1] = "Totals";
                                                int columnIndex = 2;
                                                foreach (DataColumn dc in dt.Columns)
                                                {
                                                    if (dc.DataType == typeof(decimal) && columnIndex < dt.Columns.Count)
                                                    {
                                                        decimal sum = dt.AsEnumerable().Where(p => p.IsNull(dc.ColumnName) == false).Sum(row => row.Field<decimal>(dc.ColumnName));
                                                        drTotals[columnIndex] = sum;
                                                        columnIndex++;
                                                    }
                                                }
                                                dt.Rows.Add(drTotals);
                                                #endregion

                                                lstEData.Add(new emailLine(LineType.H1, ElementAlign.Left, clsSecurity.CompanyName));
                                                lstEData.Add(new emailLine(LineType.H2, ElementAlign.Left, Header2));
                                                lstEData.Add(new emailLine(LineType.Line1));
                                                //  lstEData.Add(new emailLine(LineType.Detail2, "Customer Name", sCustomerName));
                                                lstEData.Add(new emailLine(LineType.Detail2, "Date Range", sDateRange));
                                                lstEData.Add(new emailLine(LineType.Detail2, "Filters", sFilter));
                                                lstEData.Add(new emailLine(LineType.Line1));
                                                lstEData.Add(new emailLine(LineType.DataTable, dt, lstEmailDetail));
                                                lstEData.Add(new emailLine(LineType.Line1));
                                                lstEData.Add(new emailLine(LineType.Footer1, "Software Provider : Digiteq Solutions"));

                                                sBodyHTML = clsEmailConfig.CreateEmailBody(lstEData);

                                                string path = "HTMLReports";
                                                if (!Directory.Exists(path))
                                                {
                                                    Directory.CreateDirectory(path);
                                                }
                                                string fileName = "HTMLReports\\" + DateTime.Now.ToString("yyyymmddss") + "_SalesReport_" + clsSecurity.UserIDLoged + ".html";
                                                using (StreamWriter writetext = new StreamWriter(fileName))
                                                {
                                                    writetext.Write(sBodyHTML);
                                                }
                                                System.Diagnostics.Process.Start(fileName);
                                                #endregion
                                                #endregion
                                            }
                                            else
                                            {
                                                glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);
                                                //   print(sReportPath, "", glb_dts_sasSales_NoteTypeWise_ItemCategoryWise, sFilter);

                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Filter", sFilter, true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isQtyReport", chk_Qty.Checked ? "1" : "0", true);

                                                frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                                rpt.print(sReportPath, glb_dts_sasSales_NoteTypeWise_ItemCategoryWise, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                            }
                                        }
                                        #endregion
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glb_dtsReportExport.Clear();
                                        glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.Clear();
                                    }
                                }
                                #endregion

                                #region Discounted Item Report
                                else if (Report == enum_ReportName.ST_DiscountedItem || Report == enum_ReportName.ST_FreeItem)
                                {
                                    //string bIsFree = "%%", bIsSales = "0";
                                    //bool bIsCustomerMasterSalesRep = false;

                                    //if (chkUseCustomerMastorSaleRep.Checked)
                                    //    bIsCustomerMasterSalesRep = true;

                                    //if (Report == enum_ReportName.ST_FreeItem)
                                    //    bIsFree = true;

                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;

                                        glb_dts_sasInvoice.Clear();
                                        glb_dtsReportExport.Clear();

                                        string sDaterange = "From " + dtpFrom.Value.Date.ToString("dd-MMM-yyyy") + " TO " + dtpTo.Value.Date.ToString("dd-MMM-yyyy");

                                        #region Old
                                        //#region Filters
                                        //#region Customer
                                        //List<tbl_genCustomerMaster> oCustomerL;
                                        //List<tbl_sasInvoice> oInvoiceL;
                                        //if (bCustomerSelected)
                                        //{
                                        //    oCustomerL = new List<tbl_genCustomerMaster>();
                                        //    oCustomerL.Add(tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString()));
                                        //    oInvoiceL = tbl_sasInvoice.SelectAllByCustomer_ID(txtCustomer.Tag.ToString());
                                        //}
                                        //else
                                        //{
                                        //    oCustomerL = tbl_genCustomerMaster.SelectAll().ToList();
                                        //    oInvoiceL = tbl_sasInvoice.SelectAll();
                                        //}
                                        //#endregion
                                        //#endregion

                                        //foreach (tbl_genCustomerMaster oCustomer in oCustomerL.Where(p => !p.IsDeleted && p.CompanyBranch_ID == clsSecurity.BranchID))
                                        //{ 
                                        //    #region invoice
                                        //    foreach (tbl_sasInvoice oInvoice in oInvoiceL.Where(p =>p.Customer_ID==oCustomer.Customer_ID && !p.IsDeleted && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date))
                                        //    {
                                        //        foreach (tbl_sasInvoice_Detail oDetail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID).Where(i => i.DiscountPresentage > 0))
                                        //        {
                                        //            if (bItemSelected)
                                        //                if (oDetail.Item_ID != txtItemID.Tag.ToString())
                                        //                    continue;

                                        //            glb_dts_sasInvoice.dt_sasInvoice_Detail.Adddt_sasInvoice_DetailRow(oDetail.Invoice_ID, oDetail.Item_ID, "itembrandmodel", oDetail.UnitPrice, oDetail.Qty, clsGenaralName.getName_Item(oDetail.Item_ID), oDetail.Remark, clsGenaralName.getName_Uom(oDetail.Uom_ID), int.Parse(oDetail.ItemSerialNo), clsGenaralName.getName_ItemSubCategory(oDetail.ItemSubCategory_ID), oDetail.DiscountPresentage, oDetail.DiscountAmount, oDetail.TatalAmount, oDetail.BIsFreeItem, 0, "");
                                        //        }
                                        //        glb_dts_sasInvoice.dt_sasInvoice.Adddt_sasInvoiceRow(oInvoice.Invoice_ID, oInvoice.InvoiceDate, oInvoice.Customer_ID, oCustomer.CustomerName, oCustomer.AddressDelivery, oInvoice.Branch_ID, clsGenaralName.getName_Employee(oInvoice.Employee_ID), oInvoice.IsDeleted, oInvoice.DeliveryOrder_ID, oInvoice.Invoice_ID, oInvoice.SubTotal, oInvoice.DiscountPercentage, oInvoice.DiscountTotal, 0, oInvoice.NbtPercentage,
                                        //        oInvoice.NbtPercentage, oInvoice.VatPercentage, oInvoice.VatTotal, 0, 0, oInvoice.GrandTotal, oInvoice.OrderRefNo_ID, clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID), "VATRegNo", "NBTRegNo", "TAX type", oInvoice.IsWeightCalculation, oInvoice.InvoiceDate, oInvoice.DiscountPercentage, oInvoice.DiscountPercentage, oInvoice.DiscountPercentage, oInvoice.DiscountTotal, oInvoice.DiscountTotal, oInvoice.DiscountTotal, "PO No", oInvoice.RecommendedGrandTotal.ToString(), "PO Date", oInvoice.PaymentMode, oInvoice.IsVatInvoice, oInvoice.IsVatInvoice, oInvoice.PaymentTerms, oInvoice.Remark, oInvoice.Currency_ID, clsGenaralName.getName_CurrencyCode(oInvoice.Currency_ID));
                                        //    }
                                        //    #endregion
                                        //} 
                                        #endregion

                                        string sSalesrep = "%%";
                                        string sCustomer = "%%";
                                        string sCustomerType = "%%";
                                        string sCustomerCategory = "%%";
                                        string sCustomerClass = "%%";
                                        string sItem = "%%";
                                        string sItemType = "%%";
                                        string sItemCategory = "%%";
                                        string sItemClass = "%%";

                                        //string sQuary = "exec [sp_DiscountedItems] '" + dtpFrom.Value.Date.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.Date.ToString("yyyy-MM-dd") + "','" + clsSecurity.BranchID + "','%%' ";
                                        //if (bCustomerSelected)
                                        //    sQuary = "exec [sp_DiscountedItems] '" + dtpFrom.Value.Date.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.Date.ToString("yyyy-MM-dd") + "','" + clsSecurity.BranchID + "','" + txtCustomer.Tag.ToString() + "' ";

                                        if (bSelesRepSelected)
                                            sSalesrep = txtSalesRep.Tag.ToString();
                                        if (bCustomerSelected)
                                            sCustomer = txtCustomer.Tag.ToString();
                                        if (bCustomerTypeSelected)
                                            sCustomerType = txtCusType.Tag.ToString();
                                        if (bCustomerCategorySelected)
                                            sCustomerCategory = txtCusCategory.Tag.ToString();
                                        if (bCustomerClassSelected)
                                            sCustomerClass = txtCusClass.Tag.ToString();

                                        if (bItemSelected)
                                            sItem = txtItemID.Tag.ToString();
                                        if (bItemTypeSelected)
                                            sItemType = TxtItemType.Tag.ToString();
                                        if (bItemcatagorySelected)
                                            sItemCategory = TxtItemCat.Tag.ToString();
                                        if (bItemClassSelected)
                                            sItemClass = txtItemClass.Tag.ToString();

                                        string sQuary = "";

                                        if (Report == enum_ReportName.ST_FreeItem)
                                            sQuary = "exec [sp_FreeItems] '" + dtpFrom.Value.Date.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.Date.ToString("yyyy-MM-dd") + "','" + txtBranch.Tag.ToString() + "','" + sSalesrep + "','" + sCustomer + "','" + sCustomerType + "','" + sCustomerCategory + "','" + sCustomerClass + "' ,'" + sItem + "' ,'" + sItemType + "' ,'" + sItemCategory + "' ,'" + sItemClass + "' ,'" + (chkUseCustomerMastorSaleRep.Checked ? 1 : 0) + "'";
                                        else
                                            sQuary = "exec [sp_DiscountedItems] '" + dtpFrom.Value.Date.ToString("yyyy-MM-dd") + "','" + dtpTo.Value.Date.ToString("yyyy-MM-dd") + "','" + txtBranch.Tag.ToString() + "','" + sSalesrep + "','" + sCustomer + "','" + sCustomerType + "','" + sCustomerCategory + "','" + sCustomerClass + "' ,'" + sItem + "' ,'" + sItemType + "' ,'" + sItemCategory + "' ,'" + sItemClass + "' ,'" + (chkUseCustomerMastorSaleRep.Checked ? 1 : 0) + "'";

                                        glb_dts_sasInvoice.dt_discountedItem.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                        glb_dts_sasInvoice.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);
                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dts_sasInvoice, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }

                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glb_dts_sasInvoice.Clear();
                                    }
                                }
                                #endregion

                                #region Sales report - Invoice Wise
                                else if (Report == enum_ReportName.ST_SalesReport_Invoice_Wise)
                                {
                                    try
                                    {
                                        bool bIsPOS_Active = false;
                                        tbl_cfgModule oPOS_Module = tbl_cfgModule.Select(clsConfig.sMod_POS);
                                        if (oPOS_Module != null && oPOS_Module.IsEnable)
                                            bIsPOS_Active = true;

                                        #region OLD REPORT
                                        if (!chkShowUpdatedReport.Checked)
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.Clear();
                                            glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.Clear();

                                            sReportPath = "\\Reports\\SAS\\Standard\\rpt_sas_SalesReport_InvoiceWice_OLD.rpt";// clsHelpMethods.GetReportPath(sReportNo);
                                            string sSalesmanID = "", sRouteID = "";                                                                            //  string sDateRange = "From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "  To : " + dtpTo.Value.ToString("dd MMM yyyy");

                                            //Added By Gayan 2016-10-14                                

                                            #region inv
                                            List<tbl_sasInvoice> oInv = tbl_sasInvoice.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => !p.IsDeleted && !p.IsDebitNote && !p.IsReturnedCheque && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date).ToList();
                                            foreach (tbl_sasInvoice oInvoice in oInv)
                                            {
                                                #region Customer
                                                if (bCustomerSelected)
                                                {
                                                    if (oInvoice.Customer_ID != txtCustomer.Tag.ToString())
                                                        continue;
                                                }
                                                #endregion

                                                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                                if (oCustomer != null)
                                                {
                                                    sSalesmanID = oCustomer.SalesRep_ID;

                                                    if (bCustomerClassSelected)
                                                    {
                                                        if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                            continue;
                                                    }
                                                    if (bCustomerTypeSelected)
                                                    {
                                                        if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                            continue;
                                                    }
                                                    if (bCustomerCategorySelected)
                                                    {
                                                        if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                            continue;
                                                    }

                                                    #region Route
                                                    if (bRouteSelected)
                                                    {
                                                        if (!chkUseCustomerMasterRoute.Checked)
                                                        {
                                                            sRouteID = oInvoice.Route_ID.ToString();
                                                        }
                                                        else
                                                        {
                                                            foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oInvoice.Customer_ID))
                                                            {
                                                                sRouteID = oRoute.Route_ID.ToString();
                                                                if (txtRoute.Tag.ToString() == sRouteID)
                                                                    break;
                                                            }
                                                        }

                                                        if (txtRoute.Tag.ToString() != sRouteID)
                                                            continue;
                                                    }
                                                    #endregion
                                                }

                                                #region check rales rep
                                                if (!chkUseCustomerMastorSaleRep.Checked)
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }

                                                if (bSelesRepSelected)
                                                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                        break;
                                                #endregion

                                                if (bSalesNoteTypeSelected)
                                                    if (txtSalesNoteType.Tag.ToString() != oInvoice.SalesNoteType_ID)
                                                        continue;

                                                //Old 2017-07-10
                                                //glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasSalesReport_InvoicwWice.Adddt_sasSalesReport_InvoicwWiceRow("Sales", oInvoice.Invoice_ID, oInvoice.InvoiceDate, "DO<" + oInvoice.DeliveryOrder_ID + ">", oInvoice.SalesNoteType_ID, clsGenaralName.getName_SalesNoteType(oInvoice.SalesNoteType_ID), oInvoice.Customer_ID, oCustomer.CustomerName, oInvoice.SubTotal, 0, oInvoice.DiscountPercentage, oInvoice.DiscountTotal, 0);

                                                decimal dDisValue = oInvoice.DiscountTotal + oInvoice.DiscountTotal1 + oInvoice.DiscountTotal2 + oInvoice.DiscountTotal3;
                                                decimal dDisPercentage = oInvoice.DiscountPercentage + oInvoice.DiscountPercentage1 + oInvoice.DiscountPercentage2 + oInvoice.DiscountPercentage3;

                                                glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasSalesReport_InvoicwWice.Adddt_sasSalesReport_InvoicwWiceRow("Sales", oInvoice.Invoice_ID,
                                                    oInvoice.InvoiceDate, "DO<" + oInvoice.DeliveryOrder_ID + ">", oInvoice.SalesNoteType_ID,
                                                    clsGenaralName.getName_SalesNoteType(oInvoice.SalesNoteType_ID), oInvoice.Customer_ID, oCustomer.CustomerName, clsGenaralName.getName_BranchCustomer(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID)), oInvoice.SubTotal, 0,
                                                    dDisPercentage, dDisValue, 0, oInvoice.NbtTotal, oInvoice.VatTotal, oInvoice.IsTaxExcludedInvoice, oInvoice.IsVatInvoice);
                                            }
                                            #endregion

                                            #region SRN
                                            foreach (tbl_sasSalesReturnedNote oSrn in tbl_sasSalesReturnedNote.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && !p.IsDeleted && !p.IsReturnable && p.SalesReturnedNoteDate.Date >= dtpFrom.Value.Date && p.SalesReturnedNoteDate.Date <= dtpTo.Value.Date))
                                            {
                                                #region Customer
                                                if (bCustomerSelected)
                                                {
                                                    if (oSrn.Customer_ID != txtCustomer.Tag.ToString())
                                                        continue;
                                                }
                                                #endregion

                                                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oSrn.Customer_ID);
                                                if (oCustomer != null)
                                                {
                                                    sSalesmanID = oCustomer.SalesRep_ID;

                                                    if (bCustomerClassSelected)
                                                    {
                                                        if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                            continue;
                                                    }
                                                    if (bCustomerTypeSelected)
                                                    {
                                                        if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                            continue;
                                                    }
                                                    if (bCustomerCategorySelected)
                                                    {
                                                        if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                            continue;
                                                    }

                                                    #region Route
                                                    if (bRouteSelected)
                                                    {
                                                        if (!chkUseCustomerMasterRoute.Checked)
                                                        {
                                                            sRouteID = oSrn.Route_ID.ToString();
                                                        }
                                                        else
                                                        {
                                                            foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oSrn.Customer_ID))
                                                            {
                                                                sRouteID = oRoute.Route_ID.ToString();
                                                                if (txtRoute.Tag.ToString() == sRouteID)
                                                                    break;
                                                            }
                                                        }

                                                        if (txtRoute.Tag.ToString() != sRouteID)
                                                            continue;
                                                    }
                                                    #endregion
                                                }

                                                #region check rales rep
                                                if (!chkUseCustomerMastorSaleRep.Checked)
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oSrn.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }

                                                if (bSelesRepSelected)
                                                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                        break;
                                                #endregion

                                                if (bSalesNoteTypeSelected)
                                                    if (txtSalesNoteType.Tag.ToString() != oSrn.SalesNoteType_ID)
                                                        continue;

                                                //Old 2017-07-10 
                                                //glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasSalesReport_InvoicwWice.Adddt_sasSalesReport_InvoicwWiceRow("Returns", oSrn.SalesReturnedNote_ID, oSrn.SalesReturnedNoteDate, "INV<" + oSrn.Invoice_ID + ">", oSrn.SalesNoteType_ID, clsGenaralName.getName_SalesNoteType(oSrn.SalesNoteType_ID), oSrn.Customer_ID, oCustomer.CustomerName, -oSrn.SubTotal, 0, oSrn.DiscountPercentage, -oSrn.DiscountTotal, 0);

                                                glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasSalesReport_InvoicwWice.Adddt_sasSalesReport_InvoicwWiceRow("Returns", oSrn.SalesReturnedNote_ID,
                                                    oSrn.SalesReturnedNoteDate, "INV<" + oSrn.Invoice_ID + ">", oSrn.SalesNoteType_ID, clsGenaralName.getName_SalesNoteType(oSrn.SalesNoteType_ID),
                                                    oSrn.Customer_ID, oCustomer.CustomerName, clsGenaralName.getName_BranchCustomer(oSrn.Customer_ID, int.Parse(oSrn.Branch_ID)), -oSrn.SubTotal, 0, oSrn.DiscountPercentage, -oSrn.DiscountTotal, 0, oSrn.NbtTotal, oSrn.VatTotal, false,
                                                    oSrn.VatTotal != 0 ? true : false);
                                            }
                                            #endregion

                                            #region POS
                                            //2018-01-04 Gayan
                                            if (bIsPOS_Active)
                                            {
                                                //DB Table don't have any foreign keys. 
                                                //Therefore, Select Methods through foreign keys were not generated.
                                                //To do, Need to set foreign keys in DB Table and Generate CS file, then set relavant method to here.
                                                //foreach (tbl_posTransaction oPOS in tbl_posTransaction.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p =>
                                                //    !p.IsHold &&
                                                //    !p.IsDeleted &&
                                                //    p.PosTransactiondate.Date >= dtpFrom.Value.Date &&
                                                //    p.PosTransactiondate.Date <= dtpTo.Value.Date))
                                                //{
                                                //    #region Customer
                                                //    if (bCustomerSelected)
                                                //    {
                                                //        if (oPOS.Customer_ID != txtCustomer.Tag.ToString())
                                                //            continue;
                                                //    }
                                                //    #endregion

                                                //    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oPOS.Customer_ID);
                                                //    if (oCustomer != null)
                                                //    {
                                                //        sSalesmanID = oCustomer.SalesRep_ID;

                                                //        if (bCustomerClassSelected)
                                                //        {
                                                //            if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                //                continue;
                                                //        }
                                                //        if (bCustomerTypeSelected)
                                                //        {
                                                //            if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                //                continue;
                                                //        }
                                                //        if (bCustomerCategorySelected)
                                                //        {
                                                //            if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                //                continue;
                                                //        }

                                                //        #region Route
                                                //        if (bRouteSelected)
                                                //            continue;

                                                //        #endregion
                                                //    }

                                                //    #region Sales Rep Filter
                                                //    if (!chkUseCustomerMastorSaleRep.Checked)
                                                //    {
                                                //        tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oPOS.OrderRefNo_ID);
                                                //        if (oRef != null && oRef.OrderRefNo != "default")
                                                //            sSalesmanID = oRef.Employee_ID;
                                                //    }

                                                //    if (bSelesRepSelected)
                                                //        if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                //            continue;
                                                //    #endregion

                                                //    #region Note Type Filter
                                                //    if (bSalesNoteTypeSelected)
                                                //        if (txtSalesNoteType.Tag.ToString() != oPOS.SalesNoteType_ID)
                                                //            continue;
                                                //    #endregion

                                                //    decimal dSubTotal = 0, dWithNbtAmount = 0, dNbtAmount = 0, dVatAmount = 0;
                                                //    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oPOS.GrandTotal, oPOS.VatPercentage, oPOS.NbtPercentage, ref dWithNbtAmount, ref dSubTotal, ref dNbtAmount, ref dVatAmount);
                                                //    decimal dDiscount = oPOS.DiscountTotal; //+ oPOS.DiscountTotal1 + oPOS.DiscountTotal2 + oPOS.DiscountTotal3;

                                                //    glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasSalesReport_InvoicwWice
                                                //        .Adddt_sasSalesReport_InvoicwWiceRow(
                                                //            "POS", oPOS.PosTransaction_ID, oPOS.PosTransactiondate, "",
                                                //            oPOS.SalesNoteType_ID,
                                                //            clsGenaralName.getName_SalesNoteType(oPOS.SalesNoteType_ID),
                                                //            oPOS.Customer_ID,
                                                //            (oCustomer.Customer_ID != "default" ? oCustomer.CustomerName : "-"), "default",
                                                //            oPOS.GrandTotal, (dSubTotal + dDiscount), 0, dDiscount, dSubTotal,
                                                //            0, 0, false, false);
                                                //}

                                            }
                                            #endregion

                                            glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Sales Report (Invoice Wise)", "", sDateRange, clsSecurity.UserNameLoged, sFilter);
                                            print(sReportPath, "", glb_dts_sasSales_NoteTypeWise_ItemCategoryWise, sFilter, clsAutocode.getReportID(Report));
                                        }
                                        #endregion

                                        #region New Report
                                        else
                                        {
                                            Cursor = Cursors.WaitCursor;

                                            glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.Clear();
                                            glb_dtsReportExport.Clear();

                                            string sSalesmanID = "", sRouteID = "";

                                            #region inv
                                            List<tbl_sasInvoice> oInv = tbl_sasInvoice.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => !p.IsDeleted && !p.IsDebitNote && !p.IsReturnedCheque && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date).ToList();
                                            foreach (tbl_sasInvoice oInvoice in oInv)
                                            {
                                                #region Customer
                                                if (bCustomerSelected)
                                                {
                                                    if (oInvoice.Customer_ID != txtCustomer.Tag.ToString())
                                                        continue;
                                                }
                                                #endregion

                                                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                                if (oCustomer != null)
                                                {
                                                    sSalesmanID = oCustomer.SalesRep_ID;

                                                    if (bCustomerClassSelected)
                                                    {
                                                        if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                            continue;
                                                    }
                                                    if (bCustomerTypeSelected)
                                                    {
                                                        if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                            continue;
                                                    }
                                                    if (bCustomerCategorySelected)
                                                    {
                                                        if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                            continue;
                                                    }

                                                    #region Route
                                                    if (bRouteSelected)
                                                    {
                                                        if (!chkUseCustomerMasterRoute.Checked)
                                                        {
                                                            sRouteID = oInvoice.Route_ID.ToString();
                                                        }
                                                        else
                                                        {
                                                            foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oInvoice.Customer_ID))
                                                            {
                                                                sRouteID = oRoute.Route_ID.ToString();
                                                                if (txtRoute.Tag.ToString() == sRouteID)
                                                                    break;
                                                            }
                                                        }

                                                        if (txtRoute.Tag.ToString() != sRouteID)
                                                            continue;
                                                    }
                                                    #endregion
                                                }

                                                #region Sales Rep Filter
                                                if (!chkUseCustomerMastorSaleRep.Checked)
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }

                                                if (bSelesRepSelected)
                                                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                        continue;
                                                #endregion

                                                #region Note Type Filter
                                                if (bSalesNoteTypeSelected)
                                                    if (txtSalesNoteType.Tag.ToString() != oInvoice.SalesNoteType_ID)
                                                        continue;
                                                #endregion

                                                decimal bVatPrecentage = oInvoice.VatPercentage, bSVatPrecentage = oInvoice.OtherTaxPercentage, bNbtPrecentage = oInvoice.NbtPercentage;
                                                if (oInvoice.IsVatInvoice && !oInvoice.IsSVatInvoice)
                                                {
                                                    bSVatPrecentage = 0;
                                                }
                                                else if (!oInvoice.IsVatInvoice && oInvoice.IsSVatInvoice)
                                                {
                                                    bVatPrecentage = 0;
                                                }
                                                else
                                                {
                                                    bVatPrecentage = 0;
                                                    bSVatPrecentage = 0;
                                                    bNbtPrecentage = 0;
                                                }

                                                decimal dSubTotal = 0, dWithNbtAmount = 0, dNbtAmount = 0, dVatAmount = 0, dSVatAmount = 0;
                                                decimal dDiscount = oInvoice.DiscountTotal + oInvoice.DiscountTotal1 + oInvoice.DiscountTotal2 + oInvoice.DiscountTotal3;
                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvoice.GrandTotal, bVatPrecentage, bNbtPrecentage, ref dWithNbtAmount, ref dSubTotal, ref dNbtAmount, ref dVatAmount);
                                                //clsHelpMethods.CalculateGrandTotalReverce(oInvoice.GrandTotal, ref dVatAmount, oInvoice.VatPercentage, bVatInv,
                                                //    ref dSVatAmount, oInvoice.OtherTaxPercentage, bSVatInv,
                                                //    ref dNbtAmount, oInvoice.NbtPercentage, bNbtInv,
                                                //    ref dDiscount, oInvoice.DiscountPercentage, ref dSubTotal);

                                                glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasSalesReport_InvoicwWice.Adddt_sasSalesReport_InvoicwWiceRow("Sales", oInvoice.Invoice_ID, oInvoice.InvoiceDate,
                                                    "DO<" + oInvoice.DeliveryOrder_ID + ">", oInvoice.SalesNoteType_ID, clsGenaralName.getName_SalesNoteType(oInvoice.SalesNoteType_ID),
                                                    oInvoice.Customer_ID, oCustomer.CustomerName, clsGenaralName.getName_BranchCustomer(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID)), oInvoice.GrandTotal, (dSubTotal + dDiscount), 0, dDiscount, dSubTotal, 0, 0, false, false);

                                            }
                                            #endregion

                                            #region SRN
                                            foreach (tbl_sasSalesReturnedNote oSrn in tbl_sasSalesReturnedNote.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && !p.IsDeleted && !p.IsReturnable && p.SalesReturnedNoteDate.Date >= dtpFrom.Value.Date && p.SalesReturnedNoteDate.Date <= dtpTo.Value.Date))
                                            {
                                                #region Customer
                                                if (bCustomerSelected)
                                                {
                                                    if (oSrn.Customer_ID != txtCustomer.Tag.ToString())
                                                        continue;
                                                }
                                                #endregion

                                                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oSrn.Customer_ID);
                                                if (oCustomer != null)
                                                {
                                                    sSalesmanID = oCustomer.SalesRep_ID;

                                                    if (bCustomerClassSelected)
                                                    {
                                                        if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                            continue;
                                                    }
                                                    if (bCustomerTypeSelected)
                                                    {
                                                        if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                            continue;
                                                    }
                                                    if (bCustomerCategorySelected)
                                                    {
                                                        if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                            continue;
                                                    }

                                                    #region Route
                                                    if (bRouteSelected)
                                                    {
                                                        if (!chkUseCustomerMasterRoute.Checked)
                                                        {
                                                            sRouteID = oSrn.Route_ID.ToString();
                                                        }
                                                        else
                                                        {
                                                            foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oSrn.Customer_ID))
                                                            {
                                                                sRouteID = oRoute.Route_ID.ToString();
                                                                if (txtRoute.Tag.ToString() == sRouteID)
                                                                    break;
                                                            }
                                                        }

                                                        if (txtRoute.Tag.ToString() != sRouteID)
                                                            continue;
                                                    }
                                                    #endregion
                                                }

                                                #region Sales Rep Filter
                                                if (!chkUseCustomerMastorSaleRep.Checked)
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oSrn.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }

                                                if (bSelesRepSelected)
                                                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                        continue;
                                                #endregion

                                                #region Note Type Filter
                                                if (bSalesNoteTypeSelected)
                                                    if (txtSalesNoteType.Tag.ToString() != oSrn.SalesNoteType_ID)
                                                        continue;
                                                #endregion

                                                decimal bVatPrecentage = oSrn.VatPercentage, bSVatPrecentage = oSrn.OtherTaxPercentage, bNbtPrecentage = oSrn.NbtPercentage;
                                                if (oSrn.VatTotal > 0 && oSrn.NbtTotal > 0)
                                                {
                                                    bSVatPrecentage = 0;
                                                }
                                                else if (oSrn.OtherTaxTotal > 0 && oSrn.NbtTotal > 0)
                                                {
                                                    bVatPrecentage = 0;
                                                }
                                                else
                                                {
                                                    bVatPrecentage = 0;
                                                    bSVatPrecentage = 0;
                                                    bNbtPrecentage = 0;
                                                }

                                                decimal dSubTotal = 0, dWithNbtAmount = 0, dNbtAmount = 0, dVatAmount = 0, dSVatAmount = 0, dDiscount = 0;
                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oSrn.GrandTotal, bVatPrecentage, bNbtPrecentage, ref dWithNbtAmount, ref dSubTotal, ref dNbtAmount, ref dVatAmount);
                                                //  decimal dMultiplicationRate = dSubTotal / oSrn.SubTotal;

                                                glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasSalesReport_InvoicwWice.Adddt_sasSalesReport_InvoicwWiceRow("Returns", oSrn.SalesReturnedNote_ID,
                                                    oSrn.SalesReturnedNoteDate, "INV<" + oSrn.Invoice_ID + ">", oSrn.SalesNoteType_ID, clsGenaralName.getName_SalesNoteType(oSrn.SalesNoteType_ID),
                                                    oSrn.Customer_ID, oCustomer.CustomerName, clsGenaralName.getName_BranchCustomer(oSrn.Customer_ID, int.Parse(oSrn.Branch_ID)), -oSrn.GrandTotal, -(dSubTotal + oSrn.DiscountTotal), oSrn.DiscountPercentage, -oSrn.DiscountTotal, -dSubTotal,
                                                    0, 0, false, false);
                                            }
                                            #endregion

                                            #region POS
                                            //2018-01-04 Gayan
                                            if (bIsPOS_Active)
                                            {
                                                //DB Table don't have any foreign keys. 
                                                //Therefore, Select Methods through foreign keys were not generated.
                                                //To do, Need to set foreign keys in DB Table and Generate CS file, then set relavant method to here.
                                                //foreach (tbl_posTransaction oPOS in tbl_posTransaction.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString())
                                                //    .Where(p => !p.IsHold && !p.IsDeleted &&
                                                //                p.PosTransactiondate.Date >= dtpFrom.Value.Date &&
                                                //                p.PosTransactiondate.Date <= dtpTo.Value.Date))
                                                //{
                                                //    #region Customer
                                                //    if (bCustomerSelected)
                                                //    {
                                                //        if (oPOS.Customer_ID != txtCustomer.Tag.ToString())
                                                //            continue;
                                                //    }
                                                //    #endregion

                                                //    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oPOS.Customer_ID);
                                                //    if (oCustomer != null)
                                                //    {
                                                //        sSalesmanID = oCustomer.SalesRep_ID;

                                                //        if (bCustomerClassSelected)
                                                //        {
                                                //            if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                //                continue;
                                                //        }
                                                //        if (bCustomerTypeSelected)
                                                //        {
                                                //            if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                //                continue;
                                                //        }
                                                //        if (bCustomerCategorySelected)
                                                //        {
                                                //            if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                //                continue;
                                                //        }

                                                //        #region Route
                                                //        if (bRouteSelected)
                                                //            continue;
                                                //        #endregion
                                                //    }

                                                //    #region Sales Rep Filter
                                                //    if (!chkUseCustomerMastorSaleRep.Checked)
                                                //    {
                                                //        tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oPOS.OrderRefNo_ID);
                                                //        if (oRef != null && oRef.OrderRefNo != "default")
                                                //            sSalesmanID = oRef.Employee_ID;
                                                //    }

                                                //    if (bSelesRepSelected)
                                                //        if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                //            continue;

                                                //    #endregion

                                                //    #region Note Type Filter
                                                //    if (bSalesNoteTypeSelected)
                                                //        if (txtSalesNoteType.Tag.ToString() != oPOS.SalesNoteType_ID)
                                                //            continue;
                                                //    #endregion

                                                //    decimal bVatPrecentage = oPOS.VatPercentage, bSVatPrecentage = oPOS.OtherTaxPercentage, bNbtPrecentage = oPOS.NbtPercentage;
                                                //    if (oPOS.VatTotal > 0 && oPOS.NbtTotal > 0)
                                                //    {
                                                //        bSVatPrecentage = 0;
                                                //    }
                                                //    else if (oPOS.OtherTaxTotal > 0 && oPOS.NbtTotal > 0)
                                                //    {
                                                //        bVatPrecentage = 0;
                                                //    }
                                                //    else
                                                //    {
                                                //        bVatPrecentage = 0;
                                                //        bSVatPrecentage = 0;
                                                //        bNbtPrecentage = 0;
                                                //    }

                                                //    decimal dSubTotal = 0, dWithNbtAmount = 0, dNbtAmount = 0, dVatAmount = 0, dSVatAmount = 0;
                                                //    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oPOS.GrandTotal, oPOS.VatPercentage, oPOS.NbtPercentage, ref dWithNbtAmount, ref dSubTotal, ref dNbtAmount, ref dVatAmount);
                                                //    decimal dDiscount = oPOS.DiscountTotal; //+ oPOS.DiscountTotal1 + oPOS.DiscountTotal2 + oPOS.DiscountTotal3;

                                                //    glb_dts_sasSales_NoteTypeWise_ItemCategoryWise
                                                //        .dt_sasSalesReport_InvoicwWice.Adddt_sasSalesReport_InvoicwWiceRow(
                                                //            "POS", oPOS.PosTransaction_ID, oPOS.PosTransactiondate, "",
                                                //            oPOS.SalesNoteType_ID,
                                                //            clsGenaralName.getName_SalesNoteType(oPOS.SalesNoteType_ID),
                                                //            oPOS.Customer_ID, (oCustomer.Customer_ID != "default" ? oCustomer.CustomerName : "-"), "default",
                                                //            oPOS.GrandTotal, (dSubTotal + dDiscount), 0, dDiscount,
                                                //            dSubTotal, 0, 0, false, false);
                                                //}
                                            }

                                            #endregion

                                            glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Sales Report (Invoice Wise)", "", sDateRange, clsSecurity.UserNameLoged, sFilter);
                                            print(sReportPath, "", glb_dts_sasSales_NoteTypeWise_ItemCategoryWise, sFilter, clsAutocode.getReportID(Report));
                                        }
                                        #endregion
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.Clear();
                                        glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.Clear();
                                    }
                                }
                                #endregion

                                #region Sales report Profitability Report
                                else if (Report == enum_ReportName.ST_SalesProfitability)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;

                                        glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.Clear();
                                        glb_dtsReportExport.Clear();

                                        List<tbl_sasInvoice> oInvoices = tbl_sasInvoice.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => !p.IsDeleted && !p.IsOpeningBalance && !p.IsReturnedCheque && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date).ToList();
                                        List<tbl_sasSalesReturnedNote> oSrns = tbl_sasSalesReturnedNote.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && !p.IsDeleted && !p.IsReturnable && p.SalesReturnedNoteDate.Date >= dtpFrom.Value.Date && p.SalesReturnedNoteDate.Date <= dtpTo.Value.Date).ToList();

                                        string sSalesmanID = "", sSalesmanName = "", sRouteID = "";

                                        #region inv
                                        foreach (tbl_sasInvoice oInvoice in oInvoices)
                                        {
                                            #region Customer
                                            if (bCustomerSelected)
                                            {
                                                if (oInvoice.Customer_ID != txtCustomer.Tag.ToString())
                                                    continue;
                                            }
                                            #endregion

                                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                            if (oCustomer != null)
                                            {
                                                if (bCustomerClassSelected)
                                                {
                                                    if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }

                                                #region Sales Rep Filter
                                                if (!chkUseCustomerMastorSaleRep.Checked)
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }
                                                else
                                                    sSalesmanID = oCustomer.SalesRep_ID;

                                                if (bSelesRepSelected)
                                                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                        continue;

                                                sSalesmanName = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID);
                                                #endregion

                                                #region Route
                                                if (bRouteSelected)
                                                {
                                                    if (!chkUseCustomerMasterRoute.Checked)
                                                    {
                                                        sRouteID = oInvoice.Route_ID.ToString();
                                                    }
                                                    else
                                                    {
                                                        foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oInvoice.Customer_ID))
                                                        {
                                                            sRouteID = oRoute.Route_ID.ToString();
                                                            if (txtRoute.Tag.ToString() == sRouteID)
                                                                break;
                                                        }
                                                    }

                                                    if (txtRoute.Tag.ToString() != sRouteID)
                                                        continue;
                                                }
                                                #endregion
                                            }

                                            #region Sales note Filter
                                            if (bSalesNoteTypeSelected)
                                                if (txtSalesNoteType.Tag.ToString() != oInvoice.SalesNoteType_ID)
                                                    continue;
                                            #endregion

                                            decimal dSubTotal = 0, dWithNbtAmount = 0, dNbtAmount = 0, dVatAmount = 0;// dDiscountTotal = 0;

                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvoice.GrandTotal, oInvoice.VatPercentage, oInvoice.NbtPercentage, ref dWithNbtAmount, ref dSubTotal, ref dNbtAmount, ref dVatAmount);
                                            // dDiscountTotal = oInvoice.DiscountTotal + oInvoice.DiscountTotal1 + oInvoice.DiscountTotal2 + oInvoice.DiscountTotal3;
                                            decimal dSubTotal_AfterDisc = (oInvoice.SubTotal - (oInvoice.DiscountTotal + oInvoice.DiscountTotal1 + oInvoice.DiscountTotal2 + oInvoice.DiscountTotal3));


                                            // decimal dOtherDiscuntPresentage =(oInvoice.SubTotal - dSubTotal_AfterDisc )/ oInvoice.SubTotal;
                                            decimal dOtherDiscuntPresentage = 0;
                                            if (oInvoice.SubTotal != 0)
                                                dOtherDiscuntPresentage = (oInvoice.SubTotal - dSubTotal_AfterDisc) / oInvoice.SubTotal;

                                            foreach (tbl_sasInvoice_Detail oDetail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID))
                                            {
                                                decimal dAmount_BeforeLineDisc = 0, dAmount_OtherDisc = 0, dDiscountTotal = 0, dAmount_AfterDisc = 0, dItemTotal_Ratio = 0, dNbt = 0, dVat = 0, dNsp = 0;

                                                dAmount_BeforeLineDisc = oDetail.UnitPrice * oDetail.Qty;
                                                dAmount_OtherDisc = oDetail.TatalAmount * dOtherDiscuntPresentage;
                                                dDiscountTotal = oDetail.DiscountAmount + dAmount_OtherDisc;
                                                dAmount_AfterDisc = oDetail.TatalAmount - dAmount_OtherDisc;

                                                if (dSubTotal_AfterDisc != 0)
                                                    dItemTotal_Ratio = dAmount_AfterDisc / dSubTotal_AfterDisc;

                                                if (dItemTotal_Ratio != 0)
                                                {
                                                    dVat = dVatAmount * dItemTotal_Ratio;
                                                    dNbt = dNbtAmount * dItemTotal_Ratio;
                                                    dNsp = dSubTotal * dItemTotal_Ratio;
                                                }

                                                tbl_genItemMaster oItem = tbl_genItemMaster.Select(oDetail.Item_ID);
                                                if (oItem != null && oItem.Item_ID != "default")
                                                {
                                                    #region item Filters
                                                    #region Item Class
                                                    if (bItemClassSelected)
                                                    {
                                                        if (oItem.ItemClass_ID != txtItemClass.Tag.ToString())
                                                            continue;
                                                    }
                                                    #endregion

                                                    #region Item Type
                                                    if (bItemTypeSelected)
                                                    {
                                                        if (oItem.ItemType_ID != TxtItemType.Tag.ToString())
                                                            continue;
                                                    }
                                                    #endregion

                                                    #region Item Catagory
                                                    if (bItemcatagorySelected)
                                                    {
                                                        if (oItem.ItemCategory_ID != TxtItemCat.Tag.ToString())
                                                            continue;
                                                    }
                                                    #endregion

                                                    #region ItemFilter
                                                    if (bItemSelected)
                                                    {
                                                        if (oDetail.Item_ID != txtItemID.Tag.ToString())
                                                            continue;
                                                    }
                                                    #endregion
                                                    #endregion
                                                    #region Item Cost Type
                                                    enum_CostPriceType eCostType = enum_CostPriceType.CostPrice2;
                                                    if (cmbCostPrice.SelectedIndex == 0)
                                                        eCostType = enum_CostPriceType.WeightedAverage;
                                                    if (cmbCostPrice.SelectedIndex == 1)
                                                        eCostType = enum_CostPriceType.LIFO;
                                                    if (cmbCostPrice.SelectedIndex == 2)
                                                        eCostType = enum_CostPriceType.FIFO;
                                                    if (cmbCostPrice.SelectedIndex == 3)
                                                        eCostType = enum_CostPriceType.HighestPurchaseCost;
                                                    if (cmbCostPrice.SelectedIndex == 4)
                                                        eCostType = enum_CostPriceType.LovestPurchaseCost;
                                                    if (cmbCostPrice.SelectedIndex == 5)
                                                        eCostType = enum_CostPriceType.CostPrice1;
                                                    if (cmbCostPrice.SelectedIndex == 6)
                                                        eCostType = enum_CostPriceType.CostPrice2;
                                                    #endregion

                                                    decimal dCostPriceValue = clsProcessMethods.GetCostPrice_ByCostType(oItem.Item_ID, eCostType);

                                                    glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasProfitabilityReport.Adddt_sasProfitabilityReportRow("INV", oInvoice.Invoice_ID, oInvoice.InvoiceDate, oInvoice.SalesNoteType_ID, "", oInvoice.Customer_ID, oCustomer.CustomerName, sSalesmanID, sSalesmanName, oDetail.Item_ID, oItem.ItemName, oItem.ItemCategory_ID, "", "", "", oDetail.BIsFreeItem, oDetail.Qty, oDetail.UnitPrice, dAmount_BeforeLineDisc, oDetail.DiscountAmount, dAmount_OtherDisc, dDiscountTotal, dAmount_AfterDisc, dVat, dNbt, dNsp, dCostPriceValue);
                                                }
                                            }

                                        }

                                        #endregion

                                        #region SRN
                                        foreach (tbl_sasSalesReturnedNote oSrn in oSrns)
                                        {
                                            #region Customer
                                            if (bCustomerSelected)
                                            {
                                                if (oSrn.Customer_ID != txtCustomer.Tag.ToString())
                                                    continue;
                                            }
                                            #endregion

                                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oSrn.Customer_ID);
                                            if (oCustomer != null)
                                            {
                                                if (bCustomerClassSelected)
                                                {
                                                    if (oCustomer.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (oCustomer.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (oCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }

                                                #region Sales Rep Filter
                                                if (!chkUseCustomerMastorSaleRep.Checked)
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oSrn.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }
                                                else
                                                    sSalesmanID = oCustomer.SalesRep_ID;

                                                if (bSelesRepSelected)
                                                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                        continue;

                                                sSalesmanName = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID);
                                                #endregion
                                            }

                                            #region Sales Note Filter
                                            if (bSalesNoteTypeSelected)
                                                if (txtSalesNoteType.Tag.ToString() != oSrn.SalesNoteType_ID)
                                                    continue;
                                            #endregion

                                            decimal dSubTotal = 0, dWithNbtAmount = 0, dNbtAmount = 0, dVatAmount = 0;

                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oSrn.GrandTotal, oSrn.VatPercentage, oSrn.NbtPercentage, ref dWithNbtAmount, ref dSubTotal, ref dNbtAmount, ref dVatAmount);


                                            decimal dSubTotal_AfterDisc = (oSrn.SubTotal - oSrn.DiscountTotal);
                                            decimal dOtherDiscuntPresentage = 0;
                                            if (oSrn.SubTotal != 0)
                                                dOtherDiscuntPresentage = (oSrn.SubTotal - dSubTotal_AfterDisc) / oSrn.SubTotal;

                                            foreach (tbl_sasSalesReturnedNote_Detail oDetail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSrn.SalesReturnedNote_ID))
                                            {
                                                decimal dAmount_BeforeLineDisc = 0, dAmount_OtherDisc = 0, dDiscountTotal = 0, dAmount_AfterDisc = 0, dItemTotal_Ratio = 0, dNbt = 0, dVat = 0, dNsp = 0;

                                                dAmount_BeforeLineDisc = oDetail.UnitPrice * oDetail.Qty;
                                                dAmount_OtherDisc = oDetail.TatalAmount * dOtherDiscuntPresentage;
                                                dDiscountTotal = oDetail.DiscountAmount + dAmount_OtherDisc;
                                                dAmount_AfterDisc = oDetail.TatalAmount - dAmount_OtherDisc;

                                                if (dSubTotal_AfterDisc != 0)
                                                    dItemTotal_Ratio = dAmount_AfterDisc / dSubTotal_AfterDisc;

                                                if (dItemTotal_Ratio != 0)
                                                {
                                                    dVat = dVatAmount * dItemTotal_Ratio;
                                                    dNbt = dNbtAmount * dItemTotal_Ratio;
                                                    dNsp = dSubTotal * dItemTotal_Ratio;
                                                }

                                                tbl_genItemMaster oItem = tbl_genItemMaster.Select(oDetail.Item_ID);
                                                if (oItem != null && oItem.Item_ID != "default")
                                                {
                                                    #region item Filters
                                                    #region Item Class
                                                    if (bItemClassSelected)
                                                    {
                                                        if (oItem.ItemClass_ID != txtItemClass.Tag.ToString())
                                                            continue;
                                                    }
                                                    #endregion

                                                    #region Item Type
                                                    if (bItemTypeSelected)
                                                    {
                                                        if (oItem.ItemType_ID != TxtItemType.Tag.ToString())
                                                            continue;
                                                    }
                                                    #endregion

                                                    #region Item Catagory
                                                    if (bItemcatagorySelected)
                                                    {
                                                        if (oItem.ItemCategory_ID != TxtItemCat.Tag.ToString())
                                                            continue;
                                                    }
                                                    #endregion

                                                    #region ItemFilter
                                                    if (bItemSelected)
                                                    {
                                                        if (oItem.Item_ID != txtItemID.Tag.ToString())
                                                            continue;
                                                    }
                                                    #endregion
                                                    #endregion
                                                    #region Item Cost Type
                                                    enum_CostPriceType eCostType = enum_CostPriceType.CostPrice2;
                                                    if (cmbCostPrice.SelectedIndex == 0)
                                                        eCostType = enum_CostPriceType.WeightedAverage;
                                                    if (cmbCostPrice.SelectedIndex == 1)
                                                        eCostType = enum_CostPriceType.LIFO;
                                                    if (cmbCostPrice.SelectedIndex == 2)
                                                        eCostType = enum_CostPriceType.FIFO;
                                                    if (cmbCostPrice.SelectedIndex == 3)
                                                        eCostType = enum_CostPriceType.HighestPurchaseCost;
                                                    if (cmbCostPrice.SelectedIndex == 4)
                                                        eCostType = enum_CostPriceType.LovestPurchaseCost;
                                                    if (cmbCostPrice.SelectedIndex == 5)
                                                        eCostType = enum_CostPriceType.CostPrice1;
                                                    if (cmbCostPrice.SelectedIndex == 6)
                                                        eCostType = enum_CostPriceType.CostPrice2;
                                                    #endregion

                                                    decimal dCostPriceValue = clsProcessMethods.GetCostPrice_ByCostType(oItem.Item_ID,  eCostType);

                                                    glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasProfitabilityReport.Adddt_sasProfitabilityReportRow("SRN", oSrn.SalesReturnedNote_ID, oSrn.SalesReturnedNoteDate, oSrn.SalesNoteType_ID, "", oSrn.Customer_ID, oCustomer.CustomerName, sSalesmanID, sSalesmanName, oDetail.Item_ID, oItem.ItemName, oItem.ItemCategory_ID, "", "", "", oDetail.BIsFreeItem, -oDetail.Qty, oDetail.UnitPrice, -dAmount_BeforeLineDisc, -oDetail.DiscountAmount, -dAmount_OtherDisc, -dDiscountTotal, -dAmount_AfterDisc, -dVat, -dNbt, -dNsp, dCostPriceValue);

                                                }
                                            }
                                        }
                                        #endregion

                                        glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Profitability Report", "", sDateRange, clsSecurity.UserNameLoged, sFilter);
                                        print(sReportPath, "", glb_dts_sasSales_NoteTypeWise_ItemCategoryWise, sFilter, clsAutocode.getReportID(Report));

                                        //string sSalesmanID = "", sSalesmanName = "";

                                        //List<tbl_sasInvoice> oInvoices = tbl_sasInvoice.SelectAll().Where(p => !p.IsDeleted && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date).ToList();
                                        #region inv
                                        //foreach (tbl_sasInvoice oInvoice in oInvoices)
                                        //{
                                        //    #region Sales Rep Filter
                                        //    //if (!chkUseCustomerMastorSaleRep.Checked)
                                        //    //{
                                        //        tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                        //        if (oRef != null && oRef.OrderRefNo != "default")
                                        //            sSalesmanID = oRef.Employee_ID;
                                        //    //}
                                        //    //else
                                        //    //    sSalesmanID = oCustomer.SalesRep_ID;

                                        //    if (bSelesRepSelected)
                                        //        if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                        //            continue;

                                        //    sSalesmanName = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID);
                                        //    #endregion

                                        //    #region Sales note Filter
                                        //    if (bSalesNoteTypeSelected)
                                        //        if (txtSalesNoteType.Tag.ToString() != oInvoice.SalesNoteType_ID)
                                        //            continue;
                                        //    #endregion

                                        //    decimal dSubTotal = 0, dWithNbtAmount = 0, dNbtAmount = 0, dVatAmount = 0;
                                        //    decimal dMultiplicationRate = 0;

                                        //    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvoice.GrandTotal, oInvoice.VatPercentage, oInvoice.NbtPercentage, ref dWithNbtAmount, ref dSubTotal, ref dNbtAmount, ref dVatAmount);

                                        //    if (oInvoice.SubTotal > 0)
                                        //        dMultiplicationRate = dSubTotal / oInvoice.SubTotal;

                                        //    foreach (tbl_sasInvoice_Detail oDetail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID))
                                        //    {
                                        //        tbl_genItemMaster oItem = tbl_genItemMaster.Select(oDetail.Item_ID);
                                        //        if (oItem != null && oItem.Item_ID != "default")
                                        //        {
                                        //            #region item Filters
                                        //            #region Item Class
                                        //            if (bItemClassSelected)
                                        //            {
                                        //                if (oItem.ItemClass_ID != txtItemClass.Tag.ToString())
                                        //                    continue;
                                        //            }
                                        //            #endregion

                                        //            #region Item Type
                                        //            if (bItemTypeSelected)
                                        //            {
                                        //                if (oItem.ItemType_ID != TxtItemType.Tag.ToString())
                                        //                    continue;
                                        //            }
                                        //            #endregion

                                        //            #region Item Catagory
                                        //            if (bItemcatagorySelected)
                                        //            {
                                        //                if (oItem.ItemCategory_ID != TxtItemCat.Tag.ToString())
                                        //                    continue;
                                        //            }
                                        //            #endregion

                                        //            #region ItemFilter
                                        //            if (bItemSelected)
                                        //            {
                                        //                if (oDetail.Item_ID != txtItemID.Tag.ToString())
                                        //                    continue;
                                        //            }
                                        //            #endregion
                                        //            #endregion
                                        //        }
                                        //        decimal dDiscount = oInvoice.DiscountTotal + oInvoice.DiscountTotal1 + oInvoice.DiscountTotal2 + oInvoice.DiscountTotal3;
                                        //        //glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasSalesReport_InvoicwWice.Adddt_sasSalesReport_InvoicwWiceRow("Sales", oInvoice.Invoice_ID, oInvoice.InvoiceDate, "DO<" + oInvoice.DeliveryOrder_ID + ">", oInvoice.SalesNoteType_ID, clsGenaralName.getName_SalesNoteType(oInvoice.SalesNoteType_ID), oInvoice.Customer_ID, "", oInvoice.GrandTotal, (dSubTotal + dDiscount), 0, dDiscount, dSubTotal);

                                        //        string sItemPriceCategory = ((ComboBoxItem)cmbPriceCategory.SelectedItem).Value;
                                        //        decimal dSalesValue = clsProcessMethods.GetRecommendedUnitPrice_Basic(oDetail.Item_ID, sItemPriceCategory);
                                        //        //tbl_genItemMaster_Pricing oItemFin = tbl_genItemMaster_Pricing.Select(oDetail.Item_ID, oDetail.ItemSubCategory_ID, oDetail.ItemSubCategory2_ID, oDetail.ItemSerialNo, oDetail.ItemSerialNo2);

                                        //        decimal dCostPerPiece = 0;
                                        //        int iIndex = cmbCostPrice.SelectedIndex;

                                        //        if(iIndex == 0)
                                        //            dCostPerPiece = oItem.CostPrice;
                                        //        else if(iIndex == 1)
                                        //            dCostPerPiece = clsProcessMethods.GetItemWeightedAvarageCostPrice(oDetail.Item_ID, oDetail.ItemSubCategory_ID, oDetail.ItemSubCategory2_ID, oDetail.ItemSerialNo, oDetail.ItemSerialNo2);
                                        //        else if (iIndex == 2)
                                        //            dCostPerPiece = clsProcessMethods.GetHighestPurchaseCostPrice(oDetail.Item_ID, dSalesValue);
                                        //        else if (iIndex == 3)
                                        //            dCostPerPiece = clsProcessMethods.GetLovesetPurchaseCostPrice(oDetail.Item_ID, dSalesValue);                                                                     


                                        //        glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_sasSalesReport.Adddt_sasSalesReportRow("INV", oInvoice.Invoice_ID, oInvoice.InvoiceDate, oInvoice.SalesNoteType_ID, clsGenaralName.getName_SalesNoteType(oInvoice.SalesNoteType_ID), oInvoice.Customer_ID, "", sSalesmanID, sSalesmanName, oDetail.Item_ID, oItem.ItemName, clsGenaralName.getName_Tag1(oItem.Tag1_ID), clsGenaralName.getName_Tag2(oItem.Tag2_ID), oItem.ItemCategory_ID, oDetail.Qty, oDetail.TatalAmount * dMultiplicationRate, 0, 0, clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID), dDiscount, oDetail.BIsFreeItem, dVatAmount, dNbtAmount, oDetail.UnitPrice, dCostPerPiece);
                                        //    }


                                        //}

                                        #endregion

                                        ////}

                                        //glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Profitability Report", "", sDateRange, clsSecurity.UserNameLoged, sFilter);
                                        //print(sReportPath, "", glb_dts_sasSales_NoteTypeWise_ItemCategoryWise, sFilter);

                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.Clear();
                                    }
                                }
                                #endregion

                                #region Sales Register Details - Report
                                else if (Report == enum_ReportName.ST_Sales_Register_Details)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.Clear();
                                        glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.Clear();

                                        string sRouteID = "", sSalesmanID = "";
                                        // string sDateRange = "From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "  To : " + dtpTo.Value.ToString("dd MMM yyyy");

                                        List<tbl_sasInvoice> Query = tbl_sasInvoice.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => !p.IsDeleted && p.Invoice_ID != "default" && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date && !p.IsReturnedCheque && !p.IsDebitNote).ToList();
                                        foreach (tbl_sasInvoice oInvoice in Query)
                                        {
                                            if (bCustomerSelected)
                                                if (oInvoice.Customer_ID != txtCustomer.Tag.ToString())
                                                    continue;

                                            tbl_genCustomerMaster CusDetail = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                            if (CusDetail != null)
                                            {
                                                if (bCustomerClassSelected)
                                                {
                                                    if (CusDetail.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerTypeSelected)
                                                {
                                                    if (CusDetail.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                if (bCustomerCategorySelected)
                                                {
                                                    if (CusDetail.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                                        continue;
                                                }

                                                #region Sales Rep
                                                if (chkUseCustomerMastorSaleRep.Checked)
                                                    sSalesmanID = CusDetail.SalesRep_ID;
                                                else
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }

                                                if (bSelesRepSelected)
                                                {
                                                    if (sSalesmanID != txtSalesRep.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                #endregion

                                                #region Route
                                                if (bRouteSelected)
                                                {
                                                    if (!chkUseCustomerMasterRoute.Checked)
                                                    {
                                                        sRouteID = oInvoice.Route_ID.ToString();
                                                    }
                                                    else
                                                    {
                                                        foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oInvoice.Customer_ID))
                                                        {
                                                            sRouteID = oRoute.Route_ID.ToString();
                                                            if (txtRoute.Tag.ToString() == sRouteID)
                                                                break;
                                                        }
                                                    }

                                                    if (txtRoute.Tag.ToString() != sRouteID)
                                                        continue;
                                                }
                                                #endregion
                                            }

                                            decimal dSRNAmount = 0, dCRNAmount = 0, dCashAmount = 0, dChequeAmount = 0, dFreeIssue = 0;
                                            //tbl_sasInvoice_Discount oDiscount = tbl_sasInvoice_Discount.Select(oInvoice.Invoice_ID);
                                            //if (oDiscount != null)
                                            //{
                                            //    dDiscount1_Amount = oDiscount.DiscountAmount1;
                                            //    dDiscount1_Percentage = oDiscount.DiscountPresentage1;
                                            //    dDiscount2_Amount = oDiscount.DiscountAmount2;
                                            //    dDiscount2_Percentage = oDiscount.DiscountPresentage2;
                                            //    dDiscount3_Amount = oDiscount.DiscountAmount3;
                                            //    dDiscount3_Percentage = oDiscount.DiscountPresentage3;
                                            //}

                                            foreach (tbl_sasSalesReturnedNote oSRN in tbl_sasSalesReturnedNote.SelectAllByInvoice_ID(oInvoice.Invoice_ID).Where(p => !p.IsDeleted && p.SalesReturnedNote_ID != "default"))
                                            {
                                                dSRNAmount = oSRN.GrandTotal;

                                            }
                                            foreach (tbl_sasInvoice_Sattled oSettle in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(oInvoice.Invoice_ID))
                                            {
                                                if (oSettle.CreditNote_ID != "default")
                                                    dCRNAmount = oSettle.SattledAmount;
                                                if (oSettle.Receipt_ID != "default")
                                                {
                                                    if (oSettle.ChequeRegister_ID != "default")
                                                        dChequeAmount += oSettle.SattledAmount;
                                                    else
                                                        dCashAmount += oSettle.SattledAmount;
                                                }
                                            }

                                            decimal dNetAmount = oInvoice.SubTotal - oInvoice.DiscountTotal1 - oInvoice.DiscountTotal2 - oInvoice.DiscountTotal3 - dCRNAmount;
                                            decimal dOutstanding = dNetAmount - dCashAmount - dChequeAmount;
                                            glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_SalesRegiterDetails.Adddt_SalesRegiterDetailsRow(oInvoice.Customer_ID, clsGenaralName.getName_Customer(oInvoice.Customer_ID), clsGenaralName.getName_BranchCustomer(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID)),
                                                oInvoice.Invoice_ID, oInvoice.InvoiceDate, clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID), oInvoice.SubTotal, oInvoice.DiscountPercentage1, oInvoice.DiscountPercentage2,
                                                oInvoice.DiscountPercentage3, oInvoice.DiscountTotal1, oInvoice.DiscountTotal2, oInvoice.DiscountTotal3, dSRNAmount, dCRNAmount, dNetAmount, dCashAmount, dChequeAmount, dOutstanding, dFreeIssue);
                                        }
                                        glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), "Sales Register Details", "", sDateRange, clsSecurity.UserNameLoged, sFilter);
                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dts_sasSales_NoteTypeWise_ItemCategoryWise, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;

                                        glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.Clear();
                                    }
                                }
                                #endregion





                                #region Sales Rep wise Item Sales Report - Indika
                                else if (Report == enum_ReportName.ST_ItemSalesReport_SalesRepWise)
                                {
                                    try
                                    {
                                        glb_dtsSales.Clear();

                                        List<tbl_sasDeliveryOrder> oDOs = tbl_sasDeliveryOrder.SelectAllByDateRange(dtpFrom.Value.Date, dtpTo.Value.Date).Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && !p.IsDeleted).ToList();
                                        List<tbl_sasSalesReturnedNote> oSRNs = tbl_sasSalesReturnedNote.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && !p.IsDeleted && p.SalesReturnedNoteDate.Date >= dtpFrom.Value.Date && p.SalesReturnedNoteDate.Date <= dtpTo.Value.Date).ToList();

                                        string sSalesmanID = "", sRouteID = "", sSalesmanName = "", sAreaManagerID = "", sAreaManager = "", sSalesManagerID = "", sSalesManager = "";
                                        List<string> sItemList = new List<string>();

                                        #region DO
                                        foreach (tbl_sasDeliveryOrder oDO in oDOs)
                                        {
                                            #region Route / Sales Rep Filter                                                                                     
                                            tbl_genCustomerMaster CusDetail = tbl_genCustomerMaster.Select(oDO.Customer_ID);
                                            if (CusDetail != null)
                                            {
                                                #region Route
                                                if (bRouteSelected)
                                                {
                                                    if (!chkUseCustomerMasterRoute.Checked)
                                                    {
                                                        sRouteID = oDO.Route_ID.ToString();
                                                    }
                                                    else
                                                    {
                                                        foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oDO.Customer_ID))
                                                        {
                                                            sRouteID = oRoute.Route_ID.ToString();
                                                            if (txtRoute.Tag.ToString() == sRouteID)
                                                                break;
                                                        }
                                                    }

                                                    if (txtRoute.Tag.ToString() != sRouteID)
                                                        continue;
                                                }
                                                #endregion

                                                #region Sales Rep
                                                if (chkUseCustomerMastorSaleRep.Checked)
                                                    sSalesmanID = CusDetail.SalesRep_ID;
                                                else
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oDO.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }

                                                if (bSelesRepSelected)
                                                {
                                                    if (sSalesmanID != txtSalesRep.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                #endregion
                                            }

                                            sSalesmanName = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID);
                                            #endregion

                                            #region Managers
                                            tbl_ZEmpSalesRep oRep = tbl_ZEmpSalesRep.Select(sSalesmanID);
                                            if (oRep != null)
                                            {
                                                sAreaManagerID = oRep.AreaManager_ID;
                                                if (bAreaManagerSelected)
                                                    if (sAreaManagerID != txtAreaManager.Tag.ToString().Trim())
                                                        continue;

                                                tbl_ZEmpAreaManager oManager = tbl_ZEmpAreaManager.Select(sAreaManagerID);
                                                if (oManager != null)
                                                {
                                                    sAreaManager = oManager.AreaManagerName;
                                                    sSalesManagerID = oManager.SalesManager_ID;
                                                    if (bSalesManagerSelected)
                                                        if (sSalesManagerID != txtSalesManager.Tag.ToString().Trim())
                                                            continue;

                                                    tbl_ZEmpSalesManager oSales = tbl_ZEmpSalesManager.Select(sSalesManagerID);
                                                    if (oSales != null)
                                                    {
                                                        sSalesManager = oSales.SalesManagerName;
                                                    }
                                                }
                                            }
                                            #endregion                                          

                                            foreach (tbl_sasDeliveryOrder_Detail oDODetail in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDO.DeliveryOrder_ID))
                                            //var DOList = tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDO.DeliveryOrder_ID).GroupBy(gb => new { gb.Item_ID }, (Key, group) => new { ItemID = Key.Item_ID, TotQty = group.Sum(p => p.Qty) });
                                            //foreach (var oDODetail in DOList)
                                            {
                                                #region item Filters
                                                tbl_genItemMaster oItem = tbl_genItemMaster.Select(oDODetail.Item_ID);
                                                if (oItem != null && oItem.Item_ID != "default")
                                                {
                                                    #region Item Class
                                                    if (bItemClassSelected)
                                                    {
                                                        if (oItem.ItemClass_ID != txtItemClass.Tag.ToString())
                                                            continue;
                                                    }
                                                    #endregion

                                                    #region Item Type
                                                    if (bItemTypeSelected)
                                                    {
                                                        if (oItem.ItemType_ID != TxtItemType.Tag.ToString())
                                                            continue;
                                                    }
                                                    #endregion

                                                    #region Item Catagory
                                                    if (bItemcatagorySelected)
                                                    {
                                                        if (oItem.ItemCategory_ID != TxtItemCat.Tag.ToString())
                                                            continue;
                                                    }
                                                    #endregion

                                                    #region ItemFilter
                                                    if (bItemSelected)
                                                    {
                                                        if (oDODetail.Item_ID != txtItemID.Tag.ToString())
                                                            continue;
                                                    }
                                                    #endregion

                                                }
                                                #endregion

                                                if (!sItemList.Contains(oDODetail.Item_ID))
                                                    sItemList.Add(oDODetail.Item_ID);

                                                glb_dtsSales.dt_sasItemSales_SalesRepWise.Adddt_sasItemSales_SalesRepWiseRow(oDODetail.Item_ID, "", sSalesmanID, sSalesmanName, sAreaManagerID, sAreaManager, sSalesManagerID, sSalesManager, 0, 0, oDODetail.Qty, 0);
                                            }
                                        }
                                        #endregion

                                        #region SRN
                                        foreach (tbl_sasSalesReturnedNote oSRN in oSRNs)
                                        {
                                            #region Route / Sales Rep Filter                                                                                     
                                            tbl_genCustomerMaster CusDetail = tbl_genCustomerMaster.Select(oSRN.Customer_ID);
                                            if (CusDetail != null)
                                            {
                                                #region Route
                                                if (bRouteSelected)
                                                {
                                                    if (!chkUseCustomerMasterRoute.Checked)
                                                    {
                                                        sRouteID = oSRN.Route_ID.ToString();
                                                    }
                                                    else
                                                    {
                                                        foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oSRN.Customer_ID))
                                                        {
                                                            sRouteID = oRoute.Route_ID.ToString();
                                                            if (txtRoute.Tag.ToString() == sRouteID)
                                                                break;
                                                        }
                                                    }

                                                    if (txtRoute.Tag.ToString() != sRouteID)
                                                        continue;
                                                }
                                                #endregion

                                                #region Sales Rep
                                                if (chkUseCustomerMastorSaleRep.Checked)
                                                    sSalesmanID = CusDetail.SalesRep_ID;
                                                else
                                                {
                                                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oSRN.OrderRefNo_ID);
                                                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                                        sSalesmanID = oRef.Employee_ID;
                                                }

                                                if (bSelesRepSelected)
                                                {
                                                    if (sSalesmanID != txtSalesRep.Tag.ToString().Trim())
                                                        continue;
                                                }
                                                #endregion
                                            }

                                            sSalesmanName = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID);
                                            #endregion

                                            #region Managers
                                            tbl_ZEmpSalesRep oRep = tbl_ZEmpSalesRep.Select(sSalesmanID);
                                            if (oRep != null)
                                            {
                                                sAreaManagerID = oRep.AreaManager_ID;
                                                tbl_ZEmpAreaManager oManager = tbl_ZEmpAreaManager.Select(sAreaManagerID);
                                                if (oManager != null)
                                                {
                                                    sAreaManager = oManager.AreaManagerName;
                                                    sSalesManagerID = oManager.SalesManager_ID;

                                                    tbl_ZEmpSalesManager oSales = tbl_ZEmpSalesManager.Select(sSalesManagerID);
                                                    if (oSales != null)
                                                    {
                                                        sSalesManager = oSales.SalesManagerName;
                                                    }
                                                }
                                            }
                                            #endregion                                            

                                            foreach (tbl_sasSalesReturnedNote_Detail oSRNDetail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSRN.SalesReturnedNote_ID))
                                            //var SRNList = tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSRN.SalesReturnedNote_ID).GroupBy(gb => new { gb.Item_ID }, (Key, group) => new { ItemID = Key.Item_ID, TotQty = group.Sum(p => p.Qty) });
                                            //foreach (var oSRNDetail in SRNList)
                                            {
                                                #region item Filters
                                                tbl_genItemMaster oItem = tbl_genItemMaster.Select(oSRNDetail.Item_ID);
                                                if (oItem != null && oItem.Item_ID != "default")
                                                {
                                                    #region Item Class
                                                    if (bItemClassSelected)
                                                    {
                                                        if (oItem.ItemClass_ID != txtItemClass.Tag.ToString())
                                                            continue;
                                                    }
                                                    #endregion

                                                    #region Item Type
                                                    if (bItemTypeSelected)
                                                    {
                                                        if (oItem.ItemType_ID != TxtItemType.Tag.ToString())
                                                            continue;
                                                    }
                                                    #endregion

                                                    #region Item Catagory
                                                    if (bItemcatagorySelected)
                                                    {
                                                        if (oItem.ItemCategory_ID != TxtItemCat.Tag.ToString())
                                                            continue;
                                                    }
                                                    #endregion

                                                    #region ItemFilter
                                                    if (bItemSelected)
                                                    {
                                                        if (oSRNDetail.Item_ID != txtItemID.Tag.ToString())
                                                            continue;
                                                    }
                                                    #endregion
                                                }
                                                #endregion

                                                if (!sItemList.Contains(oSRNDetail.Item_ID))
                                                    sItemList.Add(oSRNDetail.Item_ID);

                                                glb_dtsSales.dt_sasItemSales_SalesRepWise.Adddt_sasItemSales_SalesRepWiseRow(oSRNDetail.Item_ID, "", sSalesmanID, sSalesmanName, sAreaManagerID, sAreaManager, sSalesManagerID, sSalesManager, 0, 0, 0, oSRNDetail.Qty);
                                            }
                                        }
                                        #endregion

                                        #region Stock balance
                                        for (int i = 0; i < sItemList.Count; i++)
                                        {
                                            decimal dQty = 0;
                                            foreach (srh_scsFlowStock oStocktxn in srh_scsFlowStock.Select(dtpFrom.Value.Date, sItemList.ElementAt(i), "0", txtBranch.Tag.ToString()))
                                            {
                                                dQty += oStocktxn.Qty;
                                            }
                                            glb_dtsSales.dt_sasItemFlowStock.Adddt_sasItemFlowStockRow(sItemList.ElementAt(i), clsGenaralName.getName_Item(sItemList.ElementAt(i)), dQty);
                                        }
                                        #endregion

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("FromDate", clsFormatter.FormatDate_SL(dtpFrom.Value.Date), true);
                                        glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsSales, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glb_dtsReportExport.Clear();
                                        glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.Clear();
                                    }
                                }
                                #endregion

                                #region Monthly Sales Calendar - Route and Sale Rep Wise - Indika
                                else if (Report == enum_ReportName.ST_MonthlySalesCalendar_RouteSalesRepWise)
                                {
                                    try
                                    {
                                        glb_dtsSales.Clear();

                                        List<tbl_sasInvoice> oInvoiceList = tbl_sasInvoice.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => !p.IsDeleted && !p.IsOpeningBalance && !p.IsReturnedCheque && !p.IsDebitNote && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date).ToList();
                                        List<tbl_bpsCreditNote> oCRNList = tbl_bpsCreditNote.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && !p.IsDeleted && p.PosReturnTransaction_Index == -1 && p.CreditNoteDate.Date >= dtpFrom.Value.Date && p.CreditNoteDate.Date <= dtpTo.Value.Date).ToList();// p.CreditNoteType_ID != "default" &&
                                        List<tbl_sasSalesReturnedNote> oSRNList = tbl_sasSalesReturnedNote.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && !p.IsDeleted && p.SalesReturnedNoteDate.Date >= dtpFrom.Value.Date && p.SalesReturnedNoteDate.Date <= dtpTo.Value.Date).ToList();
                                        List<tbl_bpsChequeRegister> oChequeRegList = tbl_bpsChequeRegister.SelectAll().Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default" && p.PosReturnTransaction_Index == -1 && p.PosReceipt_ID == "default" && p.AccountReceipt_ID == "default" && p.AdvanceReceived_Index == -1 && p.DateRegister.Date >= dtpFrom.Value.Date && p.DateRegister.Date <= dtpTo.Value.Date).ToList();

                                        string sSalesmanID = "";
                                        int iRouteID = -1;

                                        #region INV
                                        foreach (tbl_sasInvoice oInvoice in oInvoiceList)
                                        {
                                            #region Route
                                            //iRouteID = oInvoice.Route_ID;
                                            //if (chkUseCustomerMasterRoute.Checked)
                                            //{
                                            //    tbl_genCustomerMaster_Branches oRoute = tbl_genCustomerMaster_Branches.Select(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID));
                                            //    if (oRoute != null)
                                            //        iRouteID = oRoute.Route_ID;
                                            //}

                                            //if (bRouteSelected)
                                            //    if (txtRoute.Tag.ToString() != iRouteID.ToString())
                                            //        continue;
                                            #endregion

                                            #region Sales Rep Filter                                           
                                            if (!chkUseCustomerMastorSaleRep.Checked)
                                            {
                                                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                                if (oRef != null && oRef.OrderRefNo != "default")
                                                    sSalesmanID = oRef.Employee_ID;
                                            }
                                            else
                                            {
                                                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                                if (oCustomer != null)
                                                    sSalesmanID = oCustomer.SalesRep_ID;
                                            }

                                            if (bSelesRepSelected)
                                                if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                    continue;
                                            #endregion


                                            glb_dtsSales.dt_sasMonthlySalesCalendarRepRoute.Adddt_sasMonthlySalesCalendarRepRouteRow(iRouteID.ToString(), iRouteID == -1 ? "-" : clsGenaralName.get_RouteName(iRouteID),
                                                sSalesmanID, sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID), oInvoice.Invoice_ID, oInvoice.InvoiceDate,
                                                oInvoice.GrandTotal, 0, 0, 0, 0);
                                        }
                                        #endregion

                                        #region SRN
                                        foreach (tbl_sasSalesReturnedNote oSRN in oSRNList)
                                        {
                                            #region Route
                                            //iRouteID = oSRN.Route_ID;
                                            //if (chkUseCustomerMasterRoute.Checked)
                                            //{
                                            //    tbl_genCustomerMaster_Branches oRoute = tbl_genCustomerMaster_Branches.Select(oSRN.Customer_ID, int.Parse(oSRN.Branch_ID));
                                            //    if (oRoute != null)
                                            //        iRouteID = oRoute.Route_ID;
                                            //}

                                            //if (bRouteSelected)
                                            //    if (txtRoute.Tag.ToString() != iRouteID.ToString())
                                            //        continue;
                                            #endregion

                                            #region Sales Rep Filter                                           
                                            if (!chkUseCustomerMastorSaleRep.Checked)
                                            {
                                                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oSRN.OrderRefNo_ID);
                                                if (oRef != null && oRef.OrderRefNo != "default")
                                                    sSalesmanID = oRef.Employee_ID;
                                            }
                                            else
                                            {
                                                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oSRN.Customer_ID);
                                                if (oCustomer != null)
                                                    sSalesmanID = oCustomer.SalesRep_ID;
                                            }

                                            if (bSelesRepSelected)
                                                if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                    continue;
                                            #endregion

                                            glb_dtsSales.dt_sasMonthlySalesCalendarRepRoute.Adddt_sasMonthlySalesCalendarRepRouteRow(iRouteID.ToString(), iRouteID == -1 ? "-" : clsGenaralName.get_RouteName(iRouteID),
                                                sSalesmanID, sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID), oSRN.SalesReturnedNote_ID, oSRN.SalesReturnedNoteDate,
                                                0, oSRN.GrandTotal, 0, 0, 0);
                                        }
                                        #endregion

                                        #region CRN
                                        foreach (tbl_bpsCreditNote oCRN in oCRNList.Where(p => p.SalesReturnedNote_ID == "default"))
                                        {
                                            #region Route
                                            //iRouteID = oCRN.Route_ID;
                                            //if (chkUseCustomerMasterRoute.Checked)
                                            //{
                                            //    tbl_genCustomerMaster_Branches oRoute = tbl_genCustomerMaster_Branches.Select(oCRN.Customer_ID, int.Parse(oCRN.Branch_ID));
                                            //    if (oRoute != null)
                                            //        iRouteID = oRoute.Route_ID;
                                            //}

                                            //if (bRouteSelected)
                                            //    if (txtRoute.Tag.ToString() != iRouteID.ToString())
                                            //        continue;
                                            #endregion

                                            #region Sales Rep Filter                                           
                                            if (!chkUseCustomerMastorSaleRep.Checked)
                                            {
                                                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oCRN.OrderRefNo_ID);
                                                if (oRef != null && oRef.OrderRefNo != "default")
                                                    sSalesmanID = oRef.Employee_ID;
                                            }
                                            else
                                            {
                                                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oCRN.Customer_ID);
                                                if (oCustomer != null)
                                                    sSalesmanID = oCustomer.SalesRep_ID;
                                            }

                                            if (bSelesRepSelected)
                                                if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                    continue;
                                            #endregion

                                            glb_dtsSales.dt_sasMonthlySalesCalendarRepRoute.Adddt_sasMonthlySalesCalendarRepRouteRow(iRouteID.ToString(), iRouteID == -1 ? "-" : clsGenaralName.get_RouteName(iRouteID),
                                                sSalesmanID, sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID), oCRN.CreditNote_ID, oCRN.CreditNoteDate,
                                                0, 0, oCRN.TotalAmount, 0, 0);
                                        }
                                        #endregion

                                        #region Cheque & Cash
                                        foreach (tbl_bpsChequeRegister oCheque in oChequeRegList)
                                        {
                                            #region Sales Rep Filter                                           
                                            if (!chkUseCustomerMastorSaleRep.Checked)
                                            {
                                                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oCheque.OrderRefNo_ID);
                                                if (oRef != null && oRef.OrderRefNo != "default")
                                                    sSalesmanID = oRef.Employee_ID;
                                            }
                                            else
                                            {
                                                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oCheque.Customer_ID);
                                                if (oCustomer != null)
                                                    sSalesmanID = oCustomer.SalesRep_ID;
                                            }

                                            if (bSelesRepSelected)
                                                if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                                    continue;
                                            #endregion

                                            if (oCheque.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                                            {
                                                glb_dtsSales.dt_sasMonthlySalesCalendarRepRoute.Adddt_sasMonthlySalesCalendarRepRouteRow(iRouteID.ToString(), iRouteID == -1 ? "-" : clsGenaralName.get_RouteName(iRouteID),
                                                    sSalesmanID, sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID), oCheque.ChequeRegister_ID, oCheque.DateRegister,
                                                    0, 0, 0, oCheque.Amount, 0);
                                            }
                                            else
                                            {
                                                glb_dtsSales.dt_sasMonthlySalesCalendarRepRoute.Adddt_sasMonthlySalesCalendarRepRouteRow(iRouteID.ToString(), iRouteID == -1 ? "-" : clsGenaralName.get_RouteName(iRouteID),
                                                sSalesmanID, sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID), oCheque.ChequeRegister_ID, oCheque.DateRegister,
                                                0, 0, 0, 0, oCheque.Amount);
                                            }
                                        }
                                        #endregion

                                        glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsSales, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glb_dtsReportExport.Clear();
                                        glb_dtsSales.Clear();
                                    }
                                }
                                #endregion

                                #region  Item wise Gross Profit Summary - Indika
                                else if (Report == enum_ReportName.ST_SalesReportGrossProfitSummery_ItemWise || Report == enum_ReportName.ST_SalesReportGrossProfitSummery_CustomerWise || Report == enum_ReportName.ST_SalesReportGrossProfitSummery_SalesmanWise)
                                {
                                    Cursor = Cursors.WaitCursor;

                                    glb_dtsSales.Clear();
                                    glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                    dts_ReportExport glb_dts_ExportReport = new dts_ReportExport();

                                    string SalesmanID = bSelesRepSelected ? txtSalesRep.Tag.ToString() : "";
                                    string CustomerID = bCustomerSelected ? txtCustomer.Tag.ToString() : "";
                                    string ItemID = bItemSelected ? txtItemID.Tag.ToString() : "";
                                    int RouteID = bRouteSelected ? int.Parse(txtRoute.Tag.ToString()) : -1;
                                    int CustomerMastersalesRep = chkUseCustomerMastorSaleRep.Checked ? 1 : 0;

                                    string sQuary = "exec [sp_GetRpt_SalesReport_Mounth_Qty] '" + SalesmanID + "', '" + CustomerID + "', '" + ItemID + "', '" + dtpFrom.Value.ToString("dd-MMM-yyyy") + "','" + dtpTo.Value.ToString("dd-MMM-yyyy") + "'," + RouteID + "," + CustomerMastersalesRep + "," + (int)Report + "";

                                    glb_dtsSales.dt_sas_GrossProfitSummery.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                    frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();
                                    CRViwer.print(sReportPath, glb_dtsSales, glb_dts_ExportReport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    Cursor = Cursors.Default;
                                    glb_dtsSales.Clear();
                                }
                                #endregion

                                #region Monthly sales Customer Wise Rupees
                                else if (Report == enum_ReportName.ST_Monthly_Sales_Customer_Wise_Rupees)
                                {
                                    try
                                    {
                                        if (true)
                                        {

                                            Cursor = Cursors.WaitCursor;

                                            glb_dtsSales.Clear();
                                            glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                            dts_ReportExport glb_dts_ExportReport = new dts_ReportExport();

                                            string SalesmanID = bSelesRepSelected ? txtSalesRep.Tag.ToString() : "";
                                            string CustomerID = bCustomerSelected ? txtCustomer.Tag.ToString() : "";
                                            string ItemID = bItemSelected ? txtItemID.Tag.ToString() : "";
                                            int CustomerMastersalesRep = chkUseCustomerMastorSaleRep.Checked ? 1 : 0;
                                            int RouteID = bRouteSelected ? int.Parse(txtRoute.Tag.ToString()) : -1;

                                            string sQuary = "exec [sp_GetRpt_SalesReport_Mounth_Qty] '" + SalesmanID + "', '" + CustomerID + "', '" + ItemID + "', '" + dtpFrom.Value.ToString("dd-MMM-yyyy") + "','" + dtpTo.Value.ToString("dd-MMM-yyyy") + "'," + RouteID + "," + CustomerMastersalesRep + "," + (int)Report + "";

                                            glb_dtsSales.dt_sasMonthlySalesReport_Summary.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);
                                            sReportPath = "\\Reports\\SAS\\Standard\\rpt_sas_SalesMonthWise_New2.rpt";
                                            frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();


                                            glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("month1_name", dtpFrom.Value.ToString("MMM"), true);
                                            glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("month2_name", dtpFrom.Value.AddMonths(1).ToString("MMM"), true);
                                            glb_dts_ExportReport.dt_rptParameter.Adddt_rptParameterRow("month3_name", dtpFrom.Value.AddMonths(2).ToString("MMM"), true);



                                            CRViwer.print(sReportPath, glb_dtsSales, glb_dts_ExportReport.dt_rptParameter, clsAutocode.getReportID(Report));
                                            Cursor = Cursors.Default;
                                            glb_dtsSales.Clear();

                                           // rpt.print("\\Reports\\SAS\\Standard\\rpt_sas_SalesMonthWise_New2.rpt", glb_dtsSales, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));


                                            #region New Method
                                            //Cursor = Cursors.WaitCursor;
                                            //glb_dtsSales.Clear();
                                            //string sRouteID = "", sSalesmanID = "";
                                            //int iCurType = 0;
                                            //decimal dTotalWeight = 0, dTotalQty = 0;

                                            //int FirstMonth = dtpFrom.Value.Month;
                                            //int SecondMonth = dtpFrom.Value.AddMonths(1).Month;
                                            //int ThirdMonth = dtpFrom.Value.AddMonths(2).Month;

                                            //#region Selected Currency
                                            //if (rdoRupee.Checked)
                                            //    sReportTitle_Main = "Monthly Sales Report - Customer wise - Rupees ";
                                            //else if (rdoDollars.Checked)
                                            //    sReportTitle_Main = "Monthly Sales Report - Customer wise - Dollars ";
                                            //else if (rdoAll.Checked)
                                            //    sReportTitle_Main = "Monthly Sales Report - Customer wise ";
                                            //#endregion

                                            //#region Invoice                             
                                            //List<tbl_sasInvoice> oInvoiceList = tbl_sasInvoice.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => !p.IsDeleted && p.Invoice_ID != "default"
                                            //    && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date
                                            //    && !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque).ToList();

                                            ////fill data table
                                            //foreach (tbl_sasInvoice oInvoice in oInvoiceList)
                                            //{
                                            //    if (bCustomerSelected)
                                            //    {
                                            //        if (txtCustomer.Tag.ToString() != oInvoice.Customer_ID)
                                            //            continue;
                                            //    }

                                            //    tbl_genCustomerMaster CusDetail = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                            //    if (CusDetail != null)
                                            //    {
                                            //        #region Route
                                            //        if (bRouteSelected)
                                            //        {
                                            //            if (!chkUseCustomerMasterRoute.Checked)
                                            //            {
                                            //                sRouteID = oInvoice.Route_ID.ToString();
                                            //            }
                                            //            else
                                            //            {
                                            //                foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oInvoice.Customer_ID))
                                            //                {
                                            //                    sRouteID = oRoute.Route_ID.ToString();
                                            //                    if (txtRoute.Tag.ToString() == sRouteID)
                                            //                        break;
                                            //                }
                                            //            }

                                            //            if (txtRoute.Tag.ToString() != sRouteID)
                                            //                continue;
                                            //        }
                                            //        #endregion

                                            //        #region Sales Rep
                                            //        if (chkUseCustomerMastorSaleRep.Checked)
                                            //            sSalesmanID = CusDetail.SalesRep_ID;
                                            //        else
                                            //        {
                                            //            tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                            //            if (oRef != null && oRef.OrderRefNo_ID != "default")
                                            //                sSalesmanID = oRef.Employee_ID;
                                            //        }

                                            //        if (bSelesRepSelected)
                                            //        {
                                            //            if (sSalesmanID != txtSalesRep.Tag.ToString().Trim())
                                            //                continue;
                                            //        }
                                            //        #endregion

                                            //        #region Customer Filters
                                            //        if (bCustomerTypeSelected)
                                            //        {
                                            //            if (CusDetail.CustomerType_ID != txtCusType.Tag.ToString())
                                            //                continue;
                                            //        }

                                            //        if (bCustomerClassSelected)
                                            //        {
                                            //            if (CusDetail.CustomerClass_ID != txtCusClass.Tag.ToString())
                                            //                continue;
                                            //        }

                                            //        if (bCustomerCategorySelected)
                                            //        {
                                            //            if (CusDetail.CustomerCategory_ID != txtCusCategory.Tag.ToString())
                                            //                continue;
                                            //        }
                                            //        #endregion
                                            //    }

                                            //    int month = 0;
                                            //    if (oInvoice.InvoiceDate.Month == FirstMonth)
                                            //        month = 1;
                                            //    else if (oInvoice.InvoiceDate.Month == SecondMonth)
                                            //        month = 2;
                                            //    else if (oInvoice.InvoiceDate.Month == ThirdMonth)
                                            //        month = 3;

                                            //    glb_dtsSales.dt_sasMonthlySalesReport_Summary.Adddt_sasMonthlySalesReport_SummaryRow(oInvoice.Invoice_ID, oInvoice.InvoiceDate,
                                            //           CusDetail.CustomerName, clsGenaralName.getName_BranchCustomer(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID)), oInvoice.GrandTotal, dTotalWeight, dTotalQty, month, oInvoice.InvoiceDate.Year.ToString());
                                            //}
                                            //#endregion

                                            //#region POS
                                            ////List<tbl_posTransaction> oPosList = tbl_posTransaction.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => !p.IsHold && !p.IsDeleted && p.PosTransaction_ID != "default"
                                            ////    && p.PosTransactiondate.Date >= dtpFrom.Value.Date && p.PosTransactiondate.Date <= dtpTo.Value.Date).ToList();

                                            //////fill data table
                                            ////foreach (tbl_posTransaction oPos in oPosList)
                                            ////{
                                            ////    if (bCustomerSelected)
                                            ////    {
                                            ////        if (txtCustomer.Tag.ToString() != oPos.Customer_ID)
                                            ////            continue;
                                            ////    }

                                            ////    tbl_genCustomerMaster CusDetail = tbl_genCustomerMaster.Select(oPos.Customer_ID);
                                            ////    if (CusDetail != null)
                                            ////    {
                                            ////        #region Customer Filters
                                            ////        if (bCustomerTypeSelected)
                                            ////        {
                                            ////            if (CusDetail.CustomerType_ID != txtCusType.Tag.ToString())
                                            ////                continue;
                                            ////        }

                                            ////        if (bCustomerClassSelected)
                                            ////        {
                                            ////            if (CusDetail.CustomerClass_ID != txtCusClass.Tag.ToString())
                                            ////                continue;
                                            ////        }

                                            ////        if (bCustomerCategorySelected)
                                            ////        {
                                            ////            if (CusDetail.CustomerCategory_ID != txtCusCategory.Tag.ToString())
                                            ////                continue;
                                            ////        }
                                            ////        #endregion
                                            ////    }

                                            ////    glb_dtsSales.dt_sasMonthlySalesReport_Summary.Adddt_sasMonthlySalesReport_SummaryRow(oPos.PosTransaction_ID, oPos.PosTransactiondate,
                                            ////            CusDetail.CustomerName, "default", oPos.GrandTotal, dTotalWeight, dTotalQty, oPos.PosTransactiondate.Month, oPos.PosTransactiondate.Year.ToString());
                                            ////}
                                            //#endregion

                                            //glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                            ////print("\\Reports\\SAS\\Standard\\rpt_sas_SalesMonthWise.rpt", " Monthly Sales report Summary", glb_dtsSales, "");
                                            //frm_ReportViewer_New rpt = new frm_ReportViewer_New();

                                            //glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("month1_name", dtpFrom.Value.ToString("MMM"), true);
                                            //glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("month2_name", dtpFrom.Value.AddMonths(1).ToString("MMM"), true);
                                            //glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("month3_name", dtpFrom.Value.AddMonths(2).ToString("MMM"), true);

                                            //rpt.print("\\Reports\\SAS\\Standard\\rpt_sas_SalesMonthWise_New2.rpt", glb_dtsSales, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                                            #endregion
                                        }
                                        else
                                        {
                                            #region Old Method
                                            sReportPath = "\\Reports\\SAS\\Standard\\rpt_sas_SalesMonthWise_AKI.rpt";
                                            glb_dtMonthlySales.Rows.Clear();
                                            if (rdoRupee.Checked)
                                            {
                                                sReportTitle_Main = " Monthly Sales Report - Customer wise - Rupees ";
                                                calculateTotalSales(1);
                                            }
                                            else if (rdoDollars.Checked)
                                            {
                                                sReportTitle_Main = " Monthly Sales Report - Customer wise - Dollars ";
                                                calculateTotalSales(2);
                                            }
                                            else if (rdoAll.Checked)
                                            {
                                                sReportTitle_Main = " Monthly Sales Report - Customer wise - All ";
                                                calculateTotalSales(3);
                                            }

                                            print(sReportPath, sReportTitle_Main, glb_dtMonthlySales, "");
                                            #endregion
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                        glb_dtsSales.Clear();
                                        glb_dtMonthlySales.Clear();
                                    }
                                }
                                #endregion

                                #region Sales Reports Sales Route wise / rep Wise
                                else if (Report == enum_ReportName.ST_SalesReport_RouteWise || Report == enum_ReportName.ST_SalesReport_SalesRepWise || Report == enum_ReportName.ST_SalesReport_CustomerWise_Metrix)
                                {
                                    Cursor = Cursors.WaitCursor;

                                    glb_dtsSales.Clear();
                                    glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                    dts_ReportExport glb_dts_ExportReport = new dts_ReportExport();

                                    string SalesmanID = bSelesRepSelected ? txtSalesRep.Tag.ToString() : "";
                                    string CustomerID = bCustomerSelected ? txtCustomer.Tag.ToString() : "";
                                    string ItemID = bItemSelected ? txtItemID.Tag.ToString() : "";
                                    int CustomerMastersalesRep = chkUseCustomerMastorSaleRep.Checked ? 1 : 0;
                                    int RouteID = bRouteSelected ? int.Parse(txtRoute.Tag.ToString()) : -1;

                                    string sQuary = "exec [sp_GetRpt_SalesReport_Mounth_Qty] '" + SalesmanID + "', '" + CustomerID + "', '" + ItemID + "', '" + dtpFrom.Value.ToString("dd-MMM-yyyy") + "','" + dtpTo.Value.ToString("dd-MMM-yyyy") + "'," + RouteID + "," + CustomerMastersalesRep + "," + (int)Report + "";

                                    glb_dtsSales.dt_sasSalesReport.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                    frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();
                                    CRViwer.print(sReportPath, glb_dtsSales, glb_dts_ExportReport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    Cursor = Cursors.Default;
                                    glb_dtsSales.Clear();
                                }
                                #endregion

                                #region Monthly_Sales_QTY_RoutWise
                                else if (Report == enum_ReportName.ST_Monthly_Sales_QTY_RoutWise)
                                {
                                    Cursor = Cursors.WaitCursor;

                                    glb_dtsUnspecified.Clear();
                                    glb_dtsUnspecified.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                    dts_ReportExport glb_dts_ExportReport = new dts_ReportExport();

                                    string SalesmanID = bSelesRepSelected ? txtSalesRep.Tag.ToString() : "";
                                    string CustomerID = bCustomerSelected ? txtCustomer.Tag.ToString() : "";
                                    string ItemID = bItemSelected ? txtItemID.Tag.ToString() : "";
                                    int RouteID = bRouteSelected ? int.Parse(txtRoute.Tag.ToString()) : -1;
                                    int CustomerMastersalesRep = chkUseCustomerMastorSaleRep.Checked ? 1 : 0;

                                    string sQuary = "exec [sp_GetRpt_SalesReport_Mounth_Qty] '" + SalesmanID + "', '" + CustomerID + "', '" + ItemID + "', '" + dtpFrom.Value.ToString("dd-MMM-yyyy") + "','" + dtpTo.Value.ToString("dd-MMM-yyyy") + "'," + RouteID + "," + CustomerMastersalesRep+","+(int)Report + "";

                                    glb_dtsUnspecified.dt_Unspecified_01.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                    frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();
                                    CRViwer.print(sReportPath, glb_dtsUnspecified, glb_dts_ExportReport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    Cursor = Cursors.Default;
                                    glb_dtsUnspecified.Clear();
                                }
                                #endregion

                                #region Monthly_Sales_QTY_RoutWise
                                else if (Report == enum_ReportName.ST_Monthly_Sales_QTY_ItemWise)
                                {
                                    Cursor = Cursors.WaitCursor;

                                    glb_dtsUnspecified.Clear();
                                    glb_dtsUnspecified.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                    dts_ReportExport glb_dts_ExportReport = new dts_ReportExport();

                                    string SalesmanID = bSelesRepSelected ? txtSalesRep.Tag.ToString() : "";
                                    string CustomerID = bCustomerSelected ? txtCustomer.Tag.ToString() : "";
                                    string ItemID = bItemSelected ? txtItemID.Tag.ToString() : "";
                                    int RouteID = bRouteSelected ? int.Parse(txtRoute.Tag.ToString()) : -1;
                                    int CustomerMastersalesRep = chkUseCustomerMastorSaleRep.Checked ? 1 : 0;

                                    string sQuary = "exec [sp_GetRpt_SalesReport_Mounth_Qty] '" + SalesmanID + "', '" + CustomerID + "', '" + ItemID + "', '" + dtpFrom.Value.ToString("dd-MMM-yyyy") + "','" + dtpTo.Value.ToString("dd-MMM-yyyy") + "'," + RouteID + "," + CustomerMastersalesRep + "," + (int)Report + "";

                                    glb_dtsUnspecified.dt_Unspecified_01.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                                    frm_ReportViewer_New CRViwer = new frm_ReportViewer_New();
                                    CRViwer.print(sReportPath, glb_dtsUnspecified, glb_dts_ExportReport.dt_rptParameter, clsAutocode.getReportID(Report));
                                    Cursor = Cursors.Default;
                                    glb_dtsUnspecified.Clear();
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
        #endregion

        #region Credit Note Export
        private void Creditnote_ExportSvat(ref string sReportPath, ref string sReportTitle, ref bool bSVAT, ref int iCreditNoteCount, ref decimal dTotalAmount)
        {
            iCreditNoteCount = 0;
            dTotalAmount = 0;
            List<tbl_bpsCreditNote> Query = tbl_bpsCreditNote.SelectAll().Where(p => !p.IsDeleted && p.CreditNote_ID != "default" && p.CreditNoteDate.Date >= dtpFrom.Value.Date && p.CreditNoteDate.Date <= dtpTo.Value.Date
                && p.CreditNoteType_ID != "'" + clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit) + "'" && p.OtherTaxTotal > 0 && p.CompanyBranch_ID == txtBranch.Tag.ToString()).ToList();

            foreach (tbl_bpsCreditNote oCreditNote in Query)
            {
                if (bCustomerSelected)
                {
                    if (oCreditNote.Customer_ID != txtCustomer.Tag.ToString().Trim())
                        continue;
                }
                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oCreditNote.Customer_ID);
                if (oCustomer != null)
                {
                    if (oCustomer.CustomerType_ID == "2")
                    {
                        decimal dWithNBTAmount = 0.00m, dSubTotal = oCreditNote.TotalAmount, dNBTAmount = 0.00m, dVatAmount = oCreditNote.OtherTaxTotal;
                        int iRecordCount = 0;

                        foreach (tbl_bpsCreditNote_Invoice oCRNInvoice in tbl_bpsCreditNote_Invoice.SelectAllByCreditNote_ID(oCreditNote.CreditNote_ID))
                        {
                            tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oCRNInvoice.Invoice_ID);

                            if (oInvoice != null)
                            {
                                dVatAmount = oInvoice.VatTotal;
                                dSubTotal = oCRNInvoice.AlocatedAmount;
                                glb_dtsSales.dt_sasTaxDetails_CreditNote.Adddt_sasTaxDetails_CreditNoteRow(oCreditNote.CreditNote_ID, oCreditNote.CreditNoteDate, clsGenaralName.getName_Customer(oCreditNote.Customer_ID), oCRNInvoice.AlocatedAmount,
                                    dSubTotal, clsGenaralName.getName_CreditNoteType(oCreditNote.CreditNoteType_ID), oInvoice.Invoice_ID, oInvoice.InvoiceDate, dSubTotal * oCreditNote.VatPercentage / 100, dNBTAmount, dWithNBTAmount, clsGenaralName.getName_CurrencyCode(oCreditNote.Currency_ID),
                                    oCreditNote.CurrencyRate, clsHelpMethods_Local.getDisplayPrice(dSubTotal, oCreditNote.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(dVatAmount, oCreditNote.CurrencyRate), dSubTotal, "",
                                    oCreditNote.IsDeleted, oCreditNote.PrintCount, oCRNInvoice.Invoice_ID, oCRNInvoice.AlocatedAmount, oCreditNote.Remark, "", clsSecurity.getServerDateTime().Date,
                                     oCreditNote.TotalAmount, oCreditNote.VatTotal, oCreditNote.NbtTotal, oCreditNote.SubTotal, iRecordCount, "", "", 0, 0, "");
                                iRecordCount++;
                            }
                        }
                        if (iRecordCount == 0 && oCreditNote.Invoice_ID != "default")// If No record available 
                        {
                            tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oCreditNote.Invoice_ID);
                            if (oInvoice != null)
                            {
                                glb_dtsSales.dt_sasTaxDetails_CreditNote.Adddt_sasTaxDetails_CreditNoteRow(oCreditNote.CreditNote_ID, oCreditNote.CreditNoteDate, clsGenaralName.getName_Customer(oCreditNote.Customer_ID), oCreditNote.TotalAmount,
                                    dSubTotal, clsGenaralName.getName_CreditNoteType(oCreditNote.CreditNoteType_ID), oCreditNote.Invoice_ID, oInvoice.InvoiceDate, dSubTotal * oCreditNote.VatPercentage / 100, dNBTAmount, dWithNBTAmount, clsGenaralName.getName_CurrencyCode(oCreditNote.Currency_ID),
                                    oCreditNote.CurrencyRate, clsHelpMethods_Local.getDisplayPrice(dSubTotal, oCreditNote.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(dVatAmount, oCreditNote.CurrencyRate), dSubTotal, "",
                                    oCreditNote.IsDeleted, oCreditNote.PrintCount, oCreditNote.Invoice_ID, oCreditNote.TotalAmount, oCreditNote.Remark, "", clsSecurity.getServerDateTime().Date,
                                     oCreditNote.TotalAmount, oCreditNote.VatTotal, oCreditNote.NbtTotal, oCreditNote.SubTotal, 1, "", "", 0, 0, "");
                            }
                        }
                        iCreditNoteCount++;
                        dTotalAmount += oCreditNote.TotalAmount;
                    }
                }
                clsHelpMethods_Local.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
            }
            if (cmbTaxType.Text.Trim() == "Export SVAT" && txtCustomer.Tag != null)
            {
                sReportPath = "\\reports\\SAS\\Standard\\rpt_sas_TaxReportDetail_CreditNoteExport_SVAT_SingleCustomer.rpt";
                sReportTitle = "GOODS/Services Declaration – supplementary Form";
            }
            else
            {
                sReportTitle = "Tax Report Detail - Credit Note [Export SVAT]";
                sReportPath = "\\reports\\SAS\\Standard\\rpt_sas_TaxReportDetail_CreditNoteExport_SVAT.rpt";
            }

            bSVAT = true;
        }
        #endregion

        #region Invoice Export
        private void Invoice_ExportSvat(ref string sReportPath, ref string sReportTitle, ref string sInvoiceType, ref int iInvoiceCount, ref decimal dTotalAmount)
        {
            iInvoiceCount = 0;
            dTotalAmount = 0;
            List<tbl_sasInvoice> Query = tbl_sasInvoice.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => !p.IsDeleted && p.Invoice_ID != "default" && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date
                                                      && !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque && p.OtherTaxTotal > 0).ToList();

            foreach (tbl_sasInvoice oInvoice in Query)
            {
                //Added by Gayan 2016-08-26 - Reason : Note Type filter is not working - Reported by Maduka
                if (bSalesNoteTypeSelected)
                    if (txtSalesNoteType.Tag.ToString() != oInvoice.SalesNoteType_ID)
                        continue;
                //*******************************************************************//

                if (bCustomerSelected)
                {
                    if (oInvoice.Customer_ID != txtCustomer.Tag.ToString().Trim())
                        continue;
                }

                tbl_genCustomerMaster CusDetail = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                if (CusDetail != null)
                {
                    if (bCustomerClassSelected)
                    {
                        if (CusDetail.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                            continue;
                    }
                    if (bCustomerTypeSelected)
                    {
                        if (CusDetail.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                            continue;
                    }
                    if (bCustomerCategorySelected)
                    {
                        if (CusDetail.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                            continue;
                    }
                }

                if (bCustomerSelected)
                {
                    if (oInvoice.Customer_ID != txtCustomer.Tag.ToString().Trim())
                        continue;
                }
                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                {
                    if (oInvoice.Job_ID != "default") //With Job
                    {
                        //tbl_pmsProductionJobRegister oJob = tbl_pmsProductionJobRegister.Select(oInvoice.Job_ID);
                        //if (oJob != null)
                        //    sInvoiceType = clsGenaralName.getName_ProductionJobType(oJob.ProductionJobType_ID);

                        //for fillter Job Code type
                        if (txtJobType.Tag != null && txtJobType.Tag.ToString().Length > 0 && txtJobType.Tag.ToString().Trim() != "default")
                        {
                            //if (oJob != null)
                            //{
                            //    if (oJob.ProductionJobType_ID != txtJobType.Tag.ToString().Trim())
                            //        continue;
                            //}
                        }

                    }
                    else if (oInvoice.DeliveryOrder_ID != "default") //Direct Sales
                    {
                        sInvoiceType = "Direct Sales";
                    }
                    else
                        sInvoiceType = (oInvoice.IsVatInvoice) ? "Vat Invoice" : (oInvoice.IsSVatInvoice) ? "SVat Invoice" : "Non Tax Invoice";

                    if (oInvoice.Quotation_ID != "default") //Block Sales
                        sInvoiceType = "Block Invoice";
                }
                else
                {
                    if (clsConfig.bSalesNoteType_SerialNoActiveFor_Invoice)
                        sInvoiceType = clsGenaralName.getName_SalesNoteType(oInvoice.SalesNoteType_ID);
                    else
                        sInvoiceType = (oInvoice.IsVatInvoice) ? "Vat Invoice" : (oInvoice.IsSVatInvoice) ? "SVat Invoice" : "Non Tax Invoice";
                }

                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                //tbl_pmsProductionJobRegister oProductionRegister = tbl_pmsProductionJobRegister.Select(oInvoice.Job_ID);
                //if (oProductionRegister != null & oCustomer != null)
                //{
                //    if (oCustomer.CustomerType_ID == "2" && oCustomer.IsSVATenable)
                //    {
                //        string sPONo = "";
                //        if (oInvoice.Job_ID == "default" && oInvoice.DeliveryOrder_ID != "default") //Direct Sales
                //            sPONo = clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID);
                //        else if (oInvoice.Quotation_ID != "default" && oInvoice.DeliveryOrder_ID == "default") //Block Invoice
                //            sPONo = clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID);
                //        else if (oInvoice.Job_ID != "default" && oInvoice.DeliveryOrder_ID != "default") //Normal Invoice
                //            sPONo = clsHelpMethods_Local.GetPONoByProductionJobID(oInvoice.Job_ID);
                //        decimal dCurrencyTotal = 0, dCurrencyVat = 0;

                //        dCurrencyTotal = (oInvoice.Currency_ID == clsConfig.sLocalCurrencyCode) ? 0 : oInvoice.GrandTotal / oInvoice.CurrencyRate;
                //        dCurrencyVat = (oInvoice.Currency_ID == clsConfig.sLocalCurrencyCode) ? 0 : oInvoice.OtherTaxTotal / oInvoice.CurrencyRate;

                //        glb_dtsSales.dt_sasTaxDetails_Invoice.Adddt_sasTaxDetails_InvoiceRow(oInvoice.Invoice_ID, oInvoice.InvoiceDate, clsGenaralName.getName_Customer(oInvoice.Customer_ID), clsGenaralName.getName_BranchCustomer(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID)), oInvoice.GrandTotal, oInvoice.GrandTotal,
                //            0, oInvoice.OtherTaxTotal, oInvoice.GrandTotal, sPONo, oInvoice.DeliveryOrder_ID, oInvoice.Job_ID, oInvoice.CurrencyRate, clsGenaralName.getName_CurrencyCode(oInvoice.Currency_ID),
                //            clsGenaralName.getName_ProductionJobType(oProductionRegister.ProductionJobType_ID), oInvoice.DateCreate, dCurrencyTotal, dCurrencyVat, sInvoiceType);
                //        iInvoiceCount += 1;
                //        dTotalAmount += oInvoice.GrandTotal;
                //    }
                //}
                clsHelpMethods_Local.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
            }


            if (cmbTaxType.Text.Trim() == "Export SVAT" && txtCustomer.Tag != null)
            {
                sReportPath = "\\reports\\SAS\\Standard\\rpt_sas_TaxReportDetail_InvoiceExport_SVAT_SingleCustomer.rpt";
                sReportTitle = "GOODS/Services Declaration – supplementary Form";
            }
            else
            {
                sReportPath = "\\reports\\SAS\\Standard\\rpt_sas_TaxReportDetail_InvoiceExport_SVAT.rpt";
                sReportTitle = "Tax Report Detail - Invoice [Export SVAT]";
            }
        }
        #endregion

        #region Data Set Invoice Wise Profit Report
        //private DataSet JobProfile()
        //{
        //    return glb_dtsJobProfile;
        //}
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
            txtRoute.Tag = null;
            txtSalesRep.Tag = null;
            txtCustomer.Tag = null;
            txtCusClass.Tag = null;
            txtCusType.Tag = null;
            txtCusCategory.Tag = null;
            txtTown.Tag = null;
            txtItemClass.Tag = null;
            TxtItemType.Tag = null;
            TxtItemCat.Tag = null;
            txtItemID.Tag = null;
            txtItemSerialNo.Tag = null;
            txtItemSubCategory.Tag = null;
            txtItemSerialNo.Clear();
            txtItemSubCategory.Clear();
            txtJobCode.Clear();
            txtSalesNoteType.Tag = null;
            txtJobType.Tag = null;
            txtBranch.Tag = clsSecurity.BranchID;
            txtSalesManager.Tag = null;
            txtAreaManager.Tag = null;
            txtDriver.Tag = null;
            txtDeliveryOfficer.Tag = null;

            tbl_genCompanyBranchMaster oBranch = tbl_genCompanyBranchMaster.Select(clsSecurity.BranchID);
            if (oBranch != null)
            {
                if (!oBranch.IsHeadOffice)
                {
                    clsCommon.SetEnableDisable_NormalLabel(lblBranch, false);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBranch, false);
                }
            }

            txtRoute.Text = "<All Route>";
            txtSalesRep.Text = "<All SalesReps>";
            txtCustomer.Text = "<All Customers>";
            txtCusClass.Text = "<All Classes>";
            txtCusType.Text = "<All Types>";
            txtCusCategory.Text = "<All Categories>";
            txtItemClass.Text = "<All Item Class>";
            TxtItemType.Text = "<All Item Types>";
            TxtItemCat.Text = "<All Item Categories>";
            txtItemID.Text = "<All Items>";
            txtTown.Text = "<All Towns>";
            txtJobCode.Text = "<All Jobs>";
            txtSalesNoteType.Text = "<All Note Types>";
            txtJobType.Text = "<All Jobs Type>";
            txtSalesManager.Text = "<All Sales Managers>";
            txtAreaManager.Text = "<All Area Managers>";
            txtDriver.Text= "<All Driver>";
            txtDeliveryOfficer.Text = "<All Delivery Officer>";

            txtBranch.Text = clsGenaralName.getName_CompanyBranchMaster(clsSecurity.BranchID);

            cmbTaxType.SelectedIndex = 0;
            cmbDOType.SelectedIndex = 0;
            cmbCostPrice.SelectedIndex = 0;
            cmbPriceCategory.SelectedIndex = 0;

            rdoRupee.Checked = true;
            //chkShowUpdatedReport.Visible = false;
            chkShowUpdatedReport.Checked = true;
            chkShowShowrooms.Checked = true;
            chkShowAll.Checked = false;

            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCusClass, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCusClass, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCusType, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCusType, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCusCategory, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCusCategory, true);

            clsCommon.SetEnableDisable_NormalLabel(lblItemClass, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItemClass, true);

            clsCommon.SetEnableDisable_NormalLabel(lblItemtype, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(TxtItemType, true);

            clsCommon.SetEnableDisable_NormalLabel(lblItemCat, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(TxtItemCat, true);

            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);

            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtDriver, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtDeliveryOfficer, true);

            clsCommon.SetVisibility_Panel(pnlBranch, true);
            clsCommon.SetVisibility_Panel(pnlCusName, false);
            //clsCommon.SetVisibility_Panel(pnlCusCategory, true);
            //clsCommon.SetVisibility_Panel(pnlCusClass, true);
            clsCommon.SetVisibility_Panel(pnlCusType, true);
            clsCommon.SetVisibility_Panel(pnlCostPrice, false);
            clsCommon.SetVisibility_Panel(pnlItemClass, false);
            clsCommon.SetVisibility_Panel(pnlItemType, false);
            clsCommon.SetVisibility_Panel(pnlItemCat, false);
            clsCommon.SetVisibility_Panel(pnlItemName, false);
            clsCommon.SetVisibility_Panel(pnlJobType, false);
            clsCommon.SetVisibility_Panel(pnlNoteType, false);
            clsCommon.SetVisibility_Panel(pnlRoute, false);
            clsCommon.SetVisibility_Panel(pnlSalesman, true);
            clsCommon.SetVisibility_Panel(pnlSalesManager, false);
            clsCommon.SetVisibility_Panel(pnlAreaManager, false);
            clsCommon.SetVisibility_Panel(pnlTown, false);
            clsCommon.SetVisibility_Panel(pnlTaxType, false);
            clsCommon.SetVisibility_Panel(pnlCurrency, false);
            clsCommon.SetVisibility_Panel(pnlQty, false);
            clsCommon.SetVisibility_Panel(pnlShowRoom, false);
            clsCommon.SetVisibility_Panel(pnlUpdatedReport, false);
            clsCommon.SetVisibility_Panel(pnlZeeroHide, false);

            clsCommon.SetVisibility_Panel(PnlDriver, false);
            clsCommon.SetVisibility_Panel(pnlDeliveryOfficer, false);

            //chkShowUpdatedReport.Visible = false;
            //chkShowShowrooms.Visible = false;

            //clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtJobType, false);

            clsCommon.SetEnableDisable_NormalCheckBox(chkReduceNBTAndVatValue, false);
            clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, false);
            clsCommon.SetEnableDisable_NormalCheckBox(chkIsReplasement, false);
            clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMasterRoute, true);
            chkUseCustomerMasterRoute.Checked = false;
            chkReduceNBTAndVatValue.Checked = false;
            chkHideZero.Checked = true;

            z4.Visible = false;
            pnl_QV.Visible = false;

            //if (clsSecurity.BranchName != "Cuddles Sales")
            //{
            //    //(int)enum_ReportName.ST_SalesReport_NoteTypeWise.


            //    rdoSalesReportNoteTypeWise.Visible = false;
            //    rdoSalesReportSalesmanWise.Visible = false;
            //}

            //if (clsConfig.bShowDONotInvoiced)
            //    rdoDOnotInvoiced.Visible = true;

            //if (clsConfig.bShowFreeItems)
            //    rdoFreeItems.Visible = true;
            //else
            //    rdoFreeItems.Visible = false;

            //rdoCustomerOrderTracking.Visible = clsConfig.bShow_CustomerOrderTracking_Report;

        }
        #endregion

        #region Print Method
        #region print Method For Viw
        private void print(string path, string sReportTitle, string sFormula, string sFilter)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Standed Reports";
                ReportDocument RD = new ReportDocument();
                s_Path = Application.StartupPath.Replace("\\Mini ERP\\bin\\Debug", "\\ZION.ERP.Reports");
                s_Path += path;

                frm_ReportViewer viewer = new frm_ReportViewer();
                RD.Load(s_Path); Digiteq.Classes.ReportHelper.LogonServer(ref RD);
                //   clsSecurity.LogonServer(ref RD);
                RD.Refresh();

                RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "  To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                RD.DataDefinition.FormulaFields["sReportNo"].Text = clsCommon.fncsetstring(iReport.ToString());

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

        #region Print report
        private void print(string path, string sReportTitle, DataSet objDataSet)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sFilter = "";//sHeaderTitle = "Standed Reports", sReportFilter = "",
                ReportDocument objRpt = new ReportDocument();

                s_Path = Application.StartupPath.Replace("\\Mini ERP\\bin\\Debug", "\\ZION.ERP.Reports");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(objDataSet); //(glbDtsBills);

                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                objRpt.DataDefinition.FormulaFields["sReportNo"].Text = clsCommon.fncsetstring(iReport.ToString());

                if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Length > 0)
                    sFilter += "Customer Name : " + txtCustomer.Text.Trim();
                if (txtSalesNoteType.Tag != null && txtSalesNoteType.Tag.ToString().Length > 0)
                    sFilter += "Note Type : " + txtSalesNoteType.Text.Trim();
                if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Trim().Length > 0)
                    sFilter += "Salesman Code : " + txtSalesRep.Text.Trim();
                if (txtTown.Tag != null && txtTown.Tag.ToString().Length > 0)
                    sFilter += "Town Name : " + txtTown.Text.Trim();
                if (txtItemID.Tag != null && txtItemID.Tag.ToString().Length > 0)
                    sFilter += "Item Name : " + txtItemID.Text.Trim();
                if (cmbTaxType.Tag != null && cmbTaxType.Tag.ToString().Length > 0)
                    sFilter += "Tax Type : " + cmbTaxType.Text.Trim();
                if (txtRoute.Tag != null && txtRoute.Tag.ToString().Length > 0)
                    sFilter += "Route Name : " + txtRoute.Text.Trim();
                if (txtJobCode.Tag != null && txtJobCode.Tag.ToString().Length > 0)
                    sFilter += "Job Code : " + txtJobCode.Text.Trim();

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
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Print method for Data Set
        private void print(string path, string sReportTitle, DataTable objDataTable, string sFilter)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Standed Reports", sSeperator;
                CrystalDecisions.CrystalReports.Engine.ReportDocument objRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                s_Path = Application.StartupPath.Replace("\\Mini ERP\\bin\\Debug", "\\ZION.ERP.Reports");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(objDataTable); //(glbDtsSales)

                objRpt.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "  To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);
                objRpt.DataDefinition.FormulaFields["sReportNo"].Text = clsCommon.fncsetstring(iReport.ToString());

                //string sFilter = "";               
                sSeperator = sFilter.Length > 0 ? " / " : "";
                if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Length > 0)
                    sFilter += sSeperator + "Customer Name : " + txtCustomer.Text.Trim();
                sSeperator = sFilter.Length > 0 ? " / " : "";
                if (txtSalesNoteType.Tag != null && txtSalesNoteType.Tag.ToString().Length > 0)
                    sFilter += sSeperator + "Note Type : " + txtSalesNoteType.Text.Trim();
                sSeperator = sFilter.Length > 0 ? " / " : "";
                if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Trim().Length > 0)
                    sFilter += sSeperator + "Salesman Code : " + txtSalesRep.Text.Trim();
                sSeperator = sFilter.Length > 0 ? " / " : "";
                if (txtTown.Tag != null && txtTown.Tag.ToString().Length > 0)
                    sFilter += sSeperator + "Town Name : " + txtTown.Text.Trim();
                sSeperator = sFilter.Length > 0 ? " / " : "";
                if (txtItemID.Tag != null && txtItemID.Tag.ToString().Length > 0)
                    sFilter += sSeperator + "Item Name : " + txtItemID.Text.Trim();
                sSeperator = sFilter.Length > 0 ? " / " : "";
                if (cmbTaxType.Tag != null && cmbTaxType.Tag.ToString().Length > 0)
                    sFilter += sSeperator + "Tax Type : " + cmbTaxType.Text.Trim();
                sSeperator = sFilter.Length > 0 ? " / " : "";
                if (txtRoute.Tag != null && txtRoute.Tag.ToString().Length > 0)
                    sFilter += "Route Name : " + txtRoute.Text.Trim();
                sSeperator = sFilter.Length > 0 ? " / " : "";
                if (txtJobCode.Tag != null && txtJobCode.Tag.ToString().Length > 0)
                    sFilter += sSeperator + "Job Code : " + txtJobCode.Text.Trim();
                if (sFilter != "")
                    //{
                    objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);
                //}

                //if ((rdoTaxReportInvoice.Checked || rdoTaxReportCreditNote.Checked) && cmbTaxType.Text.Trim() == "Export SVAT" && txtCustomer.Tag != null)

                int iRow = dgvReports.SelectedCells[0].RowIndex;
                iReport = int.Parse(dgvReports.Rows[iRow].Cells[0].Value.ToString());
                enum_ReportName Report = (enum_ReportName)iReport;
                if ((iReport == (int)enum_ReportName.ST_Tax_Report_Invoice_DetailLocalNBTVAT || iReport == (int)enum_ReportName.ST_Tax_Report_Invoice_DetailExportVAT || iReport == (int)enum_ReportName.ST_Tax_Report_Invoice_DetailExportSVAT || iReport == (int)enum_ReportName.ST_Tax_Report_CreditNote) && cmbTaxType.Text.Trim() == "Export SVAT" && txtCustomer.Tag != null)
                {
                    objRpt.DataDefinition.FormulaFields["CustomerName"].Text = clsCommon.fncsetstring(txtCustomer.Text.Trim());
                    tbl_genCustomerMaster odetail = tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString().Trim());
                    if (odetail != null && odetail.Customer_ID != "default")
                    {
                        objRpt.DataDefinition.FormulaFields["CustomeVatNo"].Text = clsCommon.fncsetstring(odetail.VatRegistrationNo);
                        objRpt.DataDefinition.FormulaFields["CustomeSVatNo"].Text = clsCommon.fncsetstring(odetail.SvatRegistrationNo);
                    }
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

        private void print(string path, string sReportTitle, DataSet objDataSet, string sFilter, string sReportID)
        {
            try
            {
                string sHeaderTitle = "Standed Reports";// sSeperator;                

                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sReportTitle, true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("HeaderTitle", sHeaderTitle, true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqEmail", clsCommon.getCompanyEmail(), true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DateRange", "From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"), true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("UserName", clsSecurity.UserNameLoged, true);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("sReportNo", iReport.ToString(), true);

                if (sFilter != "")
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Filter", sFilter, true);

                //if (rdoTaxReportInvoice.Checked && cmbTaxType.Text.Trim() == "Export SVAT" && txtCustomer.Tag != null)

                int iRow = dgvReports.SelectedCells[0].RowIndex;
                iReport = int.Parse(dgvReports.Rows[iRow].Cells[0].Value.ToString());
                enum_ReportName Report = (enum_ReportName)iReport;
                if ((iReport == (int)enum_ReportName.ST_Tax_Report_Invoice_DetailLocalNBTVAT || iReport == (int)enum_ReportName.ST_Tax_Report_Invoice_DetailExportVAT || iReport == (int)enum_ReportName.ST_Tax_Report_Invoice_DetailExportSVAT) && cmbTaxType.Text.Trim() == "Export SVAT" && txtCustomer.Tag != null)
                {
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CustomerName", txtCustomer.Text.Trim(), true);
                    tbl_genCustomerMaster odetail = tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString().Trim());
                    if (odetail != null && odetail.Customer_ID != "default")
                    {
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CustomeVatNo", odetail.VatRegistrationNo, true);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CustomeSVatNo", odetail.SvatRegistrationNo, true);
                    }
                }

                frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                ReportViewer.print(path, objDataSet, glb_dtsReportExport.dt_rptParameter, sReportID);
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

        #endregion

        #region KeyDown Events
        private void txtJobType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterProductionJobType(ref txtJobType);
        }
        private void txtRoute_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterRoute(ref txtRoute);
        }
        private void txtSalesRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesRepID();
        }
        private void txtJobCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Job();
        }
        private void frm_rpt_ChequeManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void txtSalesNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesNoteType();
        }

        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtItemID_DoubleClick(sender, null);
            else
                clsHelpMethods_Local.SearchItemAdvanceByKeyPress(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo, e);
        }
        #endregion

        #region Events DoublClick
        private void txtJobType_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterProductionJobType(ref txtJobType);
        }
        private void txtRoute_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterRoute(ref txtRoute);
        }
        private void txtSalesRep_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesRepID();
        }
        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }
        private void txtJobCode_DoubleClick(object sender, EventArgs e)
        {
            Search_Job();
        }
        private void txtSalesNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesNoteType();
        }

        private void txtItemClass_DoubleClick(object sender, EventArgs e)
        {
            //clsSearch.Search_MasterItemClass(ref txtItemClass);
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ItemClass);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtItemClass.Tag = lstResult[0];
                txtItemClass.Text = lstResult[1];
            }

            if (txtItemClass.Tag != null)
            {
                TxtItemType.Tag = null;
                TxtItemCat.Tag = null;
                txtItemID.Tag = null;

                TxtItemType.Text = "<All Item Types>";
                TxtItemCat.Text = "<All Item Categories>";
                txtItemID.Text = "<All Items>";
            }
        }

        private void TxtItemType_DoubleClick(object sender, EventArgs e)
        {
            if (txtItemClass.Tag != null)
                clsSearch.Search_MasterItemTypeByClassID(ref TxtItemType, txtItemClass.Tag.ToString());
            else
            {
                clsSearch.Search_MasterItemType(ref TxtItemType);
                if (TxtItemType.Tag != null)
                {
                    tbl_zItemType detail = tbl_zItemType.Select(TxtItemType.Tag.ToString());
                    if (detail != null && detail.ItemType_ID != "default")
                    {
                        txtItemClass.Tag = detail.ItemClass_ID;
                        txtItemClass.Text = clsGenaralName.getName_ItemClass(detail.ItemClass_ID);
                    }
                }
            }

            if (TxtItemType.Tag != null)
            {
                TxtItemCat.Tag = null;
                txtItemID.Tag = null;

                TxtItemCat.Text = "<All Item Categories>";
                txtItemID.Text = "<All Items>";
            }
        }

        private void TxtItemCat_DoubleClick(object sender, EventArgs e)
        {
            if (TxtItemType.Tag != null)
            {
                //clsSearch.Search_MasterItemCategoryByTypeID(ref TxtItemCat, txtItemClass.Text.ToString());

                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;

                lstParameeters.Add(TxtItemType.Tag.ToString());

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.ItemCategoryIDByTypeID);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    TxtItemCat.Tag = lstResult[0];
                    TxtItemCat.Text = lstResult[1];
                }
            }
            else
            {
                //clsSearch.Search_MasterItemCategory(ref TxtItemCat);

                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;

                RowDataSearch = new frmSearch();
                List<string> lstResult = RowDataSearch.Show(Search.ItemCategory);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    TxtItemCat.Tag = lstResult[0];
                    TxtItemCat.Text = lstResult[1];
                }

                if (TxtItemCat.Tag != null)
                {
                    tbl_zItemCategory detail = tbl_zItemCategory.Select(TxtItemCat.Tag.ToString());
                    if (detail != null && detail.ItemCategory_ID != "default")
                    {
                        TxtItemType.Tag = detail.ItemType_ID;
                        TxtItemType.Text = clsGenaralName.getName_ItemClass(detail.ItemType_ID);

                        tbl_zItemType OitmType = tbl_zItemType.Select(detail.ItemType_ID);
                        if (OitmType != null && OitmType.ItemType_ID != "default")
                        {
                            txtItemClass.Tag = OitmType.ItemClass_ID;
                            txtItemClass.Text = clsGenaralName.getName_ItemClass(OitmType.ItemClass_ID);
                        }
                    }
                }
            }

            if (TxtItemCat.Tag != null)
            {
                txtItemID.Tag = null;
                txtItemID.Text = "<All Items>";
            }
        }

        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            //if (TxtItemCat.Tag != null)
            //{
            //    //clsSearch.Search_ItemMasterByCatagoryID(ref txtItemID, TxtItemCat.Text.ToString()); 

            //    List<string> lstParameeters = new List<string>();
            //    frmSearch RowDataSearch = null;

            //    //lstParameeters.Add(clsSecurity.BranchID);

            //    RowDataSearch = new frmSearch(lstParameeters);
            //    List<string> lstResult = RowDataSearch.Show(Search.ItemMasterByCatagoryID);
            //    if (RowDataSearch.DialogResult == DialogResult.OK)
            //    {
            //        txtItemID.Tag = lstResult[0];
            //        txtItemID.Text = lstResult[1];
            //    }
            //}
            //else
            //{
            //clsSearch.Search_ItemMaster(ref txtItemID);

            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = null;

            lstParameeters.Add(clsSecurity.BranchID);

            lstParameeters.Add(txtItemClass.Tag == null ? "%%" : txtItemClass.Tag.ToString());
            lstParameeters.Add(TxtItemType.Tag == null ? "%%" : TxtItemType.Tag.ToString());
            lstParameeters.Add(TxtItemCat.Tag == null ? "%%" : TxtItemCat.Tag.ToString());

            lstParameeters.Add("0");

            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.ItemMasterByCategories);
            //List<string> lstResult = RowDataSearch.Show(Search.ItemMaster);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtItemID.Tag = lstResult[0];
                txtItemID.Text = lstResult[1];
            }

            if (txtItemID.Tag != null)
            {
                tbl_genItemMaster detail = tbl_genItemMaster.Select(txtItemID.Tag.ToString());
                if (detail != null && detail.Item_ID != "default")
                {
                    TxtItemCat.Tag = detail.ItemCategory_ID;
                    TxtItemCat.Text = clsGenaralName.getName_ItemCategory(detail.ItemCategory_ID);
                    TxtItemType.Tag = detail.ItemType_ID;
                    TxtItemType.Text = clsGenaralName.getName_ItemType(detail.ItemType_ID);
                    txtItemClass.Tag = detail.ItemClass_ID;
                    txtItemClass.Text = clsGenaralName.getName_ItemClass(detail.ItemClass_ID);

                    TxtItemCat.Enabled = false;
                    TxtItemType.Enabled = false;
                    txtItemClass.Enabled = false;
                }
            }
            //}








            //   clsSearch.Search_ItemMaster(ref txtItemID);
            //    txtItemID.Text = txtItemID.Tag != null ? clsGenaralName.getName_Item(txtItemID.Tag.ToString().Trim()) : "";
        }

        private void txtBranch_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_CompanyBranch(ref txtBranch);
        }

        #endregion

        #region Set Enable/Disable Controls
        public void setEnableDisableConctrol(int iReportID)
        {
            clearField();

            if (iReportID == (int)enum_ReportName.St_DelevaryTrackingReport)
            {
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
            }
           else if (
                 iReportID == (int)enum_ReportName.St_DelevaryReport_Pending)
            {
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlCusType, false);
                clsCommon.SetVisibility_Panel(pnlItemName, false);
                clsCommon.SetVisibility_Panel(pnlSalesman, false);
                clsCommon.SetVisibility_Panel(panel9, false);

                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
            }
            else if ( iReportID == (int)enum_ReportName.St_DelevaryReport_Deleverd || iReportID == (int)enum_ReportName.St_DelevaryReport_Deleverd_Summary)
            {
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlCusType, false);
                clsCommon.SetVisibility_Panel(pnlItemName, false);
                clsCommon.SetVisibility_Panel(pnlSalesman, false);
                clsCommon.SetVisibility_Panel(panel9, false);
                clsCommon.SetVisibility_Panel(PnlDriver, true);
                clsCommon.SetVisibility_Panel(pnlDeliveryOfficer, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Monthly_Sales_Customer_Wise_Rupees || iReportID == (int)enum_ReportName.ST_MounthlySalesSummaryReport)
            {
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlZeeroHide, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Monthly_Sales_QTY_RoutWise)
            {
                clsCommon.SetVisibility_Panel(pnlCusType, false);
                clsCommon.SetVisibility_Panel(panel9, false);
                clsCommon.SetVisibility_Panel(pnlItemCat, false);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlBranch, false);
                //  clsCommon.SetVisibility_Panel(pnlRoute, true);
                    clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, false);
            }
            else if (iReportID == (int)enum_ReportName.ST_Dilivery_Listing_Report)
            {
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkIsReplasement, true);
                clsCommon.SetVisibility_Panel(pnlCurrency, true);
                clsCommon.SetVisibility_Panel(pnlJobType, true);

                cmbDOType.Visible = true;
                txtJobCode.Visible = false;
                z4.Visible = true;
            }
            else if (iReportID == (int)enum_ReportName.ST_Invoice_Listing_Report)
            {
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlCurrency, true);
                clsCommon.SetVisibility_Panel(pnlNoteType, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMasterRoute, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
                z4.Visible = true;
            }
            else if (iReportID == (int)enum_ReportName.ST_SalesReturnTrackingReport || iReportID == (int)enum_ReportName.ST_DiscountedItem)
            {
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Tax_Report_Invoice_LocalNBTVAT || iReportID == (int)enum_ReportName.ST_Tax_Report_Invoice_LocalSVAT || iReportID == (int)enum_ReportName.ST_Tax_Report_Invoice_ExportSVAT)
            {
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlTaxType, true);
                clsCommon.SetVisibility_Panel(pnlNoteType, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Tax_Report_Invoice_DetailLocalNBTVAT || iReportID == (int)enum_ReportName.ST_Tax_Report_Invoice_DetailExportVAT || iReportID == (int)enum_ReportName.ST_Tax_Report_Invoice_DetailExportSVAT)
            {
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlTaxType, true);
                clsCommon.SetVisibility_Panel(pnlNoteType, true);
                clsCommon.SetVisibility_Panel(pnlJobType, true);
                clsCommon.SetVisibility_Panel(pnlNoteType, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);

                cmbDOType.Visible = true;
                txtJobCode.Visible = false;
                z4.Visible = true;
            }
            else if (iReportID == (int)enum_ReportName.ST_SalesPriceList_MRP)
            {
                clsCommon.SetVisibility_Panel(pnlCusType, false);
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlItemCat, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, false);
            }
            else if (iReportID == (int)enum_ReportName.ST_Tax_Report_CreditNote)
            {
                clsCommon.SetVisibility_Panel(pnlTaxType, true);
                clsCommon.SetVisibility_Panel(pnlNoteType, true);
                clsCommon.SetVisibility_Panel(pnlCusName, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Svat_04)
            {
                clsCommon.SetVisibility_Panel(pnlCusType, false);
                clsCommon.SetVisibility_Panel(pnlNoteType, true);
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, false);

                txtCustomer.Text = "<All Customers>";
            }
            else if (iReportID == (int)enum_ReportName.ST_OutstandingOrders_CustomerWise)
            {
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
            }

            else if (iReportID == (int)enum_ReportName.ST_FreeItem)
            {
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlItemClass, true);
                clsCommon.SetVisibility_Panel(pnlItemCat, true);
                clsCommon.SetVisibility_Panel(pnlItemType, true);
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Monthly_Turn_Over_Statement_SalesmanWise)
            {
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlCurrency, true);
                chkReduceNBTAndVatValue.Checked = true;
                clsCommon.SetEnableDisable_NormalCheckBox(chkReduceNBTAndVatValue, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);

            }
            else if (iReportID == (int)enum_ReportName.ST_Monthly_Turn_Over_Statement_CustomerWise)
            {
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);

                chkReduceNBTAndVatValue.Checked = true;
                clsCommon.SetEnableDisable_NormalCheckBox(chkReduceNBTAndVatValue, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Sales_Report_Summary_ItemWise || iReportID == (int)enum_ReportName.ST_Sales_Report_Itemwise)
            {
                clsCommon.SetVisibility_Panel(pnlCusType, false);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_SalesReturnValue)
            {
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_SalesReport_NoteTypeWise ||
                iReportID == (int)enum_ReportName.ST_SalesReport_ItemWise_Cr
                || iReportID == (int)enum_ReportName.ST_SalesReport_SalesmanWise)
            {
                pnlUpdatedReport.Visible = true;
                chkShowShowrooms.Visible = true;
                clsCommon.SetVisibility_Panel(pnlUpdatedReport, true);

                if (iReportID != (int)enum_ReportName.ST_SalesReport_ItemWise_Cr)
                    pnl_QV.Visible = true;

                if (iReportID == (int)enum_ReportName.ST_SalesReport_ItemWise_Cr)
                {
                    clsCommon.SetVisibility_Panel(pnlShowRoom, true);
                    clsCommon.SetVisibility_Panel(pnlUpdatedReport, true);
                }

                clsCommon.SetVisibility_Panel(pnlItemClass, true);
                clsCommon.SetVisibility_Panel(pnlItemCat, true);
                clsCommon.SetVisibility_Panel(pnlItemType, true);
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlNoteType, true);

                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_SalesReport_Invoice_Wise)
            {
                clsCommon.SetVisibility_Panel(pnlItemClass, true);
                clsCommon.SetVisibility_Panel(pnlItemCat, true);
                clsCommon.SetVisibility_Panel(pnlItemType, true);
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlNoteType, true);
                clsCommon.SetVisibility_Panel(pnlUpdatedReport, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_SalesProfitability)
            {
                clsCommon.SetVisibility_Panel(pnlItemClass, true);
                clsCommon.SetVisibility_Panel(pnlItemCat, true);
                clsCommon.SetVisibility_Panel(pnlItemType, true);
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlCostPrice, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Sales_Register_Details)
            {
                clsCommon.SetVisibility_Panel(pnlItemClass, true);
                clsCommon.SetVisibility_Panel(pnlItemCat, true);
                clsCommon.SetVisibility_Panel(pnlItemType, true);
                //clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlNoteType, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_SalesReport_SalesRepWise)
            {
                clsCommon.SetVisibility_Panel(pnlCusType, false);
           
              
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMasterRoute, false);
            }
            else if (iReportID == (int)enum_ReportName.ST_SalesReport_CustomerWise_Metrix)
            {
                clsCommon.SetVisibility_Panel(pnlCusType, false);
                clsCommon.SetVisibility_Panel(pnlCusType, false);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMasterRoute, false);
            }
            else if (iReportID == (int)enum_ReportName.ST_SalesReport_RouteWise)
            {
                clsCommon.SetVisibility_Panel(pnlCusType, false);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, false);
                chkUseCustomerMasterRoute.Checked = true;
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMasterRoute, false);
            }
            else if (iReportID == (int)enum_ReportName.ST_ItemSalesReport_SalesRepWise)
            {
                clsCommon.SetVisibility_Panel(pnlCusType, false);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlSalesManager, true);
                clsCommon.SetVisibility_Panel(pnlAreaManager, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlItemClass, true);
                clsCommon.SetVisibility_Panel(pnlItemCat, true);
                clsCommon.SetVisibility_Panel(pnlItemType, true);
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMasterRoute, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_MonthlySalesCalendar_RouteSalesRepWise)
            {
                clsCommon.SetVisibility_Panel(pnlCusType, false);

                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMasterRoute, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_SalesReportGrossProfitSummery_ItemWise)
            {
                clsCommon.SetVisibility_Panel(pnlCusType, false);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlItemName, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMasterRoute, true);
            }

            else if (iReportID == (int)enum_ReportName.ST_SalesReportGrossProfitSummery_CustomerWise)
            {
                clsCommon.SetVisibility_Panel(pnlCusType, false);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMasterRoute, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_SalesReportGrossProfitSummery_SalesmanWise)
            {
                clsCommon.SetVisibility_Panel(pnlCusType, false);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMastorSaleRep, true);
                clsCommon.SetEnableDisable_NormalCheckBox(chkUseCustomerMasterRoute, true);
            }
        }
        #endregion

        #region Events Checked Change
        private void cmbTaxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTaxType.Text.Trim() == "Export SVAT")
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
            }
            else
            {
                txtCustomer.Tag = null;
                txtCustomer.Text = "<All Customers>";
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, false);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, false);
            }
        }
        //private void rdoDailySalesReport_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoConfirmedJobSummary_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoDailySalesReportSummary_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoClosedJobSummary_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingCustomerOrderSummery_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingCustomerOrderDetail_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingInquiryOrderSummery_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingInquiryOrderDetail_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingInquiryItem_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingOrderItem_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingDeliveryItem_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingDeliverySummary_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPendingDeliveryDetail_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoInvoiceDetail_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoInvoiceSummary_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoSalseRepInvoiceWise_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoTownSummery_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoRouteTownDateWise_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoTownInvoiceDateWise_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoCustomerOutstandingsSummery_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoCustomerOutstandingsDetail_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoCustomerOutstandingsLedger_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoCustomerHistoryLedger_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoItemWiseSalesReport_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoItemWiseSalesReportSummary_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPerformanceReport_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoDiliveryListing_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoInvoiceListingReport_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoTaxReportSummary_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoTaxReportInvoice_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoTaxReportCreditNote_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoTaxReportPurchase_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoOutstandingOrder_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoSalesTurnOver_Customer_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoSalesTurnOver_SalesRep_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdoPrintingBlockRegister_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        //private void rdo_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}

        //private void rdoSalesPriceList_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}

        //private void rdoDiscountedItems_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}

        //private void rdoSalesReturnValue_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}

        //private void rdoFreeItems_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}

        //private void rdoAnualSalesReport_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}

        //private void rdoSalesReportSalesmanWise_Velona_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}
        #endregion

        #region Search Methods
        private void Search_Account()
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //if (rdoReconciliatedCheques.Checked || rdoProformaInvoice.Checked)
            //{
            //    if (txtBank.Tag != null && txtBank.Tag.ToString().Length > 0)
            //        clsSearch.passValue_CompanyAccountByBankID(txtBank.Tag.ToString());
            //    else
            //        clsSearch.passValue_CompanyAccount(); 
            //}
            //else
            //{
            //    if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Length > 0)
            //        clsSearch.passValue_CustomerAccountByCustomerID(txtCustomer.Tag.ToString());
            //    else
            //        clsSearch.passValue_CustomerAccount(); 
            //}

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
            {
                //if (frmSearchTransaction.s_SearchText.Length > 0)
                //    txtAccount.Text = frmSearchTransaction.s_SearchID;
                //if (frmSearchTransaction.s_SearchID.Length > 0)
                //    txtAccount.Tag = frmSearchTransaction.s_SearchID;                
            }
        }

        #region Customer Class/ Type / Category search
        private void Search_CustomerClassID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CustomerClass();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtCusClass.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtCusClass.Tag = frmSearchMaster.s_SearchID;
        }

        private void Search_CustomerTypeID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CustomerType();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtCusType.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtCusType.Tag = frmSearchMaster.s_SearchID;
        }
        private void Search_CustomerCategoryID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CustomerCategory();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtCusCategory.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtCusCategory.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        //private void rdoSalesProfitability_CheckedChanged(object sender, EventArgs e)
        //{
        //    setEnableDisableConctrol();
        //}

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

        private void txtSalesManager_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesManagerID();
        }

        private void txtAreaManager_DoubleClick(object sender, EventArgs e)
        {
            Search_AreaManagerID();
        }

        private void txtDeliveryOfficer_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_DeleveryOfficer(ref txtDeliveryOfficer);
        }

        private void txtDriver_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_DriverID();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    tbl_zDriver detail = tbl_zDriver.Select(frmSearchMaster.s_SearchID);
                    if (detail != null)
                    {
                        txtDriver.Tag = frmSearchMaster.s_SearchID;
                        txtDriver.Text = detail.DriverName;
                        //  FillDetails(frmSearchMaster.s_SearchID);}}
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtCusClass_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerClassID();
        }

        private void txtCusType_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerTypeID();
        }

        private void txtCusCategory_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerCategoryID();
        }

        private void Search_Job()
        {
            clsSearch.Search_TransactionProductionJobRegister_Use(ref txtJobCode, true, true);
        }
        private void Search_SalesNoteType()
        {
            clsSearch.Search_MasterSalesNoteType(ref txtSalesNoteType);
        }

        #endregion

        #region Search Methods
        private void Search_CustomerID()
        {
            //Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_CustomerMaster();
            //frmhelpsearch.ShowDialog();

            //if (frmSearchMaster.s_SearchID.Length > 0)
            //{
            //    if (frmSearchMaster.s_SearchText.Length > 0)
            //        txtCustomer.Text = frmSearchMaster.s_SearchText;
            //    if (frmSearchMaster.s_SearchID.Length > 0)
            //        txtCustomer.Tag = frmSearchMaster.s_SearchID;
            //}


            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = null;

            lstParameeters.Add(clsSecurity.BranchID);

            lstParameeters.Add(txtCusClass.Tag == null ? "%%" : txtCusClass.Tag.ToString());
            lstParameeters.Add(txtCusType.Tag == null ? "%%" : txtCusType.Tag.ToString());
            lstParameeters.Add(txtCusCategory.Tag == null ? "%%" : txtCusCategory.Tag.ToString());

            if (chkShowAll.Checked)
                lstParameeters.Add("");
            else
                lstParameeters.Add("0");

            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.CustomerMaster);
            //List<string> lstResult = RowDataSearch.Show(Search.ItemMaster);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtCustomer.Tag = lstResult[0];
                txtCustomer.Text = lstResult[1];
            }

            if (txtCustomer.Tag != null)
            {
                tbl_genCustomerMaster detail = tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString());
                if (detail != null && detail.Customer_ID != "default")
                {
                    txtCusCategory.Tag = detail.CustomerCategory_ID;
                    txtCusCategory.Text = clsGenaralName.getName_CustomerCategory(detail.CustomerCategory_ID);
                    txtCusType.Tag = detail.CustomerType_ID;
                    txtCusType.Text = clsGenaralName.getName_CustomerType(detail.CustomerType_ID);
                    txtCusClass.Tag = detail.CustomerClass_ID;
                    txtCusClass.Text = clsGenaralName.getName_CustomerClass(detail.CustomerClass_ID);

                    txtCusCategory.Enabled = false;
                    txtCusType.Enabled = false;
                    txtCusClass.Enabled = false;
                }
            }
        }

        #region Search Methods
        private void Search_AreaManagerID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_AreaManager();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtAreaManager.Tag = frmSearchMaster.s_SearchID;
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtAreaManager.Text = frmSearchMaster.s_SearchText;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_SalesManagerID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_SalesManager();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtSalesManager.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtSalesManager.Tag = frmSearchMaster.s_SearchID;
            }
        }
        #endregion

        private void fillDataforDataTable(bool bIsCustomerSelected)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                glb_dtsProduction.dt_pmsOutstanding_Jobs.Rows.Clear();
                string sFilter = "", sRouteID = "";

                List<tbl_sasCustomerOrder> Query = tbl_sasCustomerOrder.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && !p.IsDeleted && p.CustomerOrder_ID != "default" &&
                    p.CustomerOrderDate.Date >= dtpFrom.Value.Date && p.CustomerOrderDate.Date <= dtpTo.Value.Date && !p.IsSeattled).ToList();

                foreach (tbl_sasCustomerOrder oCO in Query)
                {
                    string sOrderQorW = oCO.IsWeightCalculation ? "W" : "Q";
                    decimal dOrderedQty = 0;

                    bool bCustomerOK = true, bSalesRep = true;
                    if (bCustomerSelected)
                    {
                        bCustomerOK = txtCustomer.Tag.ToString().Trim() == oCO.Customer_ID ? true : false;
                    }
                    if (bSelesRepSelected)
                    {
                        tbl_zOrderRefNo detail = tbl_zOrderRefNo.Select(oCO.OrderRefNo_ID);
                        if (detail != null && detail.OrderRefNo_ID != "default")
                            bSalesRep = txtSalesRep.Tag.ToString().Trim() == detail.Employee_ID ? true : false;
                    }

                    tbl_genCustomerMaster CusDetail = tbl_genCustomerMaster.Select(oCO.Customer_ID);
                    if (CusDetail != null)
                    {
                        #region Route
                        if (bRouteSelected)
                        {
                            if (!chkUseCustomerMasterRoute.Checked)
                            {
                                sRouteID = oCO.Route_ID.ToString();
                            }
                            else
                            {
                                foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oCO.Customer_ID))
                                {
                                    sRouteID = oRoute.Route_ID.ToString();
                                    if (txtRoute.Tag.ToString() == sRouteID)
                                        break;
                                }
                            }

                            if (txtRoute.Tag.ToString() != sRouteID)
                                continue;
                        }
                        #endregion

                        if (bCustomerClassSelected)
                        {
                            if (CusDetail.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                continue;
                        }
                        if (bCustomerTypeSelected)
                        {
                            if (CusDetail.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                continue;
                        }
                        if (bCustomerCategorySelected)
                        {
                            if (CusDetail.CustomerCategory_ID != txtCusCategory.Tag.ToString().Trim())
                                continue;
                        }

                    }

                    if (bCustomerOK && bSalesRep)
                    {
                        foreach (tbl_sasCustomerOrder_Detail oCODetail in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(oCO.CustomerOrder_ID))
                            dOrderedQty = oCO.IsWeightCalculation ? oCODetail.Weight : oCODetail.Qty;

                        //foreach (tbl_pmsProductionJobRegister oJob in tbl_pmsProductionJobRegister.SelectAllByCustomerOrder_ID(oCO.CustomerOrder_ID).Where(p => !p.IsDeleted && p.ProductionJob_ID != "default"))
                        //{
                        //    decimal dStanderdWeight = clsHelpMethods_Local.GetJobStandardWeightBy_SalesJobID(oCO.Job_ID);
                        //    decimal dProductionWegiht = 0, dProductionQty = 0, dDeliveryQty = 0, dSRNQty = 0;
                        //    string dProductionUOM = "N/A";
                        //    string sItemSize = clsHelpMethods_Local.GetItemSizeByItemID(oJob.Item_ID);

                        //    foreach (tbl_sasDeliveryOrder oDo in tbl_sasDeliveryOrder.SelectAllByJob_ID(oJob.ProductionJob_ID).Where(p => !p.IsDeleted && p.DeliveryOrder_ID != "default"))
                        //    {
                        //        foreach (tbl_sasDeliveryOrder_Detail oDoDetail in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDo.DeliveryOrder_ID))
                        //            dDeliveryQty = oDo.IsWeightCalculation ? oDoDetail.Weight : oDoDetail.Qty;

                        //        foreach (tbl_sasSalesReturnedNote oSRN in tbl_sasSalesReturnedNote.SelectAllByDeliveryOrder_ID(oDo.DeliveryOrder_ID).Where(p => !p.IsDeleted && p.DeliveryOrder_ID != "default"))
                        //        {
                        //            foreach (tbl_sasSalesReturnedNote_Detail oSRNDetail in tbl_sasSalesReturnedNote_Detail.SelectAllByDeliveryOrder_ID(oDo.DeliveryOrder_ID))
                        //                dSRNQty = oDo.IsWeightCalculation ? oSRNDetail.Weight : oSRNDetail.Qty;
                        //        }
                        //    }

                        //    foreach (tbl_pmsWorkInProgress oWIP in tbl_pmsWorkInProgress.SelectAllByProductionJob_ID(oJob.ProductionJob_ID).Where(p => !p.IsDeleted && p.WorkInProgress_ID != "default"))
                        //    {
                        //        foreach (tbl_pmsWorkInProgress_Machine_Shedule_OutputItem oWIPDetail in tbl_pmsWorkInProgress_Machine_Shedule_OutputItem.SelectAllByWorkInProgress_ID(oWIP.WorkInProgress_ID).Where(p => p.Item_ID == oJob.Item_ID))
                        //        {
                        //            dProductionWegiht += oWIPDetail.WeighOut;
                        //            dProductionQty += oWIPDetail.Qty;
                        //            dProductionUOM = clsGenaralName.getName_Uom(oWIPDetail.UomLength_ID);
                        //        }
                        //    }

                        //    glb_dtsProduction.dt_pmsOutstanding_Jobs.Rows.Add(oJob.ProductionJob_ID, oCO.DeliveryDate, oCO.DeliveryDate, oCO.CustomerOrderDate, oCO.PurchaseOrder_ID,
                        //    oJob.Item_ID, clsGenaralName.getName_Item(oJob.Item_ID), dOrderedQty, sOrderQorW, dSRNQty, sOrderQorW, dStanderdWeight, dProductionWegiht, dProductionUOM, dProductionQty, dDeliveryQty,
                        //    sOrderQorW, oCO.Customer_ID, clsGenaralName.getName_Customer(oCO.Customer_ID), sItemSize);
                        //}
                 
                    }
                    clsHelpMethods_Local.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
                }

                print("\\Reports\\SAS\\Standard\\rpt_sasOutstandingOrder_CustomerWise.rpt", "Outstanding Order Report (Customer-Wise)", glb_dtsProduction.dt_pmsOutstanding_Jobs, sFilter);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
                glb_dtsProduction.dt_pmsOutstanding_Jobs.Rows.Clear();
            }
            //}

        }
        #endregion

        #region Create Data Tables
        private void CreateDataTable_Detail()
        {
            dtAllDetailRecodes.Columns.Clear();
            dtAllDetailRecodes.Columns.Add("TransactionDate", typeof(DateTime));
            dtAllDetailRecodes.Columns.Add("SubTotal", typeof(double));
            dtAllDetailRecodes.Columns.Add("NbtAmount", typeof(double));
            dtAllDetailRecodes.Columns.Add("WithNbtAmount", typeof(double));
            dtAllDetailRecodes.Columns.Add("VatAmount", typeof(double));
            dtAllDetailRecodes.Columns.Add("TransactionType", typeof(string));
        }
        #endregion

        #region Calculate Total Sales
        private void calculateTotalSales(int iType)
        {
            decimal d1 = 0, d2 = 0, d3 = 0, d4 = 0, d5 = 0, d6 = 0, d7 = 0, d8 = 0, d9 = 0, d10 = 0, d11 = 0, d12 = 0;

            //add by janith - 2017-10-31
            List<tbl_genCustomerMaster> Query = null;
            if (bCustomerSelected)
                Query = tbl_genCustomerMaster.SelectAll().Where(p => p.Customer_ID == txtCustomer.Tag.ToString() && p.Customer_ID != "default").ToList();
            else
                Query = tbl_genCustomerMaster.SelectAll().Where(p => p.Customer_ID != "default").ToList();

            decimal dCurrencyRate = 0;

            foreach (tbl_genCustomerMaster CusDetail in Query)
            {
                foreach (tbl_sasInvoice detail in tbl_sasInvoice.SelectAllByCustomer_ID(CusDetail.Customer_ID).Where(p => !p.IsDeleted && p.Invoice_ID != "default" &&
                    p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date && !p.IsOpeningBalance && !p.IsReturnedCheque && !p.IsDebitNote
                    // && p.InvoiceDate.Year == dtpYear.Value.Year      && (bIsRupees  p.Currency_ID == clsConfig.sLocalCurrencyCode
                    ))
                {
                    bool bCurrencyOK = true;

                    if (iType == 1)//rupees
                        bCurrencyOK = detail.Currency_ID == clsConfig.sLocalCurrencyCode ? true : false;
                    else if (iType == 2)//dollers
                        bCurrencyOK = detail.Currency_ID != clsConfig.sLocalCurrencyCode ? true : false;

                    dCurrencyRate = (iType == 3) ? 1 : detail.CurrencyRate;

                    if (bCurrencyOK)
                    {
                        if (detail.InvoiceDate.Month == 1)
                            d1 += (detail.GrandTotal / dCurrencyRate);
                        else if (detail.InvoiceDate.Month == 2)
                            d2 += detail.GrandTotal / dCurrencyRate;
                        else if (detail.InvoiceDate.Month == 3)
                            d3 += detail.GrandTotal / dCurrencyRate;
                        else if (detail.InvoiceDate.Month == 4)
                            d4 += detail.GrandTotal / dCurrencyRate;
                        else if (detail.InvoiceDate.Month == 5)
                            d5 += detail.GrandTotal / dCurrencyRate;
                        else if (detail.InvoiceDate.Month == 6)
                            d6 += detail.GrandTotal / dCurrencyRate;
                        else if (detail.InvoiceDate.Month == 7)
                            d7 += detail.GrandTotal / dCurrencyRate;
                        else if (detail.InvoiceDate.Month == 8)
                            d8 += detail.GrandTotal / dCurrencyRate;
                        else if (detail.InvoiceDate.Month == 9)
                            d9 += detail.GrandTotal / dCurrencyRate;
                        else if (detail.InvoiceDate.Month == 10)
                            d10 += detail.GrandTotal / dCurrencyRate;
                        else if (detail.InvoiceDate.Month == 11)
                            d11 += detail.GrandTotal / dCurrencyRate;
                        else if (detail.InvoiceDate.Month == 12)
                            d12 += detail.GrandTotal / dCurrencyRate;
                    }
                }
                if (!(d1 == 0 && d2 == 0 && d3 == 0 && d4 == 0 && d5 == 0 && d6 == 0 && d7 == 0 && d8 == 0 && d9 == 0 && d10 == 0 && d11 == 0 && d12 == 0))
                {
                    glb_dtMonthlySales.Rows.Add(d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12, CusDetail.CustomerName);
                    d1 = 0; d2 = 0; d3 = 0; d4 = 0; d5 = 0; d6 = 0; d7 = 0; d8 = 0; d9 = 0; d10 = 0; d11 = 0; d12 = 0;
                }
                clsHelpMethods_Local.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
            }
        }
        #endregion

        //private decimal getCostPrice(string sItemCode, string sSubCategory1, string sSubCategory2, string sSerial1, string sSerial2)
        //{
        //    decimal dValue = 0;
        //    if (cmbCostPrice.SelectedIndex == 1)
        //        dValue = clsProcessMethods.GetCostPrice_ByCostType(sItemCode, sSubCategory1, sSubCategory2, sSerial1, sSerial2, enum_CostPriceType.WeightedAverage);
        //    if (cmbCostPrice.SelectedIndex == 2)
        //        dValue = clsProcessMethods.GetCostPrice_ByCostType(sItemCode, sSubCategory1, sSubCategory2, sSerial1, sSerial2, enum_CostPriceType.LIFO);
        //    if (cmbCostPrice.SelectedIndex == 3)
        //        dValue = clsProcessMethods.GetCostPrice_ByCostType(sItemCode, sSubCategory1, sSubCategory2, sSerial1, sSerial2, enum_CostPriceType.FIFO);
        //    if (cmbCostPrice.SelectedIndex == 4)
        //        dValue = clsProcessMethods.GetCostPrice_ByCostType(sItemCode, sSubCategory1, sSubCategory2, sSerial1, sSerial2, enum_CostPriceType.HighestPurchaseCost);
        //    if (cmbCostPrice.SelectedIndex == 5)
        //        dValue = clsProcessMethods.GetCostPrice_ByCostType(sItemCode, sSubCategory1, sSubCategory2, sSerial1, sSerial2, enum_CostPriceType.LovestPurchaseCost);
        //    if (cmbCostPrice.SelectedIndex == 6)
        //        dValue = clsProcessMethods.GetCostPrice_ByCostType(sItemCode, sSubCategory1, sSubCategory2, sSerial1, sSerial2, enum_CostPriceType.CostPrice1);
        //    if (cmbCostPrice.SelectedIndex == 7)
        //        dValue = clsProcessMethods.GetCostPrice_ByCostType(sItemCode, sSubCategory1, sSubCategory2, sSerial1, sSerial2, enum_CostPriceType.CostPrice2);

        //    return dValue;
        //}

        public void SetParameeters(DateTime dtmFrom, DateTime dtmTo)
        {
            dtpFrom.Value = dtmFrom;
            dtpTo.Value = dtmTo;
        }

        public void setReport(enum_ReportName enmRpt)
        {
            //if (enmRpt == enum_ReportName.ST_SalesReport_Invoice_Wise)
            //    rdoSalesReport_invoiceWise.Checked = true;
        }

    }
    class SalesReport
    {
        public string TransactionType;
        public string TransactionID;
        public DateTime TransactionDate;
        public string SalesNote_Type;
        public string Salesrep_Id;
        public string Customer_Id;
        public string item_Id;
        public string ItemCatagort_Id;
        public decimal Ammount;

        public SalesReport(string TransactionType, string TransactionID, DateTime TransactionDate, string SalesNote_Type, string Salesrep_Id, string Customer_Id, string item_Id, string ItemCatagort_Id, decimal Ammount)
        {
            this.TransactionType = TransactionType;
            this.TransactionID = TransactionID;
            this.TransactionDate = TransactionDate;
            this.SalesNote_Type = SalesNote_Type;
            this.Salesrep_Id = Salesrep_Id;
            this.Customer_Id = Customer_Id;
            this.item_Id = item_Id;
            this.ItemCatagort_Id = ItemCatagort_Id;
            this.Ammount = Ammount;
        }
    }
}

#region Sales Reports Sales Rep wise - Indika
//else if (Report == enum_ReportName.ST_SalesReport_SalesRepWise)
//{
//    try
//    {
//        glb_dtsSales.Clear();

//        List<tbl_sasInvoice> oInvoices = tbl_sasInvoice.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => !p.IsDeleted && !p.IsOpeningBalance && !p.IsReturnedCheque && !p.IsDebitNote && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date).ToList();
//        List<tbl_bpsCreditNote> CRNs = tbl_bpsCreditNote.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && !p.IsDeleted && p.CreditNoteType_ID != "default" && p.PosReturnTransaction_Index == -1 && p.CreditNoteDate.Date >= dtpFrom.Value.Date && p.CreditNoteDate.Date <= dtpTo.Value.Date).ToList();

//        string sSalesmanID = "", sSalesmanName = "";

//        #region inv
//        foreach (tbl_sasInvoice oInvoice in oInvoices)
//        {
//            #region Sales Rep Filter                                           
//            if (!chkUseCustomerMastorSaleRep.Checked)
//            {
//                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
//                if (oRef != null && oRef.OrderRefNo != "default")
//                    sSalesmanID = oRef.Employee_ID;
//            }
//            else
//            {
//                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
//                if (oCustomer != null)
//                    sSalesmanID = oCustomer.SalesRep_ID;
//            }

//            if (bSelesRepSelected)
//                if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                    continue;

//            sSalesmanName = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID);
//            #endregion

//            glb_dtsSales.dt_sasSalesReport.Adddt_sasSalesReportRow("", oInvoice.Invoice_ID, oInvoice.InvoiceDate, "", "", "", "", sSalesmanID, sSalesmanName, oInvoice.GrandTotal, 0, 0);

//        }
//        #endregion

//        #region CRN
//        foreach (tbl_bpsCreditNote oCRN in CRNs)
//        {
//            #region Sales Rep Filter                                            
//            if (!chkUseCustomerMastorSaleRep.Checked)
//            {
//                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oCRN.OrderRefNo_ID);
//                if (oRef != null && oRef.OrderRefNo != "default")
//                    sSalesmanID = oRef.Employee_ID;
//            }
//            else
//            {
//                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oCRN.Customer_ID);
//                if (oCustomer != null)
//                    sSalesmanID = oCustomer.SalesRep_ID;
//            }

//            if (bSelesRepSelected)
//                if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                    continue;

//            sSalesmanName = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID);
//            #endregion

//            // Sales Return Credit Notes
//            if (oCRN.CreditNoteType_ID == "TP/002")
//                glb_dtsSales.dt_sasSalesReport.Adddt_sasSalesReportRow("2", oCRN.CreditNote_ID, oCRN.CreditNoteDate, "", "", "", "", sSalesmanID, sSalesmanName, 0, oCRN.TotalAmount, 0);

//            //Others
//            else
//                glb_dtsSales.dt_sasSalesReport.Adddt_sasSalesReportRow("3", oCRN.CreditNote_ID, oCRN.CreditNoteDate, "", "", "", "", sSalesmanID, sSalesmanName, 0, 0, oCRN.TotalAmount);

//        }
//        #endregion

//        glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDateRange, clsSecurity.UserNameLoged, sFilter);

//        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
//        rpt.print(sReportPath, glb_dtsSales, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));

//    }
//    catch (Exception ex)
//    {
//        clsValidate.WriteErrorLog("", iFormID, ex);
//        SEACCException.Show(ex);
//    }
//    finally
//    {
//        Cursor = Cursors.Default;
//        glb_dtsReportExport.Clear();
//        glb_dts_sasSales_NoteTypeWise_ItemCategoryWise.Clear();
//    }
//}
#endregion