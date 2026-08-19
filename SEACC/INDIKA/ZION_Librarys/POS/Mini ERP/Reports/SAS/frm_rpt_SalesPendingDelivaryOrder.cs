using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic;
using System.Text;
using DataTire;
using System.Windows.Forms;
using System.Data.SqlClient;
using Digiteq.DataSets.SAS;
using Digiteq.DataSets;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Digiteq
{
    public partial class frm_rpt_SalesPendingDelivaryOrder : MettroForm
    {

        #region Variables
        //form manage
        public int iFormID;

        //for security handle
        public bool bNoAccess;
        bool bCustomerSelected = false, bSelesRepSelected = false, bItemSelected = false, bTownSelected = false, bRouteSelected = false;
        dts_sasCustomerOrder glb_dts_sasCustomerOrder = new dts_sasCustomerOrder();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        #endregion

        #region Form Load
        public frm_rpt_SalesPendingDelivaryOrder()
        {
            iFormID = clsSecurity.getFormID(FormName.ReportSalesPendingOrder);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }

        private void frmReportChequeDeposit_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, clsHelpMethods.getFormName(iFormID), 2, iFormID);
            ThemeColor = clsFormatter.colorSales;

            clearField();
        }
        #endregion

        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string sFilter = "";
            //get selection controls
            bCustomerSelected = false; bSelesRepSelected = false; bItemSelected = false; bTownSelected = false; bRouteSelected = false;
            string sFormula = "";
            if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Trim().Length > 0)
                bCustomerSelected = true;
            if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Trim().Length > 0)
                bSelesRepSelected = true;
            if (txtItem.Tag != null && txtItem.Tag.ToString().Trim().Length > 0)
                bItemSelected = true;
            if (txtTown.Tag != null && txtTown.Tag.ToString().Trim().Length > 0)
                bTownSelected = true;
            if (txtRoute.Tag != null && txtRoute.Tag.ToString().Trim().Length > 0)
                bRouteSelected = true;

            #region Selected Filters
            if (bItemSelected)
                sFilter += " Item Name : " + txtItem.Text.Trim();
            #endregion

            #region Commented
            //            if (rdoPendingInquiryOrderSummery.Checked)
            //{
            //    sFormula = " {vw_rpt_sasInquiry.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasInquiry.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
            //    sFormula += " and {vw_rpt_sasInquiry.isSeattled} = false ";
            //    if (bCustomerSelected)
            //        sFormula += "and {vw_rpt_sasInquiry.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";
            //    if (bSelesRepSelected)
            //        sFormula += " and {vw_rpt_sasInquiry.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
            //    if (bTownSelected)
            //        sFormula += " and {vw_rpt_sasInquiry.town_ID} = '" + txtTown.Tag.ToString().Trim() + "'";
            //    if (bRouteSelected)
            //        sFormula += " and {vw_rpt_sasInquiry.route_ID} = '" + txtRoute.Tag.ToString().Trim() + "'";
            //    if (clsConfig.bApprovalEnabledInquiry)
            //        sFormula += " and {vw_rpt_sasInquiry.isApproved} = true ";


            //    print("\\reports\\SAS\\Commen\\rpt_sas_Inquiry_Summery.rpt", " Pending Order Summary ", sFormula);
            //}
            //else if (rdoPendingInquiryOrderDetail.Checked)
            //{
            //    sFormula = " {vw_rpt_sasInquiry.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasInquiry.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'and {vw_rpt_sasInquiry_Detail.qtySettle} < {vw_rpt_sasInquiry_Detail.qty}";
            //    sFormula += " and {vw_rpt_sasInquiry.isSeattled} = false ";
            //    if (bCustomerSelected)
            //        sFormula += "and {vw_rpt_sasInquiry.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";
            //    if (bSelesRepSelected)
            //        sFormula += " and {vw_rpt_sasInquiry.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
            //    if (bTownSelected)
            //        sFormula += " and {vw_rpt_sasInquiry.town_ID} = '" + txtTown.Tag.ToString().Trim() + "'";
            //    if (bRouteSelected)
            //        sFormula += " and {vw_rpt_sasInquiry.route_ID} = '" + txtRoute.Tag.ToString().Trim() + "'";
            //    if (clsConfig.bApprovalEnabledInquiry)
            //        sFormula += " and {vw_rpt_sasInquiry.isApproved} = true ";

            //    print("\\reports\\SAS\\Pending\\rpt_sas_Inquiry_Detail.rpt", " Pending Order Detail ", sFormula);
            //}
            //else if (rdoPendingInquiryItem.Checked)
            //{
            //    sFormula = " {vw_rpt_sasInquiry.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasInquiry.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") +"'";
            //    sFormula += " and {vw_rpt_sasInquiry.isSeattled} = false ";
            //    if (bCustomerSelected)
            //        sFormula += "and {vw_rpt_sasInquiry.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";
            //    if (bSelesRepSelected)
            //        sFormula += " and {vw_rpt_sasInquiry.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
            //    if (bTownSelected)
            //        sFormula += " and {vw_rpt_sasInquiry.town_ID} = '" + txtTown.Tag.ToString().Trim() + "'";
            //    if (bRouteSelected)
            //        sFormula += " and {vw_rpt_sasInquiry.route_ID} = '" + txtRoute.Tag.ToString().Trim() + "'";
            //    if (clsConfig.bApprovalEnabledInquiry)
            //        sFormula += " and {vw_rpt_sasInquiry.isApproved} = true ";

            //    print("\\reports\\SAS\\Pending\\rpt_sas_Inquiry_Item.rpt", " Pending Order Item ", sFormula);
            //}
            //else if (rdoPendingDeliverySummary.Checked)
            //{
            //    sFormula = " {vw_rpt_sasDeliveryOrder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasDeliveryOrder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
            //    sFormula += " and {vw_rpt_sasDeliveryOrder.isSeattled} = false ";
            //    if (bCustomerSelected)
            //        sFormula += "and {vw_rpt_sasDeliveryOrder.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";
            //    if (bSelesRepSelected)
            //        sFormula += " and {vw_rpt_sasDeliveryOrder.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
            //    if (bTownSelected)
            //        sFormula += " and {vw_rpt_sasDeliveryOrder.town_ID} = '" + txtTown.Tag.ToString().Trim() + "'";
            //    if (bRouteSelected)
            //        sFormula += " and {vw_rpt_sasDeliveryOrder.route_ID} = '" + txtRoute.Tag.ToString().Trim() + "'";
            //    if (clsConfig.bApprovalEnabledDeliveryOrder)
            //        sFormula += " and {vw_rpt_sasDeliveryOrder.isApproved} = true ";

            //    print("\\reports\\SAS\\Commen\\rpt_sas_DeliveryOrder_Summery.rpt", "Pending Invoice Summary ", sFormula);
            //}
            //else if (rdoPendingDeliveryDetail.Checked)
            //{
            //    sFormula = " {vw_rpt_sasDeliveryOrder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasDeliveryOrder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'and {vw_rpt_sasDeliveryOrder_Detail.qtySettle} < {vw_rpt_sasDeliveryOrder_Detail.qty}";
            //    sFormula += " and {vw_rpt_sasDeliveryOrder.isSeattled} = false ";
            //    if (bCustomerSelected)
            //        sFormula += "and {vw_rpt_sasDeliveryOrder.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";
            //    if (bSelesRepSelected)
            //        sFormula += " and {vw_rpt_sasDeliveryOrder.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
            //    if (bTownSelected)
            //        sFormula += " and {vw_rpt_sasDeliveryOrder.town_ID} = '" + txtTown.Tag.ToString().Trim() + "'";
            //    if (bRouteSelected)
            //        sFormula += " and {vw_rpt_sasDeliveryOrder.route_ID} = '" + txtRoute.Tag.ToString().Trim() + "'";
            //    if (clsConfig.bApprovalEnabledDeliveryOrder)
            //        sFormula += " and {vw_rpt_sasDeliveryOrder.isApproved} = true ";

            //    print("\\reports\\SAS\\Pending\\rpt_sas_DeliveryOrder_Detail.rpt", " Pending Invoice Detail ", sFormula);
            //}
            //else if (rdoPendingDeliveryItem.Checked)
            //{
            //    sFormula = " {vw_rpt_sasDeliveryOrder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasDeliveryOrder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'and {vw_rpt_sasDeliveryOrder_Detail.qtySettle} < {vw_rpt_sasDeliveryOrder_Detail.qty}";
            //    sFormula += " and {vw_rpt_sasDeliveryOrder.isSeattled} = false ";
            //    if (bCustomerSelected)
            //        sFormula += "and {vw_rpt_sasDeliveryOrder.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";
            //    if (bSelesRepSelected)
            //        sFormula += " and {vw_rpt_sasDeliveryOrder.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
            //    if (bTownSelected)
            //        sFormula += " and {vw_rpt_sasDeliveryOrder.town_ID} = '" + txtTown.Tag.ToString().Trim() + "'";
            //    if (bRouteSelected)
            //        sFormula += " and {vw_rpt_sasDeliveryOrder.route_ID} = '" + txtRoute.Tag.ToString().Trim() + "'";
            //    if (clsConfig.bApprovalEnabledDeliveryOrder)
            //        sFormula += " and {vw_rpt_sasDeliveryOrder.isApproved} = true ";

            //    print("\\reports\\SAS\\Pending\\rpt_sas_DeliveryOrder_Item.rpt", " Pending Invoice Item ", sFormula);
            //}
            #endregion

            if (rdoPendingCustomerOrderSummery.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_PendingDeliverySummary_TownWise)))
                {
                    sFormula = " {vw_rpt_sasCustomerOrder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasCustomerOrder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'";
                    sFormula += " and {vw_rpt_sasCustomerOrder.isSeattled} = false and {vw_rpt_sasCustomerOrder.isDeleted} = false ";
                    if (bCustomerSelected)
                        sFormula += "and {vw_rpt_sasCustomerOrder.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";
                    if (bSelesRepSelected)
                        sFormula += " and {vw_rpt_sasCustomerOrder.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
                    if (bTownSelected)
                        sFormula += " and {vw_rpt_sasCustomerOrder.town_ID} = '" + txtTown.Tag.ToString().Trim() + "'";
                    if (bRouteSelected)
                        sFormula += " and {vw_rpt_sasCustomerOrder.route_ID} = '" + txtRoute.Tag.ToString().Trim() + "'";
                    if (clsConfig.bApprovalEnabledCustomerOrder)
                        sFormula += " and {vw_rpt_sasCustomerOrder.isApproved} = true ";

                    print("\\reports\\SAS\\Pending\\rpt_sas_CustomerOrder_Summary.rpt", "Pending Delivery Summary - Town Wise", sFormula);
                }
            }
            else if (rdoPendingCustomerOrderDetailTown.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Pending_Delivery_Details_TownWise)))
                {
                    sFormula = " {vw_rpt_sasCustomerOrder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasCustomerOrder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'and {vw_rpt_sasCustomerOrder_Detail.qtySettle} < {vw_rpt_sasCustomerOrder_Detail.qty}";
                    sFormula += " and {vw_rpt_sasCustomerOrder.isSeattled} = false and {vw_rpt_sasCustomerOrder.isDeleted} = false ";
                    if (bCustomerSelected)
                        sFormula += "and {vw_rpt_sasCustomerOrder.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";
                    if (bSelesRepSelected)
                        sFormula += " and {vw_rpt_sasCustomerOrder.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
                    if (bTownSelected)
                        sFormula += " and {vw_rpt_sasCustomerOrder.town_ID} = '" + txtTown.Tag.ToString().Trim() + "'";
                    if (bRouteSelected)
                        sFormula += " and {vw_rpt_sasCustomerOrder.route_ID} = '" + txtRoute.Tag.ToString().Trim() + "'";
                    if (clsConfig.bApprovalEnabledCustomerOrder)
                        sFormula += " and {vw_rpt_sasCustomerOrder.isApproved} = true ";

                    print("\\reports\\SAS\\Pending\\rpt_sas_CustomerOrder_Detail_Town.rpt", " Pending Delivery Detail - Town Wise", sFormula);
                }
            }
            else if (rdoPendingCustomerOrderDetailDate.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Pending_Delivery_Item_Datewise)))
                {
                    sFormula = " {vw_rpt_sasCustomerOrder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasCustomerOrder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'and {vw_rpt_sasCustomerOrder_Detail.qtySettle} < {vw_rpt_sasCustomerOrder_Detail.qty}";
                    sFormula += " and {vw_rpt_sasCustomerOrder.isSeattled} = false  and {vw_rpt_sasCustomerOrder.isDeleted} = false ";
                    if (bCustomerSelected)
                        sFormula += "and {vw_rpt_sasCustomerOrder.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";
                    if (bSelesRepSelected)
                        sFormula += " and {vw_rpt_sasCustomerOrder.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
                    if (bTownSelected)
                        sFormula += " and {vw_rpt_sasCustomerOrder.town_ID} = '" + txtTown.Tag.ToString().Trim() + "'";
                    if (bRouteSelected)
                        sFormula += " and {vw_rpt_sasCustomerOrder.route_ID} = '" + txtRoute.Tag.ToString().Trim() + "'";
                    if (clsConfig.bApprovalEnabledCustomerOrder)
                        sFormula += " and {vw_rpt_sasCustomerOrder.isApproved} = true ";

                    print("\\reports\\SAS\\Pending\\rpt_sas_CustomerOrder_Detail_Date.rpt", " Pending Delivery Detail - Date Wise", sFormula);
                }
            }
            else if (rdoPendingOrderItem.Checked)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Pending_Delivery_ItemforCustomers)))
                {
                    sFormula = " {vw_rpt_sasCustomerOrder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasCustomerOrder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'and {vw_rpt_sasCustomerOrder_Detail.qtySettle} < {vw_rpt_sasCustomerOrder_Detail.qty}";
                    sFormula += " and {vw_rpt_sasCustomerOrder.isSeattled} = false and {vw_rpt_sasCustomerOrder.isDeleted} = false ";
                    if (bCustomerSelected)
                        sFormula += "and {vw_rpt_sasCustomerOrder.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";
                    if (bSelesRepSelected)
                        sFormula += " and {vw_rpt_sasCustomerOrder.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
                    if (bTownSelected)
                        sFormula += " and {vw_rpt_sasCustomerOrder.town_ID} = '" + txtTown.Tag.ToString().Trim() + "'";
                    if (bRouteSelected)
                        sFormula += " and {vw_rpt_sasCustomerOrder.route_ID} = '" + txtRoute.Tag.ToString().Trim() + "'";
                    if (clsConfig.bApprovalEnabledCustomerOrder)
                        sFormula += " and {vw_rpt_sasCustomerOrder.isApproved} = true ";

                    print("\\reports\\SAS\\Pending\\rpt_sas_CustomerOrder_Item.rpt", " Pending Delivery Item For Customers", sFormula);
                }
            }
            else if (rdoPendingOrderItemSummary.Checked)
            {
                #region Old View
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Pending_Delivery_Item_Summary)))
                {
                    sFormula = " {vw_rpt_sasCustomerOrder.p_Date} >= '" + dtpFrom.Value.Year.ToString() + dtpFrom.Value.Month.ToString("00") + dtpFrom.Value.Day.ToString("00") + "'" + " and {vw_rpt_sasCustomerOrder.p_Date} <= '" + dtpTo.Value.Year.ToString() + dtpTo.Value.Month.ToString("00") + dtpTo.Value.Day.ToString("00") + "'and {vw_rpt_sasCustomerOrder_Detail.qtySettle} < {vw_rpt_sasCustomerOrder_Detail.qty}";
                    sFormula += " and {vw_rpt_sasCustomerOrder.isSeattled} = false  and {vw_rpt_sasCustomerOrder.isDeleted} = false ";
                    if (bCustomerSelected)
                        sFormula += "and {vw_rpt_sasCustomerOrder.customer_ID} = '" + txtCustomer.Tag.ToString().Trim() + "'";
                    if (bSelesRepSelected)
                        sFormula += " and {vw_rpt_sasCustomerOrder.employee_ID} = '" + txtSalesRep.Tag.ToString().Trim() + "'";
                    if (bItemSelected)
                        sFormula += "and {vw_rpt_sasCustomerOrder_Detail.item_ID} = '" + txtItem.Tag.ToString().Trim() + "'";
                    if (bTownSelected)
                        sFormula += " and {vw_rpt_sasCustomerOrder.town_ID} = '" + txtTown.Tag.ToString().Trim() + "'";
                    if (bRouteSelected)
                        sFormula += " and {vw_rpt_sasCustomerOrder.route_ID} = '" + txtRoute.Tag.ToString().Trim() + "'";
                    if (clsConfig.bApprovalEnabledCustomerOrder)
                        sFormula += " and {vw_rpt_sasCustomerOrder.isApproved} = true ";

                    print("\\reports\\SAS\\Pending\\rpt_sas_CustomerOrder_Item_Summary.rpt", " Pending Delivery Item Summary", sFormula);
                }
                #endregion

                #region Dataset
                //try
                //{
                //    glb_dts_sasCustomerOrder.Clear();
                //    glb_dtsReportExport.Clear();
                //    Cursor = Cursors.WaitCursor;
                //    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.RG_Pending_Delivery_Item_Summary)))
                //    {
                //        string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "", sSalesmanID = "", sSubCategory = "";
                //        string sDaterange = "From  : " + dtpFrom.Value.Date.ToString("dd-MMM-yyyy") + " TO : " + dtpTo.Value.Date.ToString("dd-MMM-yyyy");
                //        if (clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.RG_Pending_Delivery_Item_Summary), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                //        {
                //            foreach (tbl_sasCustomerOrder oCusOrder in tbl_sasCustomerOrder.SelectAll().Where(p => p.CustomerOrder_ID != "default" && !p.IsDeleted && p.CustomerOrderDate >= dtpFrom.Value.Date && p.CustomerOrderDate <= dtpTo.Value.Date))
                //            {
                //                glb_dts_sasCustomerOrder.dt_sasCustomerOrder.Adddt_sasCustomerOrderRow(oCusOrder.CustomerOrder_ID, oCusOrder.CustomerOrderDate, DateTime.MinValue, "", "", clsGenaralName.getName_Customer(oCusOrder.Customer_ID), "", "", 0, 1, "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, "", "", "", 0, 0, 0, 0, "", "", false, false, false, false, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");


                //                foreach (tbl_sasCustomerOrder_Detail oCusDetail in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(oCusOrder.CustomerOrder_ID))
                //                {
                //                    if (bItemSelected)
                //                        if (oCusDetail.Item_ID != txtItem.Tag.ToString())
                //                            continue;
                //                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oCusDetail.Item_ID);
                //                    if (oItem != null)

                //                        glb_dts_sasCustomerOrder.dt_sasCustomerOrderDetail.Adddt_sasCustomerOrderDetailRow(oCusDetail.CustomerOrder_ID, oCusDetail.Item_ID, clsGenaralName.getName_Item(oCusDetail.Item_ID), oCusDetail.Qty, 0, 0, false, 0, 0, "", 0, "", 0, 0, 0, clsGenaralName.getName_Uom(oItem.Uom_ID), 0, 0, oCusDetail.ItemSubCategory_ID, "");

                //                }
                //            }

                //            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("SubCategory", clsConfig.sItemSubCategory, true);

                //            glb_dts_sasCustomerOrder.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, sReportTitle_Sub, sDaterange, clsSecurity.UserNameLoged, sFilter);
                //            frm_ReportViewer_New rpt = new frm_ReportViewer_New();

                //            rpt.print(sReportPath, glb_dts_sasCustomerOrder, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.RG_Pending_Delivery_Item_Summary));
                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //    SEACCException.Show(ex);
                //}
                //finally
                //{
                //    glb_dts_sasCustomerOrder.Clear();
                //    glb_dtsReportExport.Clear();
                //    Cursor = Cursors.Default;
                //}
                #endregion
            }

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
            txtCustomer.Tag = null;
            txtSalesRep.Tag = null;
            txtTown.Tag = null;
            txtRoute.Tag = null;
            txtItem.Tag = null;

            txtCustomer.Text = "<All Customers>";
            txtSalesRep.Text = "<All SalesReps>";
            txtRoute.Text = "<All Routes>";
            txtTown.Text = "<All Towns>";
            txtTown.Text = "<All Items>";

            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, false);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomer, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItem, false);
            clsCommon.SetEnableDisable_NormalLabel(lblItem, false);
            txtItem.Visible = false;
            lblItem.Visible = false;
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, false);
            clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtTown, false);
            clsCommon.SetEnableDisable_NormalLabel(lblTown, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, false);
            clsCommon.SetEnableDisable_NormalLabel(lblRoute, false);

            setEnableDisableConctrol();
        }
        #endregion

        #region Print Method
        private void print(string path, string sReportTitle, string sFormula)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Standard Reports";
                ReportDocument RD = new ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                frm_ReportViewer viewer = new frm_ReportViewer();
                RD.Load(s_Path);
                clsSecurity.LogonServer(ref RD);
                RD.Refresh();

                if (rdoPendingOrderItem.Checked || rdoPendingOrderItemSummary.Checked || rdoPendingCustomerOrderDetailDate.Checked || rdoPendingCustomerOrderDetailTown.Checked)
                {
                    //if (bCustomerSelected)
                    //    RD.DataDefinition.FormulaFields["CustomerGroup"].Text = clsCommon.fncsetstring(bCustomerSelected.ToString());
                    //if (bSelesRepSelected)
                    //    RD.DataDefinition.FormulaFields["CustomerGroup"].Text = clsCommon.fncsetstring(bSelesRepSelected.ToString());
                    RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);
                }
                RD.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "   To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                RD.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);


                string sFilter = "";
                bool bHasItem = false;
                if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Length > 0)
                {
                    sFilter += "Customer Name : " + txtCustomer.Text.Trim();
                    bHasItem = true;
                }

                if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Trim().Length > 0)
                {
                    if (bHasItem)
                        sFilter += " / ";
                    sFilter += "Sales Rep Name : " + txtSalesRep.Text.Trim();
                    bHasItem = true;
                }
                if (txtRoute.Tag != null && txtRoute.Tag.ToString().Trim().Length > 0)
                {
                    if (bHasItem)
                        sFilter += " / ";
                    sFilter += "Route : " + txtRoute.Text.Trim();
                    bHasItem = true;
                }
                if (txtTown.Tag != null && txtTown.Tag.ToString().Trim().Length > 0)
                {
                    if (bHasItem)
                        sFilter += " / ";
                    sFilter += "Town Name : " + txtTown.Text.Trim();
                    bHasItem = true;
                }
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion


        #region Print Selectection
        private void PrintAll()
        {

        }

        private void PrintCustomerBank()
        {
            //string selectformula = " and {vwChequeRegister.cust_cod} = '" + txtCustomer.Tag.ToString() + "' and {vwChequeRegister.bank_cod} = '" + txtBank.Tag.ToString() + "'";
            //string title = "Customer: " + txtCustomer.Text + "       Bank Name: " + txtBank.Text;
            //if (rdoChequeToBeDeposited.Checked || rdoRegisteredQuotation.Checked)
            //    print("\\reports\\rptChequeToBeDeposited_CustomerBank.rpt", selectformula, title);
            //else if (rdoProformaInvoice.Checked)
            //    print("\\reports\\rptChequeReturned _All.rpt", selectformula, title);            
        }
        private void PrintBankBranch()
        {
            //string selectformula = " and {vwChequeRegister.bank_cod} = '" + txtBank.Tag.ToString() + "' and {vwChequeRegister.brnch_nam} = '" + cmbBranch.Text.Trim() + "'";
            //string title = "Bank Name: " + txtBank.Text + "     Branch Name: " + cmbBranch.Text;
            //if (rdoChequeToBeDeposited.Checked || rdoAll.Checked)
            //    print("\\reports\\rptChequeToBeDeposited_BankBranch.rpt", selectformula, title);    
            //else if (rdoChequeReturned.Checked)
            //    print("\\reports\\rptChequeReturned _All.rpt", selectformula, title);                
        }
        private void PrintBank()
        {
            //string selectformula = " and {vwChequeRegister.bank_cod} = '" + txtBank.Tag.ToString() + "'";
            //string title = "Bank Name: " + txtBank.Text;
            //if (rdoChequeToBeDeposited.Checked || rdoRegisteredQuotation.Checked)
            //    print("\\reports\\rptChequeToBeDeposited_Bank.rpt", selectformula, title);             
            //else if (rdoProformaInvoice.Checked)
            //    print("\\reports\\rptChequeReturned _All.rpt", selectformula, title);             
        }
        private void PrintCustomer()
        {
            //string selectformula = " and {vwChequeRegister.cust_cod} = '" + txtCustomer.Tag.ToString() + "'";
            //string title = "Customer: " + txtCustomer.Text;
            //if (rdoChequeToBeDeposited.Checked || rdoRegisteredQuotation.Checked)
            //    print("\\reports\\rptChequeToBeDeposited_Customer.rpt", selectformula, title);             
            //else if (rdoProformaInvoice.Checked)
            //    print("\\reports\\rptChequeReturned _Customer.rpt", selectformula, title);                
        }
        #endregion

        #region KeyDown Events
        private void txt_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CustomerID();
            }
        }
        private void txtSalesRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_SalesRepID();
            }
        }
        private void txtRoute_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterRoute(ref txtRoute);
            }
        }
        private void txtTown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterTown(ref txtTown);
            }
        }
        private void frm_rpt_ChequeManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Events DoublClick
        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }
        private void txtSalesRep_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesRepID();
        }
        private void txtTown_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterTown(ref txtTown);
        }
        private void txtRoute_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterRoute(ref txtRoute);
        }

        private void txtItem_DoubleClick(object sender, EventArgs e)
        {
            Search_ItemID();
        }
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

        private void Search_ItemID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_ItemMaster();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtItem.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtItem.Tag = frmSearchMaster.s_SearchID;
            }
        }

        private void Search_BankID()
        {
            //Form frmhelpsearch = new frmSearchMaster();
            //if (rdoProformaInvoice.Checked || rdoReconciliatedCheques.Checked)
            //    clsSearch.passValue_BankCompany();
            //else
            //    clsSearch.passValue_Bank();
            //frmhelpsearch.ShowDialog();

            //if (frmSearchMaster.s_SearchID.Length > 0)
            //{
            //    if (frmSearchMaster.s_SearchText.Length > 0)
            //        txtBank.Text = frmSearchMaster.s_SearchText;
            //    if (frmSearchMaster.s_SearchID.Length > 0)
            //        txtBank.Tag = frmSearchMaster.s_SearchID;
            //}
        }
        private void Search_SalesRepID()
        {
            try
            {
                clsSearch.Search_MasterSalesRep(ref txtSalesRep);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events CheckedChanged
        private void rdoRegisteredCheques_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoChequeToBeDeposited_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoReIssuedCheques_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoDeposittedCheques_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoReconciliatedCheques_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoChequeReturnedSummery_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoChequeRealizedSummary_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoChequeSummery_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoPendingChequeReconciliate_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoPendingOrderItemSummary_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();

        }

        #endregion

        #region Set Enable/Disable Controls
        private void setEnableDisableConctrol()
        {
            if (rdoPendingCustomerOrderSummery.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, true);
                clsCommon.SetEnableDisable_NormalLabel(lblRoute, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtTown, true);
                clsCommon.SetEnableDisable_NormalLabel(lblTown, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItem, false);
                clsCommon.SetEnableDisable_NormalLabel(lblItem, false);
                txtItem.Visible = false;
                lblItem.Visible = false;
            }
            else if (rdoPendingCustomerOrderDetailTown.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, true);
                clsCommon.SetEnableDisable_NormalLabel(lblRoute, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtTown, true);
                clsCommon.SetEnableDisable_NormalLabel(lblTown, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItem, false);
                clsCommon.SetEnableDisable_NormalLabel(lblItem, false);
                txtItem.Visible = false;
                lblItem.Visible = false;
            }
            else if (rdoPendingCustomerOrderDetailDate.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, true);
                clsCommon.SetEnableDisable_NormalLabel(lblRoute, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtTown, true);
                clsCommon.SetEnableDisable_NormalLabel(lblTown, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItem, false);
                clsCommon.SetEnableDisable_NormalLabel(lblItem, false);
                txtItem.Visible = false;
                lblItem.Visible = false;
            }
            else if (rdoPendingOrderItem.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, true);
                clsCommon.SetEnableDisable_NormalLabel(lblRoute, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtTown, true);
                clsCommon.SetEnableDisable_NormalLabel(lblTown, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItem, false);
                clsCommon.SetEnableDisable_NormalLabel(lblItem, false);
                txtItem.Visible = false;
                lblItem.Visible = false;
            }
            else if (rdoPendingOrderItemSummary.Checked)
            {
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, false);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomer, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, false);
                clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRoute, false);
                clsCommon.SetEnableDisable_NormalLabel(lblRoute, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtTown, false);
                clsCommon.SetEnableDisable_NormalLabel(lblTown, false);

             //   clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtItem, true);
              //  clsCommon.SetEnableDisable_NormalLabel(lblItem, true);
                txtItem.Visible = true;
                lblItem.Visible = true;
            }
        }
        #endregion

        #region Events CheckedChange
        private void rdoDailySalesReport_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoConfirmedJobSummary_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoDailySalesReportSummary_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoClosedJobSummary_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoPendingCustomerOrderSummery_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoPendingCustomerOrderDetail_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoPendingInquiryOrderSummery_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoPendingInquiryOrderDetail_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoPendingInquiryItem_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }

        private void rdoPendingOrderItem_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoPendingDeliveryItem_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoPendingDeliverySummary_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        private void rdoPendingDeliveryDetail_CheckedChanged(object sender, EventArgs e)
        {
            clearField();
            setEnableDisableConctrol();
        }
        #endregion
    }
}
