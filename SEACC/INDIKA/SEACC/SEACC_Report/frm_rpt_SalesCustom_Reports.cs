using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using Digiteq_Logic;
using System.Windows.Forms;
using DataTire;
using Digiteq;
using System.Reflection;
using SEACC_Report.Excel_Class;
using SEACC_Report.Excel_DataTable;

namespace SEACC_Report
{
    public partial class frm_rpt_SalesCustom_Reports : MettroForm
    {
        #region Variables
        public int iFormID;
        public bool bNoAccess;
        #endregion

        #region Form Load
        public frm_rpt_SalesCustom_Reports()
        {
            iFormID = clsSecurity.getFormID(FormName.ReportSalesCustom);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;
            InitializeComponent();

            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomer, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomer, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCusClass, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCusClass, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCusType, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCusType, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCusCategory, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCusCategory, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesRep, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSalseRep, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSalesNoteType, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, true);
        }

        private void frmReportChequeDeposit_Load(object sender, EventArgs e)
        {
            ThemeColor = clsFormatter.colorSales;

            clearField();
            DisplayReports();
        }
        #endregion

        #region Display Reports
        private void DisplayReports()
        {
            try
            {
                dgvReports.Rows.Clear();
                dgvReports.DataSource = DBHandling.ExecQuery("EXEC sp_Reports '" + 50 + "'").Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                        Cursor = Cursors.WaitCursor;
                        ProgressBar.Value = 0;

                        int iRow = dgvReports.SelectedCells[0].RowIndex;
                        int iReport = int.Parse(dgvReports.Rows[iRow].Cells[0].Value.ToString());
                        enum_ReportName Report = (enum_ReportName)iReport;

                        if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(Report)))
                        {
                            string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                            if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath, true))
                            {
                                #region Filter
                                bool bCustomerSelected = false, bCustomerClassSelected = false, bCustomerTypeSelected = false, bCustomerCategorySelected = false,
                                    bSelesRepSelected = false, bSalesNoteTypeSelected = false, bBranchSelected = false, bRouteSelected = false, bItemSelected = false, bItemCategorySelected = false;
                                string sFilter = "";

                                DateTime dtFromDate = dtpFrom.Value.Date;
                                DateTime dtToDate = dtpTo.Value.Date;
                                string sDaterange = "From  : " + dtFromDate.ToString("dd-MMM-yyyy") + " To : " + dtToDate.ToString("dd-MMM-yyyy");

                                if (txtBranch.Tag != null && txtBranch.Tag.ToString().Trim().Length > 0)
                                    bBranchSelected = true;
                                if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Trim().Length > 0)
                                    bCustomerSelected = true;
                                if (txtCusClass.Tag != null && txtCusClass.Tag.ToString().Trim().Length > 0)
                                    bCustomerClassSelected = true;
                                if (txtCusType.Tag != null && txtCusType.Tag.ToString().Trim().Length > 0)
                                    bCustomerTypeSelected = true;
                                if (txtCusCategory.Tag != null && txtCusCategory.Tag.ToString().Trim().Length > 0)
                                    bCustomerCategorySelected = true;
                                if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Trim().Length > 0)
                                    bSelesRepSelected = true;
                                if (txtSalesNoteType.Tag != null && txtSalesNoteType.Tag.ToString().Trim().Length > 0)
                                    bSalesNoteTypeSelected = true;
                                if (txtRoute.Tag != null && txtRoute.Tag.ToString().Trim().Length > 0)
                                    bRouteSelected = true;
                                if (txtItemCategory.Tag != null && txtItemCategory.Tag.ToString().Trim().Length > 0)
                                    bItemCategorySelected = true;
                                if (txtItemName.Tag != null && txtItemName.Tag.ToString().Trim().Length > 0)
                                    bItemSelected = true;
                                #endregion

                                #region Selected Filters
                                if (bCustomerSelected)
                                    sFilter += " Customer Name : " + txtCustomer.Text.Trim();
                                if (bSelesRepSelected)
                                    sFilter += " Sales Rep. Name : " + txtSalesRep.Text.Trim();
                                if (bCustomerClassSelected)
                                    sFilter += " Customer Class : " + txtSalesNoteType.Text.Trim();
                                if (bCustomerTypeSelected)
                                    sFilter += " Customer Type : " + txtSalesNoteType.Text.Trim();
                                if (bCustomerCategorySelected)
                                    sFilter += " Customer Category : " + txtSalesNoteType.Text.Trim();
                                if (bSalesNoteTypeSelected)
                                    sFilter += " Sales Note Type : " + txtSalesNoteType.Text.Trim();
                                if (bRouteSelected)
                                    sFilter += " Route Name : " + txtRoute.Text.Trim();
                                if (bItemSelected)
                                    sFilter += " Item Name : " + txtItemName.Text.Trim();
                                if (bItemCategorySelected)
                                    sFilter += " Item Category : " + txtItemCategory.Text.Trim();
                                #endregion

                                //#region Celcius Excel Reports
                                //if (Report == enum_ReportName.CU_SalesDetailReport_InvoiceItemWise || Report == enum_ReportName.CU_SalesDetailReport_InvoiceWise ||
                                //                                Report == enum_ReportName.CU_SalesSummaryReport || Report == enum_ReportName.CU_SalesSummaryReport_YTD ||
                                //                                Report == enum_ReportName.CU_CollectionReportSummary_RepWise || Report == enum_ReportName.CU_PendingOrders)
                                //{
                                //    #region Filtered List
                                //    List<tbl_sasCustomerOrder> oCOList;
                                //    List<tbl_sasInvoice> oInvoiceList;
                                //    List<tbl_sasSalesReturnedNote> oSrnList;
                                //    List<tbl_bpsCreditNote> oCrnList;
                                //    List<tbl_bpsDebitNote> oDbnList;

                                //    List<tbl_posTransaction> oPosList;
                                //    List<tbl_genCustomerMaster> oCustomers;

                                //    #region If Customer selected
                                //    if (bCustomerSelected)
                                //    {
                                //        oCOList = tbl_sasCustomerOrder.SelectAllByCustomer_ID(txtCustomer.Tag.ToString()).Where(p => !p.IsDeleted && p.CustomerOrderDate.Date >= dtFromDate.Date && p.CustomerOrderDate.Date <= dtToDate.Date).ToList();
                                //        oInvoiceList = tbl_sasInvoice.SelectAllByCustomer_ID(txtCustomer.Tag.ToString()).Where(p => !p.IsDeleted && !p.IsReturnedCheque && !p.IsDebitNote && p.InvoiceDate.Date >= dtFromDate.Date && p.InvoiceDate.Date <= dtToDate.Date).ToList();
                                //        oSrnList = tbl_sasSalesReturnedNote.SelectAllByCustomer_ID(txtCustomer.Tag.ToString()).Where(p => !p.IsDeleted && !p.IsReturnable && p.SalesReturnedNoteDate.Date >= dtFromDate.Date && p.SalesReturnedNoteDate.Date <= dtToDate.Date).ToList();
                                //        oCrnList = tbl_bpsCreditNote.SelectAllByCustomer_ID(txtCustomer.Tag.ToString()).Where(p => !p.IsDeleted && p.CreditNoteDate.Date >= dtFromDate.Date && p.CreditNoteDate.Date <= dtToDate.Date).ToList();
                                //        oDbnList = tbl_bpsDebitNote.SelectAllByCustomer_ID(txtCustomer.Tag.ToString()).Where(p => !p.IsDeleted && p.DebitNoteDate.Date >= dtFromDate.Date && p.DebitNoteDate.Date <= dtToDate.Date).ToList();

                                //        oPosList = tbl_posTransaction.SelectAllByCustomer_ID(txtCustomer.Tag.ToString()).Where(p => !p.IsHold && !p.IsDeleted && p.PosTransactiondate.Date >= dtFromDate.Date && p.PosTransactiondate.Date <= dtToDate.Date).ToList();//!p.IsReturnedPOS_Invoice && !p.IsHold &&
                                //                                                                                                                                                                                                                                   // oPosReturnList = tbl_posTransaction.SelectAllByCustomer_ID(txtCustomer.Tag.ToString()).Where(p => p.IsReturnedPOS_Invoice && !p.IsDeleted && p.PosTransactiondate.Date >= dtFromDate.Date && p.PosTransactiondate.Date <= dtToDate.Date).ToList();
                                //        oCustomers = new List<tbl_genCustomerMaster>();
                                //        oCustomers.Add(tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString()));
                                //    }
                                //    else
                                //    {
                                //        oCOList = tbl_sasCustomerOrder.SelectAll().Where(p => !p.IsDeleted && p.CustomerOrderDate.Date >= dtFromDate.Date && p.CustomerOrderDate.Date <= dtToDate.Date).ToList();
                                //        oInvoiceList = tbl_sasInvoice.SelectAll().Where(p => !p.IsDeleted && !p.IsReturnedCheque && !p.IsDebitNote && p.InvoiceDate.Date >= dtFromDate.Date && p.InvoiceDate.Date <= dtToDate.Date).ToList();
                                //        oSrnList = tbl_sasSalesReturnedNote.SelectAll().Where(p => !p.IsDeleted && !p.IsReturnable && p.SalesReturnedNoteDate.Date >= dtFromDate.Date && p.SalesReturnedNoteDate.Date <= dtToDate.Date).ToList();
                                //        oCrnList = tbl_bpsCreditNote.SelectAll().Where(p => !p.IsDeleted && p.CreditNoteDate.Date >= dtFromDate.Date && p.CreditNoteDate.Date <= dtToDate.Date).ToList();
                                //        oDbnList = tbl_bpsDebitNote.SelectAll().Where(p => !p.IsDeleted && p.DebitNoteDate.Date >= dtFromDate.Date && p.DebitNoteDate.Date <= dtToDate.Date).ToList();

                                //        oPosList = tbl_posTransaction.SelectAll().Where(p => !p.IsHold && !p.IsDeleted && p.PosTransactiondate.Date >= dtFromDate.Date && p.PosTransactiondate.Date <= dtToDate.Date).ToList();
                                //        //!p.IsReturnedPOS_Invoice &&   // oPosReturnList = tbl_posTransaction.SelectAll().Where(p => p.IsReturnedPOS_Invoice && !p.IsDeleted && p.PosTransactiondate.Date >= dtFromDate.Date && p.PosTransactiondate.Date <= dtToDate.Date).ToList();
                                //        oCustomers = tbl_genCustomerMaster.SelectAll();
                                //    }
                                //    #endregion

                                //    if (!chkShowAllCO.Checked)
                                //        oCOList = oCOList.Where(p => !p.IsSeattled).ToList();

                                //    if (bBranchSelected)
                                //    {
                                //        oCOList = oCOList.Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString()).ToList();
                                //        oInvoiceList = oInvoiceList.Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString()).ToList();
                                //        oSrnList = oSrnList.Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString()).ToList();
                                //        oPosList = oPosList.Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString()).ToList();
                                //        oCrnList = oCrnList.Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString()).ToList();
                                //        oDbnList = oDbnList.Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString()).ToList();
                                //    }
                                //    #endregion

                                //    #region Sales Report - Invoice Wice Item Wise & Invoice Wise
                                //    if (Report == enum_ReportName.CU_SalesDetailReport_InvoiceItemWise || Report == enum_ReportName.CU_SalesDetailReport_InvoiceWise)
                                //    {
                                //        List<cls_sasSalesReportDetail_InvoiceItemWise_DTO> lstSales = new List<cls_sasSalesReportDetail_InvoiceItemWise_DTO>();

                                //        #region Fill Data Object List
                                //        #region Invoice
                                //        foreach (tbl_sasInvoice oInvoice in oInvoiceList)
                                //        {
                                //            bool bVATable = false, bNBTable = false, bSVATable = false;
                                //            decimal dDiscountPresentage_AVG = 0;
                                //            decimal dDiscounttotal = oInvoice.DiscountTotal + oInvoice.DiscountTotal1 + oInvoice.DiscountTotal2 + oInvoice.DiscountTotal3;
                                //            string sSalesmanID = "";

                                //            tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oInvoice.Customer_ID).FirstOrDefault();
                                //            if (oCustomer != null)
                                //            {
                                //                #region Filters
                                //                #region Customer Filters
                                //                if (bCustomerClassSelected)
                                //                    if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
                                //                        continue;
                                //                if (bCustomerTypeSelected)
                                //                    if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
                                //                        continue;
                                //                if (bCustomerCategorySelected)
                                //                    if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
                                //                        continue;
                                //                #endregion

                                //                #region Sales Rep Filter
                                //                if (!chkUseCustomerMastorSaleRep.Checked)
                                //                {
                                //                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                //                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                //                        sSalesmanID = oRef.Employee_ID;
                                //                }
                                //                else
                                //                    sSalesmanID = oCustomer.SalesRep_ID;


                                //                if (bSelesRepSelected)
                                //                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                //                        continue;
                                //                #endregion
                                //                #endregion

                                //                #region Bulk Discount Presentage
                                //                if (dDiscounttotal != 0)
                                //                    dDiscountPresentage_AVG = dDiscounttotal * 100 / oInvoice.SubTotal;
                                //                #endregion

                                //                #region Tax
                                //                if (oInvoice.IsVatInvoice)
                                //                {
                                //                    bVATable = true;
                                //                    bNBTable = true;
                                //                }
                                //                else if (oInvoice.IsSVatInvoice)
                                //                {
                                //                    bSVATable = true;
                                //                    bNBTable = true;
                                //                }
                                //                #endregion

                                //                #region Transaction Detail 
                                //                foreach (tbl_sasInvoice_Detail oDetail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID).OrderBy(r => r.Line_No))
                                //                {
                                //                    decimal dMultificationFactor = 0, dItemWise_GrandTotal = 0, dNBTAmount = 0, dVATAmount = 0, dSVATAmount = 0, dSubTotal = 0, dAmountBeforeLineDiscount = 0, dBulkDiscount = 0, dLineDiscount = 0;

                                //                    if (oInvoice.SubTotal != 0)
                                //                        dMultificationFactor = oDetail.TatalAmount / oInvoice.SubTotal;

                                //                    dItemWise_GrandTotal = oInvoice.GrandTotal * dMultificationFactor;

                                //                    if (dDiscountPresentage_AVG == 100)
                                //                    {
                                //                        oDetail.BIsFreeItem = true;
                                //                        dDiscountPresentage_AVG = 0;
                                //                    }
                                //                    clsHelpMethods.CalculateGrandTotalReverce(dItemWise_GrandTotal, ref dVATAmount, oInvoice.VatPercentage, bVATable, ref dSVATAmount, oInvoice.OtherTaxPercentage, bSVATable, ref dNBTAmount, oInvoice.NbtPercentage, bNBTable, ref dBulkDiscount, dDiscountPresentage_AVG, ref dSubTotal);

                                //                    if (oDetail.BIsFreeItem || oDetail.DiscountPresentage == 100)
                                //                    {
                                //                        dAmountBeforeLineDiscount = oDetail.Qty * oDetail.UnitPrice;
                                //                        dLineDiscount = dAmountBeforeLineDiscount;
                                //                    }
                                //                    else
                                //                    {
                                //                        dAmountBeforeLineDiscount = (dSubTotal / (100 - oDetail.DiscountPresentage) * 100);
                                //                        dLineDiscount = dAmountBeforeLineDiscount - dSubTotal;
                                //                    }

                                //                    decimal dUnitPrice = dAmountBeforeLineDiscount / oDetail.Qty;

                                //                    lstSales.Add(new cls_sasSalesReportDetail_InvoiceItemWise_DTO()
                                //                    {
                                //                        TxType = "1-Sales",
                                //                        Branch = clsGenaralName.getName_CompanyBranchMaster(oInvoice.CompanyBranch_ID),
                                //                        Tx_ID = oInvoice.Invoice_ID,
                                //                        TxDate = oInvoice.InvoiceDate.Date,
                                //                        SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
                                //                        Customer = clsGenaralName.getName_Customer(oInvoice.Customer_ID),
                                //                        CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
                                //                        CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
                                //                        CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

                                //                        Item_ID = oDetail.Item_ID,
                                //                        ItemName = clsGenaralName.getName_Item(oDetail.Item_ID),

                                //                        SellingPrice = dUnitPrice,
                                //                        TotalQty = oDetail.Qty,

                                //                        ItemTotal = dAmountBeforeLineDiscount,
                                //                        Discount = dBulkDiscount + dLineDiscount,
                                //                        SubTotal = dAmountBeforeLineDiscount - (dBulkDiscount + dLineDiscount), //dSubTotal,

                                //                        NBTAmount = dNBTAmount,
                                //                        VATAmount = dVATAmount,
                                //                        GrandTotal = dItemWise_GrandTotal,
                                //                        SVATAmount = dSVATAmount,

                                //                        IsReturnedPOS_Invoice = false
                                //                    });
                                //                }
                                //                #endregion

                                //                clsHelpMethods_Local.startProgressBar(0, oInvoiceList.Count, 1, ProgressBar);
                                //            }
                                //        }
                                //        ProgressBar.Value = 0;
                                //        #endregion

                                //        #region SRN
                                //        foreach (tbl_sasSalesReturnedNote oSrn in oSrnList)
                                //        {
                                //            bool bVATable = false, bNBTable = false, bSVATable = false;
                                //            decimal dDiscountPresentage_AVG = 0;
                                //            decimal dDiscounttotal = oSrn.DiscountTotal;
                                //            string sSalesmanID = "";

                                //            tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oSrn.Customer_ID).FirstOrDefault();
                                //            if (oCustomer != null)
                                //            {
                                //                #region Filters
                                //                #region Customer Filters
                                //                if (bCustomerClassSelected)
                                //                    if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
                                //                        continue;
                                //                if (bCustomerTypeSelected)
                                //                    if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
                                //                        continue;
                                //                if (bCustomerCategorySelected)
                                //                    if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
                                //                        continue;
                                //                #endregion

                                //                #region Sales Rep Filter
                                //                if (!chkUseCustomerMastorSaleRep.Checked)
                                //                {
                                //                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oSrn.OrderRefNo_ID);
                                //                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                //                        sSalesmanID = oRef.Employee_ID;
                                //                }
                                //                else
                                //                    sSalesmanID = oCustomer.SalesRep_ID;

                                //                if (bSelesRepSelected)
                                //                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                //                        continue;
                                //                #endregion
                                //                #endregion

                                //                #region Bulk Discount Presentage
                                //                if (dDiscounttotal != 0)
                                //                    dDiscountPresentage_AVG = dDiscounttotal * 100 / oSrn.SubTotal;
                                //                #endregion

                                //                #region Tax
                                //                if (oSrn.VatTotal > 0)
                                //                {
                                //                    bVATable = true;
                                //                    bNBTable = true;
                                //                }
                                //                else if (oSrn.OtherTaxTotal > 0)
                                //                {
                                //                    bSVATable = true;
                                //                    bNBTable = true;
                                //                }
                                //                #endregion

                                //                #region Transaction Detail 
                                //                foreach (tbl_sasSalesReturnedNote_Detail oDetail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSrn.SalesReturnedNote_ID).OrderBy(r => r.Line_No))
                                //                {
                                //                    decimal dMultificationFactor = 0, dItemWise_GrandTotal = 0, dNBTAmount = 0, dVATAmount = 0, dSVATAmount = 0, dSubTotal = 0, dAmountBeforeLineDiscount = 0, dBulkDiscount = 0, dLineDiscount = 0;

                                //                    if (oSrn.SubTotal != 0)
                                //                        dMultificationFactor = oDetail.TatalAmount / oSrn.SubTotal;

                                //                    dItemWise_GrandTotal = oSrn.GrandTotal * dMultificationFactor;

                                //                    if (dDiscountPresentage_AVG == 100)
                                //                    {
                                //                        oDetail.BIsFreeItem = true;
                                //                        dDiscountPresentage_AVG = 0;
                                //                    }

                                //                    clsHelpMethods.CalculateGrandTotalReverce(dItemWise_GrandTotal, ref dVATAmount, oSrn.VatPercentage, bVATable, ref dSVATAmount, oSrn.OtherTaxPercentage, bSVATable, ref dNBTAmount, oSrn.NbtPercentage, bNBTable, ref dBulkDiscount, dDiscountPresentage_AVG, ref dSubTotal);

                                //                    if (oDetail.BIsFreeItem || oDetail.DiscountPresentage == 100)
                                //                    {
                                //                        dAmountBeforeLineDiscount = oDetail.Qty * oDetail.UnitPrice;
                                //                        dLineDiscount = dAmountBeforeLineDiscount;
                                //                    }
                                //                    else
                                //                    {
                                //                        dAmountBeforeLineDiscount = (dSubTotal / (100 - oDetail.DiscountPresentage) * 100);
                                //                        dLineDiscount = dAmountBeforeLineDiscount - dSubTotal;
                                //                    }

                                //                    decimal dUnitPrice = dAmountBeforeLineDiscount / oDetail.Qty;

                                //                    lstSales.Add(new cls_sasSalesReportDetail_InvoiceItemWise_DTO()
                                //                    {
                                //                        TxType = "2-Sales Return",
                                //                        Branch = clsGenaralName.getName_CompanyBranchMaster(oSrn.CompanyBranch_ID),
                                //                        Tx_ID = oSrn.SalesReturnedNote_ID,
                                //                        TxDate = oSrn.SalesReturnedNoteDate.Date,
                                //                        SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
                                //                        Customer = clsGenaralName.getName_Customer(oSrn.Customer_ID),
                                //                        CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
                                //                        CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
                                //                        CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),


                                //                        Item_ID = oDetail.Item_ID,
                                //                        ItemName = clsGenaralName.getName_Item(oDetail.Item_ID),

                                //                        SellingPrice = (dUnitPrice * -1),
                                //                        TotalQty = (oDetail.Qty * -1),
                                //                        ItemTotal = (dAmountBeforeLineDiscount * -1),

                                //                        Discount = (dBulkDiscount + dLineDiscount * -1),
                                //                        SubTotal = ((dAmountBeforeLineDiscount - (dBulkDiscount + dLineDiscount)) * -1),

                                //                        NBTAmount = (dNBTAmount * -1),
                                //                        VATAmount = (dVATAmount * -1),
                                //                        GrandTotal = (dItemWise_GrandTotal * -1),
                                //                        SVATAmount = (dSVATAmount * -1),

                                //                        IsReturnedPOS_Invoice = false
                                //                    });
                                //                }
                                //                #endregion

                                //                clsHelpMethods_Local.startProgressBar(0, oSrnList.Count, 1, ProgressBar);
                                //            }
                                //        }
                                //        ProgressBar.Value = 0;
                                //        #endregion

                                //        #region CRN
                                //        foreach (tbl_bpsCreditNote oCrn in oCrnList.Where(p => p.SalesReturnedNote_ID == "default" && p.PosReturnTransaction_Index == -1 && p.AdvanceReceived_Index == -1 && p.CreditNoteType_ID == "TP/002" || p.CreditNoteType_ID == "TP/007" || p.CreditNoteType_ID == "TP/004" || p.CreditNoteType_ID == "TP/005"))
                                //        {
                                //            bool bVATable = false, bNBTable = false, bSVATable = false;
                                //            decimal dDiscountPresentage_AVG = 0;
                                //            decimal dDiscounttotal = oCrn.DiscountTotal;
                                //            string sSalesmanID = "";

                                //            tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oCrn.Customer_ID).FirstOrDefault();
                                //            if (oCustomer != null)
                                //            {
                                //                #region Filters
                                //                #region Customer Filters
                                //                if (bCustomerClassSelected)
                                //                    if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
                                //                        continue;
                                //                if (bCustomerTypeSelected)
                                //                    if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
                                //                        continue;
                                //                if (bCustomerCategorySelected)
                                //                    if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
                                //                        continue;
                                //                #endregion

                                //                #region Sales Rep Filter
                                //                if (!chkUseCustomerMastorSaleRep.Checked)
                                //                {
                                //                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oCrn.OrderRefNo_ID);
                                //                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                //                        sSalesmanID = oRef.Employee_ID;
                                //                }
                                //                else
                                //                    sSalesmanID = oCustomer.SalesRep_ID;


                                //                if (bSelesRepSelected)
                                //                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                //                        continue;
                                //                #endregion

                                //                #region Sales Note Filter
                                //                if (bSalesNoteTypeSelected)
                                //                    if (txtSalesNoteType.Tag.ToString() != oCrn.SalesNoteType_ID)
                                //                        continue;
                                //                #endregion
                                //                #endregion

                                //                #region Bulk Discount Presentage
                                //                if (dDiscounttotal != 0)
                                //                    dDiscountPresentage_AVG = dDiscounttotal * 100 / oCrn.SubTotal;
                                //                #endregion

                                //                #region Tax
                                //                if (oCrn.VatTotal > 0)
                                //                {
                                //                    bVATable = true;
                                //                    bNBTable = true;
                                //                }
                                //                else if (oCrn.OtherTaxTotal > 0)
                                //                {
                                //                    bSVATable = true;
                                //                    bNBTable = true;
                                //                }
                                //                #endregion

                                //                #region Detail Fill
                                //                decimal dItemWise_GrandTotal = oCrn.TotalAmount, dNBTAmount = 0, dVATAmount = 0, dSVATAmount = 0, dItemTotal = 0, dBulkDiscount = 0, dSubTotal = 0;
                                //                clsHelpMethods.CalculateGrandTotalReverce(dItemWise_GrandTotal, ref dVATAmount, oCrn.VatPercentage, bVATable, ref dSVATAmount, oCrn.OtherTaxPercentage, bSVATable, ref dNBTAmount, oCrn.NbtPercentage, bNBTable, ref dBulkDiscount, dDiscountPresentage_AVG, ref dItemTotal);

                                //                dSubTotal = dItemTotal + dBulkDiscount;
                                //                lstSales.Add(new cls_sasSalesReportDetail_InvoiceItemWise_DTO()
                                //                {
                                //                    TxType = "3-Credit Note",
                                //                    Branch = clsGenaralName.getName_CompanyBranchMaster(oCrn.CompanyBranch_ID),
                                //                    Tx_ID = oCrn.CreditNote_ID,
                                //                    TxDate = oCrn.CreditNoteDate.Date,
                                //                    SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
                                //                    Customer = clsGenaralName.getName_Customer(oCrn.Customer_ID),
                                //                    CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
                                //                    CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
                                //                    CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),


                                //                    Item_ID = "-",
                                //                    ItemName = "-",

                                //                    SellingPrice = 0,
                                //                    TotalQty = 0,
                                //                    ItemTotal = (dItemTotal * -1),

                                //                    Discount = (dBulkDiscount * -1),
                                //                    SubTotal = ((dItemTotal - dBulkDiscount) * -1),

                                //                    NBTAmount = (dNBTAmount * -1),
                                //                    VATAmount = (dVATAmount * -1),
                                //                    GrandTotal = (dItemWise_GrandTotal * -1),
                                //                    SVATAmount = (dSVATAmount * -1),

                                //                    IsReturnedPOS_Invoice = false
                                //                });
                                //                #endregion

                                //                clsHelpMethods_Local.startProgressBar(0, oCrnList.Count, 1, ProgressBar);
                                //            }
                                //        }
                                //        ProgressBar.Value = 0;
                                //        #endregion

                                //        #region DBN
                                //        foreach (tbl_bpsDebitNote oDbn in oDbnList.Where(p => p.DebitNoteType_ID == "TP/003"))
                                //        {
                                //            string sSalesmanID = "";
                                //            tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oDbn.Customer_ID).FirstOrDefault();
                                //            if (oCustomer != null)
                                //            {
                                //                #region Filters
                                //                #region Customer Filters
                                //                if (bCustomerClassSelected)
                                //                    if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
                                //                        continue;
                                //                if (bCustomerTypeSelected)
                                //                    if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
                                //                        continue;
                                //                if (bCustomerCategorySelected)
                                //                    if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
                                //                        continue;
                                //                #endregion

                                //                #region Sales Rep Filter
                                //                if (!chkUseCustomerMastorSaleRep.Checked)
                                //                {
                                //                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oDbn.OrderRefNo_ID);
                                //                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                //                        sSalesmanID = oRef.Employee_ID;
                                //                }
                                //                else
                                //                    sSalesmanID = oCustomer.SalesRep_ID;


                                //                if (bSelesRepSelected)
                                //                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                //                        continue;
                                //                #endregion

                                //                #region Sales Note Filter
                                //                if (bSalesNoteTypeSelected)
                                //                    if (txtSalesNoteType.Tag.ToString() != oDbn.SalesNoteType_ID)
                                //                        continue;
                                //                #endregion
                                //                #endregion

                                //                bool bVATable = false, bNBTable = false, bSVATable = false;
                                //                decimal dDiscountPresentage_AVG = 0;
                                //                decimal dDiscounttotal = oDbn.DiscountTotal;

                                //                #region Bulk Discount Presentage
                                //                if (dDiscounttotal != 0)
                                //                    dDiscountPresentage_AVG = dDiscounttotal * 100 / oDbn.SubTotal;
                                //                #endregion

                                //                #region Tax
                                //                if (oDbn.VatTotal > 0)
                                //                {
                                //                    bVATable = true;
                                //                    bNBTable = true;
                                //                }
                                //                else if (oDbn.OtherTaxTotal > 0)
                                //                {
                                //                    bSVATable = true;
                                //                    bNBTable = true;
                                //                }
                                //                #endregion

                                //                #region Detail Fill
                                //                decimal dItemWise_GrandTotal = oDbn.TotalAmount, dSubTotal = 0, dNBTAmount = 0, dVATAmount = 0, dSVATAmount = 0, dItemTotal = 0, dBulkDiscount = 0;
                                //                clsHelpMethods.CalculateGrandTotalReverce(dItemWise_GrandTotal, ref dVATAmount, oDbn.VatPercentage, bVATable, ref dSVATAmount, oDbn.OtherTaxPercentage, bSVATable, ref dNBTAmount, oDbn.NbtPercentage, bNBTable, ref dBulkDiscount, dDiscountPresentage_AVG, ref dItemTotal);

                                //                dSubTotal = dItemTotal + dBulkDiscount;
                                //                lstSales.Add(new cls_sasSalesReportDetail_InvoiceItemWise_DTO()
                                //                {
                                //                    TxType = "4-Debit Note",
                                //                    Branch = clsGenaralName.getName_CompanyBranchMaster(oDbn.CompanyBranch_ID),
                                //                    Tx_ID = oDbn.DebitNote_ID,
                                //                    TxDate = oDbn.DebitNoteDate.Date,
                                //                    SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
                                //                    Customer = clsGenaralName.getName_Customer(oDbn.Customer_ID),
                                //                    CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
                                //                    CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
                                //                    CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),


                                //                    Item_ID = "-",
                                //                    ItemName = "-",

                                //                    SellingPrice = 0,
                                //                    TotalQty = 0,
                                //                    ItemTotal = dItemTotal,

                                //                    Discount = dBulkDiscount,
                                //                    SubTotal = dItemTotal - dBulkDiscount,

                                //                    NBTAmount = dNBTAmount,
                                //                    VATAmount = dVATAmount,
                                //                    GrandTotal = dItemWise_GrandTotal,
                                //                    SVATAmount = dSVATAmount,

                                //                    IsReturnedPOS_Invoice = false
                                //                });
                                //                #endregion

                                //                clsHelpMethods_Local.startProgressBar(0, oDbnList.Count, 1, ProgressBar);
                                //            }
                                //        }
                                //        ProgressBar.Value = 0;
                                //        #endregion

                                //        #region POS Transaction
                                //        foreach (tbl_posTransaction oPos in oPosList)
                                //        {
                                //            decimal dDiscountPresentage_AVG = 0;
                                //            decimal dDiscounttotal = oPos.DiscountTotal;
                                //            string sSalesmanID = "";
                                //            tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oPos.Customer_ID).FirstOrDefault();
                                //            if (oCustomer != null)
                                //            {
                                //                #region Filters
                                //                #region Customer Filters
                                //                if (bCustomerClassSelected)
                                //                    if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
                                //                        continue;
                                //                if (bCustomerTypeSelected)
                                //                    if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
                                //                        continue;
                                //                if (bCustomerCategorySelected)
                                //                    if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
                                //                        continue;
                                //                #endregion

                                //                #region Sales Rep Filter
                                //                //if (!chkUseCustomerMastorSaleRep.Checked)
                                //                //{
                                //                //    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oPos.OrderRefNo_ID);
                                //                //    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                //                //        sSalesmanID = oRef.Employee_ID;
                                //                //}
                                //                //else
                                //                sSalesmanID = oCustomer.SalesRep_ID;

                                //                if (bSelesRepSelected)
                                //                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                //                        continue;
                                //                #endregion
                                //                #endregion

                                //                #region Bulk Discount
                                //                if (dDiscounttotal != 0)
                                //                    dDiscountPresentage_AVG = dDiscounttotal * 100 / oPos.SubTotal;
                                //                if (oPos.SubTotal < 0)
                                //                    dDiscountPresentage_AVG *= -1;
                                //                #endregion

                                //                #region Transaction Detail
                                //                foreach (tbl_posTransaction_Detail oDetail in tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oPos.PosTransaction_Index))
                                //                {
                                //                    decimal dMultificationFactor = 0, dItemWise_GrandTotal = 0, dNBTAmount = 0, dVATAmount = 0, dSVATAmount = 0, dSubTotal = 0, dAmountBeforeLineDiscount = 0, dBulkDiscount = 0, dLineDiscount = 0;

                                //                    if (oPos.SubTotal != 0)
                                //                        dMultificationFactor = oDetail.GrossAmount / oPos.SubTotal;

                                //                    dItemWise_GrandTotal = oPos.GrandTotal * dMultificationFactor;

                                //                    if (dDiscountPresentage_AVG == 100)
                                //                    {
                                //                        oDetail.BIsFreeItem = true;
                                //                        dDiscountPresentage_AVG = 0;
                                //                    }

                                //                    clsHelpMethods.CalculateGrandTotalReverce(dItemWise_GrandTotal, ref dVATAmount, oPos.VatPercentage, true, ref dSVATAmount, oPos.OtherTaxPercentage, false, ref dNBTAmount, oPos.NbtPercentage, true, ref dBulkDiscount, dDiscountPresentage_AVG, ref dSubTotal);

                                //                    if (oDetail.BIsFreeItem || oDetail.LineDiscountPresentage == 100)
                                //                    {
                                //                        dAmountBeforeLineDiscount = oDetail.Qty * oDetail.UnitPrice;
                                //                        dLineDiscount = dAmountBeforeLineDiscount;
                                //                    }
                                //                    else
                                //                    {
                                //                        dAmountBeforeLineDiscount = (dSubTotal / (100 - oDetail.LineDiscountPresentage) * 100);
                                //                        dLineDiscount = dAmountBeforeLineDiscount - dSubTotal;
                                //                    }

                                //                    decimal dUnitPrice = dAmountBeforeLineDiscount / oDetail.Qty;



                                //                    //decimal dMultificationFactor = 0, dAmount = 0, dWithNBTAmount = 0, dSubTotal = 0, dNBTAmount = 0, dVATAmount = 0, dAmountBeforeBulkDiscount = 0, dAmountBeforeLineDiscount = 0;

                                //                    //if (oPos.SubTotal != 0)
                                //                    //    dMultificationFactor = oDetail.GrossAmount / oPos.SubTotal;

                                //                    //dAmount = oPos.GrandTotal * dMultificationFactor;

                                //                    //clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dAmount, oPos.VatPercentage, oPos.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVATAmount);
                                //                    //decimal dBulkDiscount = 0, dLineDiscount = 0;

                                //                    //if (dDiscountPresentage_AVG != 100)
                                //                    //{
                                //                    //    dAmountBeforeBulkDiscount = (dSubTotal / (100 - dDiscountPresentage_AVG) * 100);
                                //                    //    dBulkDiscount = dAmountBeforeBulkDiscount - dSubTotal;
                                //                    //}
                                //                    //else
                                //                    //{
                                //                    //    oDetail.BIsFreeItem = true;
                                //                    //}


                                //                    //if (oDetail.BIsFreeItem || oDetail.LineDiscountPresentage == 100)
                                //                    //{
                                //                    //    dAmountBeforeLineDiscount = oDetail.Qty * oDetail.UnitPrice;
                                //                    //    dLineDiscount = dAmountBeforeLineDiscount;
                                //                    //}
                                //                    //else
                                //                    //{
                                //                    //    dAmountBeforeLineDiscount = (dAmountBeforeBulkDiscount / (100 - oDetail.LineDiscountPresentage) * 100);
                                //                    //    dLineDiscount = dAmountBeforeLineDiscount - dAmountBeforeBulkDiscount;
                                //                    //}

                                //                    //decimal dUnitPrice = dAmountBeforeLineDiscount / oDetail.Qty;

                                //                    lstSales.Add(new cls_sasSalesReportDetail_InvoiceItemWise_DTO()
                                //                    {
                                //                        TxType = "5-POS Sales & Return",
                                //                        Branch = clsGenaralName.getName_CompanyBranchMaster(oPos.CompanyBranch_ID),
                                //                        Tx_ID = oPos.PosTransaction_ID,
                                //                        TxDate = oPos.PosTransactiondate.Date,
                                //                        SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
                                //                        Customer = clsGenaralName.getName_Customer(oPos.Customer_ID),
                                //                        CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
                                //                        CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
                                //                        CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

                                //                        Item_ID = oDetail.Item_ID,
                                //                        ItemName = clsGenaralName.getName_Item(oDetail.Item_ID),
                                //                        SellingPrice = dUnitPrice,
                                //                        TotalQty = oDetail.Qty,
                                //                        ItemTotal = dAmountBeforeLineDiscount,

                                //                        Discount = dBulkDiscount + dLineDiscount,
                                //                        SubTotal = dAmountBeforeLineDiscount - (dBulkDiscount + dLineDiscount),

                                //                        NBTAmount = dNBTAmount,
                                //                        VATAmount = dVATAmount,
                                //                        GrandTotal = dItemWise_GrandTotal,
                                //                        SVATAmount = 0,

                                //                        IsReturnedPOS_Invoice = oPos.IsReturnedPOS_Invoice
                                //                    });

                                //                }


                                //                foreach (tbl_posReceipt oReceipt in tbl_posReceipt.SelectAllByPosTransaction_Index(oPos.PosTransaction_Index))
                                //                {
                                //                    foreach (tbl_bpsChequeRegister oChequeRegister in tbl_bpsChequeRegister.SelectAllByPosReceipt_ID(oReceipt.PosReceipt_ID).Where(p => p.PaymentMethod_ID == (int)PaymentMethod.Gift_Voucher))
                                //                    {
                                //                        decimal dGrandTotalWithout_Tax2 = 0;
                                //                        decimal dWithNbtAmount2 = 0, dNbtAmount2 = 0, dVatAmount2 = 0;

                                //                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oChequeRegister.Amount, oPos.VatPercentage, oPos.NbtPercentage, ref dWithNbtAmount2, ref dGrandTotalWithout_Tax2, ref dNbtAmount2, ref dVatAmount2);

                                //                        lstSales.Add(new cls_sasSalesReportDetail_InvoiceItemWise_DTO()
                                //                        {
                                //                            TxType = "5-POS Sales & Return",
                                //                            Branch = clsGenaralName.getName_CompanyBranchMaster(oPos.CompanyBranch_ID),
                                //                            Tx_ID = oPos.PosTransaction_ID,
                                //                            TxDate = oPos.PosTransactiondate.Date,
                                //                            SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
                                //                            Customer = clsGenaralName.getName_Customer(oPos.Customer_ID),
                                //                            CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
                                //                            CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

                                //                            Item_ID = oChequeRegister.GiftVoucherID.ToString(),
                                //                            ItemName = "Gift Voucher",

                                //                            SellingPrice = 0,
                                //                            TotalQty = 0,
                                //                            ItemTotal = -dGrandTotalWithout_Tax2,

                                //                            Discount = 0,
                                //                            SubTotal = -dGrandTotalWithout_Tax2,

                                //                            NBTAmount = -dNbtAmount2,
                                //                            VATAmount = -dVatAmount2,
                                //                            GrandTotal = -oChequeRegister.Amount,
                                //                            SVATAmount = 0,

                                //                            IsReturnedPOS_Invoice = oPos.IsReturnedPOS_Invoice
                                //                        });
                                //                    }
                                //                }
                                //                #endregion

                                //                clsHelpMethods_Local.startProgressBar(0, oPosList.Count, 1, ProgressBar);
                                //            }
                                //        }
                                //        ProgressBar.Value = 0;
                                //        #endregion
                                //        #endregion

                                //        #region Print Section
                                //        if (lstSales.Count > 0)
                                //        {
                                //            #region Invoice
                                //            if (Report == enum_ReportName.CU_SalesDetailReport_InvoiceWise)
                                //            {
                                //                List<cls_sasSalesReportDetail_InvoiceWise_DTO> lstSales_Temp = lstSales.GroupBy(r => new { r.TxType, r.Branch, r.Tx_ID, r.TxDate, r.SalesRep, r.Customer, r.CustomerClass, r.CustomerType, r.CustomerCategory })
                                //                                        .Select(grp => new cls_sasSalesReportDetail_InvoiceWise_DTO
                                //                                        {
                                //                                            TxType = grp.Key.TxType,
                                //                                            Branch = grp.Key.Branch,
                                //                                            Tx_ID = grp.Key.Tx_ID,
                                //                                            TxDate = grp.Key.TxDate,
                                //                                            SalesRep = grp.Key.SalesRep,
                                //                                            Customer = grp.Key.Customer,
                                //                                            CustomerClass = grp.Key.CustomerClass,
                                //                                            CustomerType = grp.Key.CustomerType,
                                //                                            CustomerCategory = grp.Key.CustomerCategory,

                                //                                            TotalQty = grp.Sum(r => r.TotalQty),

                                //                                            ItemAmount = grp.Sum(r => r.ItemTotal),
                                //                                            Discount = grp.Sum(r => r.Discount),
                                //                                            SubTotal = grp.Sum(r => r.SubTotal),

                                //                                            NBTAmount = grp.Sum(r => r.NBTAmount),
                                //                                            VATAmount = grp.Sum(r => r.VATAmount),
                                //                                            GrandTotal = grp.Sum(r => r.GrandTotal),
                                //                                            SVATAmount = grp.Sum(r => r.SVATAmount)

                                //                                        }).ToList();

                                //                cls_sasSalesReportDetail_InvoiceWise.Run_SalesReportDetail_InvoiceWise(lstSales_Temp, dtFromDate, dtToDate, sReportTitle_Main);
                                //            }
                                //            #endregion
                                //            #region Sales Summary
                                //            //else if (Report == enum_ReportName.CU_SalesSummaryReport || Report == enum_ReportName.CU_SalesSummaryReport_YTD)
                                //            //{
                                //            //    List<cls_sasSalesReportSummary_DTO> lstSales = lstSalesTemp.GroupBy(r => new { r.TxType, r.Branch, r.Tx_ID, r.TxDate, r.SalesRep, r.Customer, r.CustomerClass, r.CustomerType, r.CustomerCategory })
                                //            //                                    .Select(grp => new cls_sasSalesReportSummary_DTO()
                                //            //                                    {
                                //            //                                        TxType = grp.Key.TxType,
                                //            //                                        Branch = grp.Key.Branch,
                                //            //                                        Tx_ID = grp.Key.Tx_ID,
                                //            //                                        TxDate = grp.Key.TxDate,
                                //            //                                        SalesRep = grp.Key.SalesRep,
                                //            //                                        Customer = grp.Key.Customer,
                                //            //                                        CustomerClass = grp.Key.CustomerClass,
                                //            //                                        CustomerType = grp.Key.CustomerType,
                                //            //                                        CustomerCategory = grp.Key.CustomerCategory,

                                //            //                                        Sale = grp.Where(p => p.TxType == "1-Sales").Sum(r => r.SubTotal) + grp.Where(p => p.TxType == "5-POS Sales & Return" && p.IsReturnedPOS_Invoice == false).Sum(r => r.SubTotal),
                                //            //                                        SalesReturn = grp.Where(p => p.TxType == "2-Sales Return").Sum(r => r.SubTotal) + grp.Where(p => p.TxType == "5-POS Sales & Return" && p.IsReturnedPOS_Invoice == true).Sum(r => r.SubTotal * -1),
                                //            //                                        CreditNote = grp.Where(p => p.TxType == "3-Credit Note").Sum(r => r.SubTotal),
                                //            //                                        DebitNote = grp.Where(p => p.TxType == "4-Debit Note").Sum(r => r.SubTotal),

                                //            //                                        SalesQty = grp.Where(p => p.TxType == "1-Sales").Sum(r => r.TotalQty) + grp.Where(p => p.TxType == "5-POS Sales & Return" && p.IsReturnedPOS_Invoice == false).Sum(r => r.TotalQty),
                                //            //                                        ReturnQty = grp.Where(p => p.TxType == "1-Sales").Sum(r => r.TotalQty) + grp.Where(p => p.TxType == "5-POS Sales & Return" && p.IsReturnedPOS_Invoice == true).Sum(r => r.TotalQty),
                                //            //                                    }).ToList();

                                //            //    if (Report == enum_ReportName.CU_SalesSummaryReport_YTD)
                                //            //    {
                                //            //        #region Grouping List - Sales Summary YTD
                                //            //        List<cls_sasSalesReportSummaryYTD_DTO> lstSalesYTD = lstSales.GroupBy(r => new { r.Branch, r.TxDate.Month, r.SalesRep, r.CustomerClass, r.CustomerType, r.CustomerCategory })
                                //            //                                        .Select(grp => new cls_sasSalesReportSummaryYTD_DTO
                                //            //                                        {
                                //            //                                            Branch = grp.Key.Branch,
                                //            //                                            SalesRep = grp.Key.SalesRep,
                                //            //                                            CustomerClass = grp.Key.CustomerClass,
                                //            //                                            CustomerType = grp.Key.CustomerType,
                                //            //                                            CustomerCategory = grp.Key.CustomerCategory,

                                //            //                                            April = grp.Key.Month == 4 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //            //                                            May = grp.Key.Month == 5 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //            //                                            June = grp.Key.Month == 6 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //            //                                            July = grp.Key.Month == 7 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //            //                                            August = grp.Key.Month == 8 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //            //                                            September = grp.Key.Month == 9 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //            //                                            October = grp.Key.Month == 10 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //            //                                            November = grp.Key.Month == 11 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //            //                                            December = grp.Key.Month == 12 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //            //                                            January = grp.Key.Month == 1 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //            //                                            February = grp.Key.Month == 2 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //            //                                            March = grp.Key.Month == 3 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,

                                //            //                                            TotalQty = grp.Sum(r => r.SalesQty) - grp.Sum(r => r.ReturnQty)
                                //            //                                        }).ToList();
                                //            //        #endregion

                                //            //        cls_sasSalesReportSummary_YTD.SalesReportSummary_YTD(lstSalesYTD, dtFromDate, dtToDate, sReportTitle_Main);
                                //            //    }
                                //            //    else
                                //            //    {
                                //            //        cls_sasSalesReportSummary.SalesReportSummary(lstSales, dtFromDate, dtToDate, sReportTitle_Main);
                                //            //    }
                                //            //}
                                //            #endregion
                                //            #region Invoice Item
                                //            else
                                //            {
                                //                cls_sasSalesReportDetail_InvoiceItemWise.Run_SalesDetail_InvoiceItemWise(lstSales, dtFromDate, dtToDate, sReportTitle_Main);
                                //            }
                                //            #endregion
                                //        }
                                //        else
                                //        {
                                //            MessageBox.Show("Data Not Found", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //        }
                                //        #endregion
                                //    }
                                //    #endregion

                                //    #region Sales Summary Report & YTD
                                //    else if (Report == enum_ReportName.CU_SalesSummaryReport || Report == enum_ReportName.CU_SalesSummaryReport_YTD)
                                //    {
                                //        //Create list of Data Ojects
                                //        List<cls_sasSalesReportSummary_DTO> lstSales = new List<cls_sasSalesReportSummary_DTO>();

                                //        #region Fill Data Object List
                                //        #region Invoice
                                //        foreach (tbl_sasInvoice oInvoice in oInvoiceList)
                                //        {
                                //            bool bVATable = false, bNBTable = false, bSVATable = false;
                                //            decimal dDiscountPresentage_AVG = 0;
                                //            decimal dDiscounttotal = oInvoice.DiscountTotal + oInvoice.DiscountTotal1 + oInvoice.DiscountTotal2 + oInvoice.DiscountTotal3;
                                //            string sSalesmanID = "";

                                //            tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oInvoice.Customer_ID).FirstOrDefault();
                                //            if (oCustomer != null)
                                //            {
                                //                #region Filters
                                //                #region Customer Filters
                                //                if (bCustomerClassSelected)
                                //                    if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
                                //                        continue;
                                //                if (bCustomerTypeSelected)
                                //                    if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
                                //                        continue;
                                //                if (bCustomerCategorySelected)
                                //                    if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
                                //                        continue;
                                //                #endregion

                                //                #region Sales Rep Filter
                                //                if (!chkUseCustomerMastorSaleRep.Checked)
                                //                {
                                //                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                //                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                //                        sSalesmanID = oRef.Employee_ID;
                                //                }
                                //                else
                                //                    sSalesmanID = oCustomer.SalesRep_ID;


                                //                if (bSelesRepSelected)
                                //                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                //                        continue;
                                //                #endregion
                                //                #endregion

                                //                #region Bulk Discount Presentage
                                //                if (dDiscounttotal != 0)
                                //                    dDiscountPresentage_AVG = dDiscounttotal * 100 / oInvoice.SubTotal;
                                //                #endregion

                                //                #region Tax
                                //                if (oInvoice.IsVatInvoice)
                                //                {
                                //                    bVATable = true;
                                //                    bNBTable = true;
                                //                }
                                //                else if (oInvoice.IsSVatInvoice)
                                //                {
                                //                    bSVATable = true;
                                //                    bNBTable = true;
                                //                }
                                //                #endregion

                                //                #region Transaction Detail 
                                //                foreach (tbl_sasInvoice_Detail oDetail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID).OrderBy(r => r.Line_No))
                                //                {
                                //                    decimal dMultificationFactor = 0, dItemWise_GrandTotal = 0, dNBTAmount = 0, dVATAmount = 0, dSVATAmount = 0, dSubTotal = 0, dAmountBeforeLineDiscount = 0, dBulkDiscount = 0, dLineDiscount = 0;

                                //                    if (oInvoice.SubTotal != 0)
                                //                        dMultificationFactor = oDetail.TatalAmount / oInvoice.SubTotal;

                                //                    dItemWise_GrandTotal = oInvoice.GrandTotal * dMultificationFactor;

                                //                    if (dDiscountPresentage_AVG == 100)
                                //                    {
                                //                        oDetail.BIsFreeItem = true;
                                //                        dDiscountPresentage_AVG = 0;
                                //                    }
                                //                    clsHelpMethods.CalculateGrandTotalReverce(dItemWise_GrandTotal, ref dVATAmount, oInvoice.VatPercentage, bVATable, ref dSVATAmount, oInvoice.OtherTaxPercentage, bSVATable, ref dNBTAmount, oInvoice.NbtPercentage, bNBTable, ref dBulkDiscount, dDiscountPresentage_AVG, ref dSubTotal);

                                //                    if (oDetail.BIsFreeItem || oDetail.DiscountPresentage == 100)
                                //                    {
                                //                        dAmountBeforeLineDiscount = oDetail.Qty * oDetail.UnitPrice;
                                //                        dLineDiscount = dAmountBeforeLineDiscount;
                                //                    }
                                //                    else
                                //                    {
                                //                        dAmountBeforeLineDiscount = (dSubTotal / (100 - oDetail.DiscountPresentage) * 100);
                                //                        dLineDiscount = dAmountBeforeLineDiscount - dSubTotal;
                                //                    }

                                //                    lstSales.Add(new cls_sasSalesReportSummary_DTO()
                                //                    {
                                //                        TxType = "1-Sales",
                                //                        Branch = clsGenaralName.getName_CompanyBranchMaster(oInvoice.CompanyBranch_ID),
                                //                        Tx_ID = oInvoice.Invoice_ID,
                                //                        TxDate = oInvoice.InvoiceDate.Date,
                                //                        SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
                                //                        Customer = clsGenaralName.getName_Customer(oInvoice.Customer_ID),
                                //                        CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
                                //                        CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
                                //                        CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

                                //                        Sale = dAmountBeforeLineDiscount - (dBulkDiscount + dLineDiscount),
                                //                        SalesReturn = 0,
                                //                        CreditNote = 0,
                                //                        DebitNote = 0,

                                //                        SalesQty = oDetail.Qty,
                                //                        ReturnQty = 0,
                                //                    });
                                //                }
                                //                #endregion

                                //                clsHelpMethods_Local.startProgressBar(0, oInvoiceList.Count, 1, ProgressBar);
                                //            }
                                //        }
                                //        ProgressBar.Value = 0;
                                //        #endregion
                                //        #region SRN
                                //        foreach (tbl_sasSalesReturnedNote oSrn in oSrnList)
                                //        {
                                //            bool bVATable = false, bNBTable = false, bSVATable = false;
                                //            decimal dDiscountPresentage_AVG = 0;
                                //            decimal dDiscounttotal = oSrn.DiscountTotal;
                                //            string sSalesmanID = "";

                                //            tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oSrn.Customer_ID).FirstOrDefault();
                                //            if (oCustomer != null)
                                //            {
                                //                #region Filters
                                //                #region Customer Filters
                                //                if (bCustomerClassSelected)
                                //                    if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
                                //                        continue;
                                //                if (bCustomerTypeSelected)
                                //                    if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
                                //                        continue;
                                //                if (bCustomerCategorySelected)
                                //                    if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
                                //                        continue;
                                //                #endregion

                                //                #region Sales Rep Filter
                                //                if (!chkUseCustomerMastorSaleRep.Checked)
                                //                {
                                //                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oSrn.OrderRefNo_ID);
                                //                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                //                        sSalesmanID = oRef.Employee_ID;
                                //                }
                                //                else
                                //                    sSalesmanID = oCustomer.SalesRep_ID;

                                //                if (bSelesRepSelected)
                                //                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                //                        continue;
                                //                #endregion
                                //                #endregion

                                //                #region Bulk Discount Presentage
                                //                if (dDiscounttotal != 0)
                                //                    dDiscountPresentage_AVG = dDiscounttotal * 100 / oSrn.SubTotal;
                                //                #endregion

                                //                #region Tax
                                //                if (oSrn.VatTotal > 0)
                                //                {
                                //                    bVATable = true;
                                //                    bNBTable = true;
                                //                }
                                //                else if (oSrn.OtherTaxTotal > 0)
                                //                {
                                //                    bSVATable = true;
                                //                    bNBTable = true;
                                //                }
                                //                #endregion

                                //                #region Transaction Detail 
                                //                foreach (tbl_sasSalesReturnedNote_Detail oDetail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSrn.SalesReturnedNote_ID).OrderBy(r => r.Line_No))
                                //                {
                                //                    decimal dMultificationFactor = 0, dItemWise_GrandTotal = 0, dNBTAmount = 0, dVATAmount = 0, dSVATAmount = 0, dSubTotal = 0, dAmountBeforeLineDiscount = 0, dBulkDiscount = 0, dLineDiscount = 0;

                                //                    if (oSrn.SubTotal != 0)
                                //                        dMultificationFactor = oDetail.TatalAmount / oSrn.SubTotal;

                                //                    dItemWise_GrandTotal = oSrn.GrandTotal * dMultificationFactor;

                                //                    if (dDiscountPresentage_AVG == 100)
                                //                    {
                                //                        oDetail.BIsFreeItem = true;
                                //                        dDiscountPresentage_AVG = 0;
                                //                    }

                                //                    clsHelpMethods.CalculateGrandTotalReverce(dItemWise_GrandTotal, ref dVATAmount, oSrn.VatPercentage, bVATable, ref dSVATAmount, oSrn.OtherTaxPercentage, bSVATable, ref dNBTAmount, oSrn.NbtPercentage, bNBTable, ref dBulkDiscount, dDiscountPresentage_AVG, ref dSubTotal);

                                //                    if (oDetail.BIsFreeItem || oDetail.DiscountPresentage == 100)
                                //                    {
                                //                        dAmountBeforeLineDiscount = oDetail.Qty * oDetail.UnitPrice;
                                //                        dLineDiscount = dAmountBeforeLineDiscount;
                                //                    }
                                //                    else
                                //                    {
                                //                        dAmountBeforeLineDiscount = (dSubTotal / (100 - oDetail.DiscountPresentage) * 100);
                                //                        dLineDiscount = dAmountBeforeLineDiscount - dSubTotal;
                                //                    }

                                //                    decimal dUnitPrice = dAmountBeforeLineDiscount / oDetail.Qty;

                                //                    lstSales.Add(new cls_sasSalesReportSummary_DTO()
                                //                    {
                                //                        TxType = "2-Sales Return",
                                //                        Branch = clsGenaralName.getName_CompanyBranchMaster(oSrn.CompanyBranch_ID),
                                //                        Tx_ID = oSrn.SalesReturnedNote_ID,
                                //                        TxDate = oSrn.SalesReturnedNoteDate.Date,
                                //                        SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
                                //                        Customer = clsGenaralName.getName_Customer(oSrn.Customer_ID),
                                //                        CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
                                //                        CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
                                //                        CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

                                //                        Sale = 0,
                                //                        SalesReturn = (dAmountBeforeLineDiscount - (dBulkDiscount + dLineDiscount)),
                                //                        CreditNote = 0,
                                //                        DebitNote = 0,

                                //                        SalesQty = 0,
                                //                        ReturnQty = oDetail.Qty
                                //                    });
                                //                }
                                //                #endregion

                                //                clsHelpMethods_Local.startProgressBar(0, oSrnList.Count, 1, ProgressBar);
                                //            }
                                //        }
                                //        ProgressBar.Value = 0;
                                //        #endregion
                                //        #region CRN
                                //        foreach (tbl_bpsCreditNote oCrn in oCrnList.Where(p => p.SalesReturnedNote_ID == "default" && p.PosReturnTransaction_Index == -1 && p.AdvanceReceived_Index == -1 && p.CreditNoteType_ID == "TP/002" || p.CreditNoteType_ID == "TP/007" || p.CreditNoteType_ID == "TP/004" || p.CreditNoteType_ID == "TP/005"))
                                //        {
                                //            bool bVATable = false, bNBTable = false, bSVATable = false;
                                //            decimal dDiscountPresentage_AVG = 0;
                                //            decimal dDiscounttotal = oCrn.DiscountTotal;
                                //            string sSalesmanID = "";

                                //            tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oCrn.Customer_ID).FirstOrDefault();
                                //            if (oCustomer != null)
                                //            {
                                //                #region Filters
                                //                #region Customer Filters
                                //                if (bCustomerClassSelected)
                                //                    if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
                                //                        continue;
                                //                if (bCustomerTypeSelected)
                                //                    if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
                                //                        continue;
                                //                if (bCustomerCategorySelected)
                                //                    if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
                                //                        continue;
                                //                #endregion

                                //                #region Sales Rep Filter
                                //                if (!chkUseCustomerMastorSaleRep.Checked)
                                //                {
                                //                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oCrn.OrderRefNo_ID);
                                //                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                //                        sSalesmanID = oRef.Employee_ID;
                                //                }
                                //                else
                                //                    sSalesmanID = oCustomer.SalesRep_ID;


                                //                if (bSelesRepSelected)
                                //                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                //                        continue;
                                //                #endregion

                                //                #region Sales Note Filter
                                //                if (bSalesNoteTypeSelected)
                                //                    if (txtSalesNoteType.Tag.ToString() != oCrn.SalesNoteType_ID)
                                //                        continue;
                                //                #endregion
                                //                #endregion

                                //                #region Bulk Discount Presentage
                                //                if (dDiscounttotal != 0)
                                //                    dDiscountPresentage_AVG = dDiscounttotal * 100 / oCrn.SubTotal;
                                //                #endregion

                                //                #region Tax
                                //                if (oCrn.VatTotal > 0)
                                //                {
                                //                    bVATable = true;
                                //                    bNBTable = true;
                                //                }
                                //                else if (oCrn.OtherTaxTotal > 0)
                                //                {
                                //                    bSVATable = true;
                                //                    bNBTable = true;
                                //                }
                                //                #endregion

                                //                #region Detail Fill
                                //                decimal dItemWise_GrandTotal = oCrn.TotalAmount, dNBTAmount = 0, dVATAmount = 0, dSVATAmount = 0, dSubTotal = 0, dBulkDiscount = 0;
                                //                clsHelpMethods.CalculateGrandTotalReverce(dItemWise_GrandTotal, ref dVATAmount, oCrn.VatPercentage, bVATable, ref dSVATAmount, oCrn.OtherTaxPercentage, bSVATable, ref dNBTAmount, oCrn.NbtPercentage, bNBTable, ref dBulkDiscount, dDiscountPresentage_AVG, ref dSubTotal);

                                //                lstSales.Add(new cls_sasSalesReportSummary_DTO()
                                //                {
                                //                    TxType = "3-Credit Note",
                                //                    Branch = clsGenaralName.getName_CompanyBranchMaster(oCrn.CompanyBranch_ID),
                                //                    Tx_ID = oCrn.CreditNote_ID,
                                //                    TxDate = oCrn.CreditNoteDate.Date,
                                //                    SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
                                //                    Customer = clsGenaralName.getName_Customer(oCrn.Customer_ID),
                                //                    CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
                                //                    CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
                                //                    CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

                                //                    Sale = 0,
                                //                    SalesReturn = 0,
                                //                    CreditNote = dSubTotal + dBulkDiscount,
                                //                    DebitNote = 0,

                                //                    SalesQty = 0,
                                //                    ReturnQty = 0
                                //                });
                                //                #endregion

                                //                clsHelpMethods_Local.startProgressBar(0, oCrnList.Count, 1, ProgressBar);
                                //            }
                                //        }
                                //        ProgressBar.Value = 0;
                                //        #endregion
                                //        #region DBN
                                //        foreach (tbl_bpsDebitNote oDbn in oDbnList.Where(p => p.DebitNoteType_ID == "TP/003"))
                                //        {
                                //            string sSalesmanID = "";
                                //            tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oDbn.Customer_ID).FirstOrDefault();
                                //            if (oCustomer != null)
                                //            {
                                //                #region Filters
                                //                #region Customer Filters
                                //                if (bCustomerClassSelected)
                                //                    if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
                                //                        continue;
                                //                if (bCustomerTypeSelected)
                                //                    if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
                                //                        continue;
                                //                if (bCustomerCategorySelected)
                                //                    if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
                                //                        continue;
                                //                #endregion

                                //                #region Sales Rep Filter
                                //                if (!chkUseCustomerMastorSaleRep.Checked)
                                //                {
                                //                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oDbn.OrderRefNo_ID);
                                //                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                //                        sSalesmanID = oRef.Employee_ID;
                                //                }
                                //                else
                                //                    sSalesmanID = oCustomer.SalesRep_ID;


                                //                if (bSelesRepSelected)
                                //                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                //                        continue;
                                //                #endregion

                                //                #region Sales Note Filter
                                //                if (bSalesNoteTypeSelected)
                                //                    if (txtSalesNoteType.Tag.ToString() != oDbn.SalesNoteType_ID)
                                //                        continue;
                                //                #endregion
                                //                #endregion

                                //                bool bVATable = false, bNBTable = false, bSVATable = false;
                                //                decimal dDiscountPresentage_AVG = 0;
                                //                decimal dDiscounttotal = oDbn.DiscountTotal;

                                //                #region Bulk Discount Presentage
                                //                if (dDiscounttotal != 0)
                                //                    dDiscountPresentage_AVG = dDiscounttotal * 100 / oDbn.SubTotal;
                                //                #endregion

                                //                #region Tax
                                //                if (oDbn.VatTotal > 0)
                                //                {
                                //                    bVATable = true;
                                //                    bNBTable = true;
                                //                }
                                //                else if (oDbn.OtherTaxTotal > 0)
                                //                {
                                //                    bSVATable = true;
                                //                    bNBTable = true;
                                //                }
                                //                #endregion

                                //                #region Detail Fill
                                //                decimal dItemWise_GrandTotal = oDbn.TotalAmount, dNBTAmount = 0, dVATAmount = 0, dSVATAmount = 0, dSubTotal = 0, dBulkDiscount = 0;
                                //                clsHelpMethods.CalculateGrandTotalReverce(dItemWise_GrandTotal, ref dVATAmount, oDbn.VatPercentage, bVATable, ref dSVATAmount, oDbn.OtherTaxPercentage, bSVATable, ref dNBTAmount, oDbn.NbtPercentage, bNBTable, ref dBulkDiscount, dDiscountPresentage_AVG, ref dSubTotal);

                                //                lstSales.Add(new cls_sasSalesReportSummary_DTO()
                                //                {
                                //                    TxType = "4-Debit Note",
                                //                    Branch = clsGenaralName.getName_CompanyBranchMaster(oDbn.CompanyBranch_ID),
                                //                    Tx_ID = oDbn.DebitNote_ID,
                                //                    TxDate = oDbn.DebitNoteDate.Date,
                                //                    SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
                                //                    Customer = clsGenaralName.getName_Customer(oDbn.Customer_ID),
                                //                    CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
                                //                    CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
                                //                    CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

                                //                    Sale = 0,
                                //                    SalesReturn = 0,
                                //                    CreditNote = 0,
                                //                    DebitNote = dSubTotal + dBulkDiscount,

                                //                    SalesQty = 0,
                                //                    ReturnQty = 0
                                //                });
                                //                #endregion

                                //                clsHelpMethods_Local.startProgressBar(0, oDbnList.Count, 1, ProgressBar);
                                //            }
                                //        }
                                //        ProgressBar.Value = 0;
                                //        #endregion
                                //        #region POS Transaction
                                //        foreach (tbl_posTransaction oPos in oPosList)
                                //        {
                                //            decimal dDiscountPresentage_AVG = 0;
                                //            decimal dDiscounttotal = oPos.DiscountTotal;
                                //            string sSalesmanID = "";
                                //            tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oPos.Customer_ID).FirstOrDefault();
                                //            if (oCustomer != null)
                                //            {
                                //                #region Filters
                                //                #region Customer Filters
                                //                if (bCustomerClassSelected)
                                //                    if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
                                //                        continue;
                                //                if (bCustomerTypeSelected)
                                //                    if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
                                //                        continue;
                                //                if (bCustomerCategorySelected)
                                //                    if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
                                //                        continue;
                                //                #endregion

                                //                #region Sales Rep Filter
                                //                //if (!chkUseCustomerMastorSaleRep.Checked)
                                //                //{
                                //                //    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oPos.OrderRefNo_ID);
                                //                //    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                //                //        sSalesmanID = oRef.Employee_ID;
                                //                //}
                                //                //else
                                //                sSalesmanID = oCustomer.SalesRep_ID;

                                //                if (bSelesRepSelected)
                                //                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                //                        continue;
                                //                #endregion
                                //                #endregion

                                //                #region Bulk Discount
                                //                if (dDiscounttotal != 0)
                                //                    dDiscountPresentage_AVG = dDiscounttotal * 100 / oPos.SubTotal;
                                //                if (oPos.SubTotal < 0)
                                //                    dDiscountPresentage_AVG *= -1;
                                //                #endregion

                                //                #region Transaction Detail
                                //                foreach (tbl_posTransaction_Detail oDetail in tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oPos.PosTransaction_Index))
                                //                {
                                //                    decimal dMultificationFactor = 0, dItemWise_GrandTotal = 0, dNBTAmount = 0, dVATAmount = 0, dSVATAmount = 0, dSubTotal = 0, dAmountBeforeLineDiscount = 0, dBulkDiscount = 0, dLineDiscount = 0;

                                //                    if (oPos.SubTotal != 0)
                                //                        dMultificationFactor = oDetail.GrossAmount / oPos.SubTotal;

                                //                    dItemWise_GrandTotal = oPos.GrandTotal * dMultificationFactor;

                                //                    if (dDiscountPresentage_AVG == 100)
                                //                    {
                                //                        oDetail.BIsFreeItem = true;
                                //                        dDiscountPresentage_AVG = 0;
                                //                    }

                                //                    clsHelpMethods.CalculateGrandTotalReverce(dItemWise_GrandTotal, ref dVATAmount, oPos.VatPercentage, true, ref dSVATAmount, oPos.OtherTaxPercentage, false, ref dNBTAmount, oPos.NbtPercentage, true, ref dBulkDiscount, dDiscountPresentage_AVG, ref dSubTotal);

                                //                    if (oDetail.BIsFreeItem || oDetail.LineDiscountPresentage == 100)
                                //                    {
                                //                        dAmountBeforeLineDiscount = oDetail.Qty * oDetail.UnitPrice;
                                //                        dLineDiscount = dAmountBeforeLineDiscount;
                                //                    }
                                //                    else
                                //                    {
                                //                        dAmountBeforeLineDiscount = (dSubTotal / (100 - oDetail.LineDiscountPresentage) * 100);
                                //                        dLineDiscount = dAmountBeforeLineDiscount - dSubTotal;
                                //                    }

                                //                    decimal dUnitPrice = dAmountBeforeLineDiscount / oDetail.Qty;

                                //                    lstSales.Add(new cls_sasSalesReportSummary_DTO()
                                //                    {
                                //                        TxType = "5-POS Sales & Return",
                                //                        Branch = clsGenaralName.getName_CompanyBranchMaster(oPos.CompanyBranch_ID),
                                //                        Tx_ID = oPos.PosTransaction_ID,
                                //                        TxDate = oPos.PosTransactiondate.Date,
                                //                        SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
                                //                        Customer = clsGenaralName.getName_Customer(oPos.Customer_ID),
                                //                        CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
                                //                        CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
                                //                        CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),


                                //                        Sale = !oPos.IsReturnedPOS_Invoice ? (dAmountBeforeLineDiscount - (dBulkDiscount + dLineDiscount)) : 0,
                                //                        SalesReturn = oPos.IsReturnedPOS_Invoice ? ((dAmountBeforeLineDiscount - (dBulkDiscount + dLineDiscount)) * -1) : 0,
                                //                        CreditNote = 0,
                                //                        DebitNote = 0,

                                //                        SalesQty = !oPos.IsReturnedPOS_Invoice ? oDetail.Qty : 0,
                                //                        ReturnQty = oPos.IsReturnedPOS_Invoice ? (oDetail.Qty * -1) : 0
                                //                    });
                                //                }


                                //                foreach (tbl_posReceipt oReceipt in tbl_posReceipt.SelectAllByPosTransaction_Index(oPos.PosTransaction_Index))
                                //                {
                                //                    foreach (tbl_bpsChequeRegister oChequeRegister in tbl_bpsChequeRegister.SelectAllByPosReceipt_ID(oReceipt.PosReceipt_ID).Where(p => p.PaymentMethod_ID == (int)PaymentMethod.Gift_Voucher))
                                //                    {
                                //                        decimal dGrandTotalWithout_Tax2 = 0;
                                //                        decimal dWithNbtAmount2 = 0, dNbtAmount2 = 0, dVatAmount2 = 0;

                                //                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oChequeRegister.Amount, oPos.VatPercentage, oPos.NbtPercentage, ref dWithNbtAmount2, ref dGrandTotalWithout_Tax2, ref dNbtAmount2, ref dVatAmount2);

                                //                        lstSales.Add(new cls_sasSalesReportSummary_DTO()
                                //                        {
                                //                            TxType = "5-POS Sales & Return",
                                //                            Branch = clsGenaralName.getName_CompanyBranchMaster(oPos.CompanyBranch_ID),
                                //                            Tx_ID = oPos.PosTransaction_ID,
                                //                            TxDate = oPos.PosTransactiondate.Date,
                                //                            SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
                                //                            Customer = clsGenaralName.getName_Customer(oPos.Customer_ID),
                                //                            CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
                                //                            CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
                                //                            CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

                                //                            Sale = !oPos.IsReturnedPOS_Invoice ? -dGrandTotalWithout_Tax2 : 0,
                                //                            SalesReturn = 0,
                                //                            CreditNote = 0,
                                //                            DebitNote = 0,

                                //                            SalesQty = 0,
                                //                            ReturnQty = 0
                                //                        });
                                //                    }
                                //                }
                                //                #endregion

                                //                clsHelpMethods_Local.startProgressBar(0, oPosList.Count, 1, ProgressBar);
                                //            }
                                //        }
                                //        ProgressBar.Value = 0;
                                //        #endregion
                                //        #endregion

                                //        if (lstSales.Count > 0)
                                //        {
                                //            if (Report == enum_ReportName.CU_SalesSummaryReport_YTD)
                                //            {
                                //                #region Grouping List
                                //                List<cls_sasSalesReportSummaryYTD_DTO> lstTemp = lstSales.GroupBy(r => new { r.Branch, r.TxDate.Month, r.SalesRep, r.CustomerClass, r.CustomerType, r.CustomerCategory })
                                //                                                .Select(grp => new cls_sasSalesReportSummaryYTD_DTO
                                //                                                {
                                //                                                    Branch = grp.Key.Branch,
                                //                                                    SalesRep = grp.Key.SalesRep,
                                //                                                    CustomerClass = grp.Key.CustomerClass,
                                //                                                    CustomerType = grp.Key.CustomerType,
                                //                                                    CustomerCategory = grp.Key.CustomerCategory,

                                //                                                    April = grp.Key.Month == 4 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //                                                    May = grp.Key.Month == 5 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //                                                    June = grp.Key.Month == 6 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //                                                    July = grp.Key.Month == 7 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //                                                    August = grp.Key.Month == 8 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //                                                    September = grp.Key.Month == 9 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //                                                    October = grp.Key.Month == 10 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //                                                    November = grp.Key.Month == 11 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //                                                    December = grp.Key.Month == 12 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //                                                    January = grp.Key.Month == 1 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //                                                    February = grp.Key.Month == 2 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,
                                //                                                    March = grp.Key.Month == 3 ? grp.Sum(r => r.Sale) - grp.Sum(r => r.SalesReturn) - grp.Sum(r => r.CreditNote) + grp.Sum(r => r.DebitNote) : 0,

                                //                                                    TotalQty = grp.Sum(r => r.SalesQty) - grp.Sum(r => r.ReturnQty)
                                //                                                }).ToList();
                                //                #endregion
                                //                //DataTable tempDt = clsHelpMethods_Local.ToDataTable(lstTemp.ToList());

                                //                cls_sasSalesReportSummary_YTD.SalesReportSummary_YTD(lstTemp, dtFromDate, dtToDate, sReportTitle_Main);
                                //            }
                                //            else
                                //            {
                                //                cls_sasSalesReportSummary.SalesReportSummary(lstSales, dtFromDate, dtToDate, sReportTitle_Main);
                                //            }
                                //        }
                                //        else
                                //        {
                                //            MessageBox.Show("Data Not Found", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //        }
                                //    }
                                //    #endregion

                                //    #region Collection Report Summary - Rep Wise
                                //    else if (Report == enum_ReportName.CU_CollectionReportSummary_RepWise)
                                //    {
                                //        List<cls_sasCollectionReportSummary_RepWise_DTO> lstCollection = new List<cls_sasCollectionReportSummary_RepWise_DTO>();
                                //        List<tbl_genCustomerMaster> vCustomers = tbl_genCustomerMaster.SelectAll().Where(r => !r.IsPOSCustomer && r.Customer_ID != "default").ToList();//&& !r.IsDeleted

                                //        //Branch Filter SQL Parameter
                                //        string sCompanyBranch_Filter_Param = "%%";
                                //        if (bBranchSelected)
                                //            sCompanyBranch_Filter_Param = txtBranch.Tag.ToString();

                                //        #region Fill Details
                                //        foreach (var vCustomer in vCustomers)
                                //        {
                                //            clsHelpMethods_Local.startProgressBar(0, vCustomers.Count() + 2, 1, ProgressBar);

                                //            #region Customer Filter
                                //            if (bCustomerSelected)
                                //                if (vCustomer.Customer_ID != txtCustomer.Tag.ToString())
                                //                    continue;
                                //            if (bCustomerClassSelected)
                                //                if (vCustomer.CustomerClass_ID != txtCusClass.Tag.ToString())
                                //                    continue;
                                //            if (bCustomerTypeSelected)
                                //                if (vCustomer.CustomerType_ID != txtCusType.Tag.ToString())
                                //                    continue;
                                //            if (bCustomerCategorySelected)
                                //                if (vCustomer.CustomerCategory_ID != txtCusCategory.Tag.ToString())
                                //                    continue;
                                //            //Sales Rep Filter - Customer Master
                                //            if (bSelesRepSelected && chkUseCustomerMastorSaleRep.Checked)
                                //                if (vCustomer.SalesRep_ID != txtSalesRep.Tag.ToString())
                                //                    continue;
                                //            #endregion

                                //            var vCustomerFin = tbl_genCustomerFinance.Select(vCustomer.Customer_ID);
                                //            if (vCustomerFin != null)
                                //            {
                                //                cls_sasCollectionReportSummary_RepWise_DTO oCollectionDetailRec = new cls_sasCollectionReportSummary_RepWise_DTO();
                                //                oCollectionDetailRec.Customer_Code = vCustomer.Customer_ID;
                                //                oCollectionDetailRec.Customer_Name = vCustomer.CustomerName;
                                //                oCollectionDetailRec.CustomerClass = vCustomer.CustomerClass_ID != "default" ? (clsGenaralName.getName_CustomerClass(vCustomer.CustomerClass_ID)) : "-";
                                //                oCollectionDetailRec.CustomerType = vCustomer.CustomerType_ID != "default" ? clsGenaralName.getName_CustomerType(vCustomer.CustomerType_ID) : "-";
                                //                oCollectionDetailRec.CustomerCategory = vCustomer.CustomerCategory_ID != "default" ? clsGenaralName.getName_CustomerCategory(vCustomer.CustomerCategory_ID) : "-";
                                //                oCollectionDetailRec.Credit_Period = vCustomerFin.CreditPeriod;
                                //                oCollectionDetailRec.Credit_Limit = vCustomerFin.CreditLimit;
                                //                oCollectionDetailRec.SalesRep = vCustomer.SalesRep_ID != "default" ? ("SALES REP : " + clsGenaralName.getName_SalesRep(vCustomer.SalesRep_ID)) : "-";
                                //                oCollectionDetailRec.Invoice_No = "N/A";

                                //                DataTable dtOSL = DBHandling.ExecQuery("sp_bssCustomerOutstanding '"
                                //                                              + vCustomer.CustomerClass_ID + "', '"
                                //                                              + vCustomer.CustomerType_ID + "', '"
                                //                                              + vCustomer.CustomerCategory_ID + "', '"
                                //                                              + vCustomer.Customer_ID + "', '"
                                //                                              + vCustomer.Route_ID + "', '"
                                //                                              + sCompanyBranch_Filter_Param + "' , '"
                                //                                              + "2001-01-01', '"
                                //                                              + dtpTo.Value.Date.Date + "', "
                                //                                              + false + ",  "
                                //                                              + true + "  , "
                                //                                              + chkUseCustomerMastorSaleRep.Checked).Tables[0];

                                //                //Sales Rep Filter - Transaction Level - SQL Parameter
                                //                string sSales_Rep_Filter = "%%";
                                //                if (bSelesRepSelected && chkUseCustomerMastorSaleRep.Checked)
                                //                    sSales_Rep_Filter = txtSalesRep.Tag.ToString();
                                //                string sLnqQuary = "employeeID Like '" + sSales_Rep_Filter + "' AND Amount <> 0 AND IsChequeInHand = false ";

                                //                //Outstanding Less than 60 days
                                //                var vResult_Less60 = dtOSL.Select(sLnqQuary + " AND age <" + 61);
                                //                if (vResult_Less60.Length > 0)
                                //                    oCollectionDetailRec.Less_Than_60_Days = vResult_Less60.Sum(x => x.Field<decimal>("Amount"));

                                //                //Outstanding More than or equal 60 days
                                //                var vResult_More60 = dtOSL.Select(sLnqQuary + " AND age >=" + 61);
                                //                if (vResult_More60.Length > 0)
                                //                    oCollectionDetailRec.Over_60_Days = vResult_More60.Sum(x => x.Field<decimal>("Amount"));

                                //                //Total Outstanding
                                //                oCollectionDetailRec.Total = (oCollectionDetailRec.Over_60_Days + oCollectionDetailRec.Less_Than_60_Days);

                                //                oCollectionDetailRec.Advance_Payment = DBHandling.ExecQuery_ReturnDecimal("exec [sp_Get_Payment_TotalAmount] '" + sCompanyBranch_Filter_Param + "' , '" + vCustomer.Customer_ID + "' , '" + dtFromDate.Date.ToString("yyyy-MM-dd") + "' , '" + dtToDate.Date.ToString("yyyy-MM-dd") + "' , '1'");
                                //                oCollectionDetailRec.PartFullPayment = DBHandling.ExecQuery_ReturnDecimal("exec [sp_Get_Payment_TotalAmount] '" + sCompanyBranch_Filter_Param + "' , '" + vCustomer.Customer_ID + "' , '" + dtFromDate.Date.ToString("yyyy-MM-dd") + "' , '" + dtToDate.Date.ToString("yyyy-MM-dd") + "' , '0'");
                                //                oCollectionDetailRec.Total_Collection_Amount = (oCollectionDetailRec.Advance_Payment + oCollectionDetailRec.PartFullPayment);

                                //                oCollectionDetailRec.Percentage = 0m;
                                //                var vOutstandingAndPayment = (oCollectionDetailRec.Total + oCollectionDetailRec.PartFullPayment);
                                //                if (vOutstandingAndPayment > 0)
                                //                    oCollectionDetailRec.Percentage = oCollectionDetailRec.Total_Collection_Amount / vOutstandingAndPayment;

                                //                // PD Cheques in Hand - No Date Period
                                //                oCollectionDetailRec.Pd_Cheques_InHand = DBHandling.ExecQuery_ReturnDecimal("exec [sp_Get_PD_Cheques_TotalAmount] '" + sCompanyBranch_Filter_Param + "' , '" + vCustomer.Customer_ID + "' , '" + dtToDate.Date.ToString("yyyy-MM-dd") + "'");

                                //                // Deposited Cheques, Not Realized - Within Date Period
                                //                oCollectionDetailRec.NotRealizedCheques = DBHandling.ExecQuery_ReturnDecimal("exec [sp_Get_NotRealized_Cheques_TotalAmount] '" + sCompanyBranch_Filter_Param + "' , '" + vCustomer.Customer_ID + "' , '" + dtFromDate.Date.ToString("yyyy-MM-dd") + "' , '" + dtToDate.Date.ToString("yyyy-MM-dd") + "'");

                                //                lstCollection.Add(oCollectionDetailRec);
                                //            }
                                //        }
                                //        #endregion

                                //        if (lstCollection.Count > 0)
                                //        {
                                //            cls_sasCollectionReportSummary_RepWise.Run_CollectionReportSummary(lstCollection, dtFromDate, dtToDate);
                                //        }
                                //        else
                                //        {
                                //            MessageBox.Show("Data Not Found", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //        }
                                //    }
                                //    #endregion

                                //    #region Sales Report - Pending Orders
                                //    if (Report == enum_ReportName.CU_PendingOrders)
                                //    {
                                //        List<cls_sasPendingOrders_DTO> lstSales = new List<cls_sasPendingOrders_DTO>();

                                //        #region Fill Data CustomerOrder
                                //        foreach (tbl_sasCustomerOrder oCO in oCOList)
                                //        {
                                //            string sSalesmanID = "", sRouteID = "";
                                //            tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oCO.Customer_ID).FirstOrDefault();
                                //            if (oCustomer != null)
                                //            {
                                //                #region Filters 

                                //                #region Customer Filters                                              
                                //                if (bCustomerTypeSelected)
                                //                    if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
                                //                        continue;
                                //                if (bCustomerCategorySelected)
                                //                    if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
                                //                        continue;
                                //                #endregion
                                                                                            
                                //                #region Route
                                //                if (bRouteSelected)
                                //                {
                                //                    if (!chkUseCustomerMasterRoute.Checked)
                                //                    {
                                //                        sRouteID = oCO.Route_ID.ToString();
                                //                    }
                                //                    else
                                //                    {
                                //                        foreach (tbl_genCustomerMaster_Branches oRoute in tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oCO.Customer_ID))
                                //                        {
                                //                            sRouteID = oRoute.Route_ID.ToString();
                                //                            if (txtRoute.Tag.ToString() == sRouteID)
                                //                                break;
                                //                        }
                                //                    }

                                //                    if (txtRoute.Tag.ToString() != sRouteID)
                                //                        continue;
                                //                }
                                //                #endregion

                                //                #region Sales Rep Filter
                                //                if (!chkUseCustomerMastorSaleRep.Checked)
                                //                {
                                //                    tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oCO.OrderRefNo_ID);
                                //                    if (oRef != null && oRef.OrderRefNo_ID != "default")
                                //                        sSalesmanID = oRef.Employee_ID;
                                //                }
                                //                else
                                //                    sSalesmanID = oCustomer.SalesRep_ID;


                                //                if (bSelesRepSelected)
                                //                    if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                //                        continue;
                                //                #endregion
                                //                #endregion

                                //                #region Transaction Detail 
                                //                foreach (tbl_sasCustomerOrder_Detail oDetail in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(oCO.CustomerOrder_ID).OrderBy(r => r.Line_No))
                                //                {
                                //                    if (!chkShowAllCO.Checked)
                                //                        if (oDetail.Qty <= oDetail.QtySettle_DeliveryOrder)
                                //                            continue;

                                //                        #region Item
                                //                        if (bItemSelected)
                                //                        if (oDetail.Item_ID != txtItemName.Tag.ToString())
                                //                            continue;
                                //                    #endregion

                                //                    #region Item Catagory
                                //                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oDetail.Item_ID);
                                //                    if (oItem != null && oItem.Item_ID != "default")
                                //                    {

                                //                        if (bItemCategorySelected)
                                //                        {
                                //                            if (oItem.ItemCategory_ID != txtItemCategory.Tag.ToString())
                                //                                continue;
                                //                        }
                                //                    }
                                //                    #endregion

                                //                    decimal dNetPrice = ((oDetail.UnitPrice * (100 - oDetail.DiscountPresentage)) / 100) *
                                //                                                ((100 - oCO.DiscountPercentage) / 100);
                                //                    dNetPrice = Math.Round(dNetPrice, 2);

                                //                    decimal dDisAmount = oDetail.UnitPrice - dNetPrice;
                                //                    dDisAmount = Math.Round(dDisAmount, 2);

                                //                    decimal dDisPercentage = 0;
                                //                    if (oDetail.UnitPrice != 0)
                                //                        dDisPercentage = (100 - ((dNetPrice * 100) / oDetail.UnitPrice)) / 100;

                                //                    lstSales.Add(new cls_sasPendingOrders_DTO()
                                //                    {
                                //                        CODate = oCO.CustomerOrderDate.Date,
                                //                        CONo = oCO.CustomerOrder_ID,
                                //                        CustomerName = clsGenaralName.getName_Customer(oCO.Customer_ID),
                                //                        Branch = clsGenaralName.getName_CompanyBranchMaster(oCO.CompanyBranch_ID),

                                //                        CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
                                //                        CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),
                                //                        SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
                                //                        ItemCode = oDetail.Item_ID,
                                //                        ItemDescription = clsGenaralName.getName_Item(oDetail.Item_ID),

                                //                        COQty = oDetail.Qty,
                                //                        DOQty = oDetail.QtySettle_DeliveryOrder,

                                //                        SellingPrice = oDetail.UnitPrice,

                                //                        DiscountPercentage = dDisPercentage,
                                //                        DiscountAmount = dDisAmount,
                                //                        NetPrice = dNetPrice,

                                //                        DeliveryDate = oCO.DeliveryDate.Date,
                                //                    });
                                //                }
                                //                #endregion

                                //                //clsHelpMethods_Local.startProgressBar(0, oInvoiceList.Count, 1, ProgressBar);
                                //            }
                                //        }
                                //        #endregion

                                //        #region Print Section
                                //        if (lstSales.Count > 0)
                                //        {
                                //            cls_sasPendingOrders.Run_SalesReport_PendingOrder(lstSales, dtFromDate, dtToDate, sReportTitle_Main);
                                //        }
                                //        else
                                //        {
                                //            MessageBox.Show("Data Not Found", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //        }
                                //        #endregion
                                //    }
                                //    #endregion
                                //}
                                //#endregion

                                #region Monthly Returns Against Sales - Indika (Excel)
                                //else if (Report == enum_ReportName.ST_MonthlyReturnsAgainst_Sales)
                                {
                                    try
                                    {
                                        DateTime dtFromDate_Init = dtToDate.AddMonths(-4).Date;
                                        DateTime dtFromDate_Temp = new DateTime(dtFromDate_Init.Year, dtFromDate_Init.Month, 1);

                                        string sSalesmanID = "";
                                        int iRouteID = -1, iMonth = 0;

                                        List<cls_sasMonthlyReturnsAgainst_Sales_DTO> oMonthlyReturnsList = new List<cls_sasMonthlyReturnsAgainst_Sales_DTO>();
                                        for (DateTime fromDate = dtFromDate_Temp.Date; fromDate <= dtToDate.Date; fromDate = fromDate.AddMonths(1))
                                        {
                                            ++iMonth;
                                            DateTime ToDate = fromDate.AddMonths(1).AddDays(-1);
                                            if (ToDate.Date > dtToDate.Date)
                                                ToDate = dtToDate;

                                            List<tbl_sasInvoice> oInvoicesList = tbl_sasInvoice.SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => !p.IsDeleted && !p.IsOpeningBalance && !p.IsReturnedCheque && !p.IsDebitNote && p.InvoiceDate.Date >= fromDate.Date && p.InvoiceDate.Date <= ToDate.Date).ToList();
                                            List<tbl_sasSalesReturnedNote> oSRNList = tbl_sasSalesReturnedNote.SelectAll().Where(p => p.CompanyBranch_ID == txtBranch.Tag.ToString() && !p.IsDeleted && p.SalesReturnedNoteDate.Date >= fromDate.Date && p.SalesReturnedNoteDate.Date <= ToDate.Date).ToList();

                                            #region INV
                                            //foreach (tbl_sasInvoice oInvoice in oInvoicesList)
                                            //{
                                            //    #region Route
                                            //    iRouteID = oInvoice.Route_ID;
                                            //    if (chkUseCustomerMasterRoute.Checked)
                                            //    {
                                            //        tbl_genCustomerMaster_Branches oRoute = tbl_genCustomerMaster_Branches.Select(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID));
                                            //        if (oRoute != null)
                                            //            iRouteID = oRoute.Route_ID;
                                            //    }

                                            //    if (bRouteSelected)
                                            //        if (txtRoute.Tag.ToString() != iRouteID.ToString())
                                            //            continue;
                                            //    #endregion

                                            //    #region Sales Rep Filter                                           
                                            //    if (!chkUseCustomerMastorSaleRep.Checked)
                                            //    {
                                            //        tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                            //        if (oRef != null && oRef.OrderRefNo != "default")
                                            //            sSalesmanID = oRef.Employee_ID;
                                            //    }
                                            //    else
                                            //    {
                                            //        tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                            //        if (oCustomer != null)
                                            //            sSalesmanID = oCustomer.SalesRep_ID;
                                            //    }

                                            //    if (bSelesRepSelected)
                                            //        if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                            //            continue;
                                            //    #endregion

                                            //    cls_sasMonthlyReturnsAgainst_Sales_DTO oMonthlyReturns = new cls_sasMonthlyReturnsAgainst_Sales_DTO(iRouteID == -1 ? "-" : clsGenaralName.get_RouteName(iRouteID),
                                            //        sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
                                            //        oInvoice.Invoice_ID, oInvoice.InvoiceDate, iMonth,
                                            //        oInvoice.GrandTotal, 0);

                                            //    oMonthlyReturnsList.Add(oMonthlyReturns);
                                            //}
                                            #endregion

                                            #region SRN
                                            //foreach (tbl_sasSalesReturnedNote oSRN in oSRNList)
                                            //{
                                            //    #region Route
                                            //    iRouteID = oSRN.Route_ID;
                                            //    if (chkUseCustomerMasterRoute.Checked)
                                            //    {
                                            //        tbl_genCustomerMaster_Branches oRoute = tbl_genCustomerMaster_Branches.Select(oSRN.Customer_ID, int.Parse(oSRN.Branch_ID));
                                            //        if (oRoute != null)
                                            //            iRouteID = oRoute.Route_ID;
                                            //    }

                                            //    if (bRouteSelected)
                                            //        if (txtRoute.Tag.ToString() != iRouteID.ToString())
                                            //            continue;
                                            //    #endregion

                                            //    #region Sales Rep Filter                                           
                                            //    if (!chkUseCustomerMastorSaleRep.Checked)
                                            //    {
                                            //        tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oSRN.OrderRefNo_ID);
                                            //        if (oRef != null && oRef.OrderRefNo != "default")
                                            //            sSalesmanID = oRef.Employee_ID;
                                            //    }
                                            //    else
                                            //    {
                                            //        tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oSRN.Customer_ID);
                                            //        if (oCustomer != null)
                                            //            sSalesmanID = oCustomer.SalesRep_ID;
                                            //    }

                                            //    if (bSelesRepSelected)
                                            //        if (txtSalesRep.Tag.ToString() != sSalesmanID)
                                            //            continue;
                                            //    #endregion

                                            //    cls_sasMonthlyReturnsAgainst_Sales_DTO oMonthlyReturns = new cls_sasMonthlyReturnsAgainst_Sales_DTO(iRouteID == -1 ? "-" : clsGenaralName.get_RouteName(iRouteID),
                                            //        sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
                                            //        oSRN.SalesReturnedNote_ID, oSRN.SalesReturnedNoteDate, iMonth,
                                            //        0, oSRN.GrandTotal);

                                            //    oMonthlyReturnsList.Add(oMonthlyReturns);
                                            //}
                                            #endregion
                                        }

                                        List<string> lstMonth = GetMonthYear(dtFromDate_Temp, dtToDate);

                                        List<cls_sasMonthlyReturnsAgainst_Sales_DTO_Temp> ListTemp = oMonthlyReturnsList
                                                .GroupBy(u => new { u.Month, u.SalesRep, u.Route })
                                                .Select(t => new cls_sasMonthlyReturnsAgainst_Sales_DTO_Temp
                                                {
                                                    Route = t.Key.Route,
                                                    SalesRep = t.Key.SalesRep,

                                                    MonthOneGross = t.Key.Month == 1 ? t.Sum(v => v.GrossValue) : 0,
                                                    MonthOneReturn = t.Key.Month == 1 ? t.Sum(v => v.ReturnValue) : 0,
                                                    MonthTwoGross = t.Key.Month == 2 ? t.Sum(v => v.GrossValue) : 0,
                                                    MonthTwoReturn = t.Key.Month == 2 ? t.Sum(v => v.ReturnValue) : 0,
                                                    MonthThreeGross = t.Key.Month == 3 ? t.Sum(v => v.GrossValue) : 0,
                                                    MonthThreeReturn = t.Key.Month == 3 ? t.Sum(v => v.ReturnValue) : 0,
                                                    MonthFourGross = t.Key.Month == 4 ? t.Sum(v => v.GrossValue) : 0,
                                                    MonthFourReturn = t.Key.Month == 4 ? t.Sum(v => v.ReturnValue) : 0,
                                                    MonthFiveGross = t.Key.Month == 5 ? t.Sum(v => v.GrossValue) : 0,
                                                    MonthFiveReturn = t.Key.Month == 5 ? t.Sum(v => v.ReturnValue) : 0
                                                })
                                                .ToList();

                                        if (ListTemp.Count > 0)
                                        {
                                            cls_sasMonthlyReturnsAgainst_Sales.MonthlyReturnsAgainst_Sales(ListTemp, dtFromDate_Temp, dtToDate, sReportTitle_Main, lstMonth);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Data Not Found", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                      //  clsValidate.WriteErrorLog("", iFormID, ex);
                                        MessageBox.Show(ex.Message);
                                    }
                                    finally
                                    {
                                        ProgressBar.Value = 0;
                                        Cursor = Cursors.Arrow;
                                    }
                                }
                                #endregion
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //clsValidate.WriteErrorLog("", iFormID, ex);
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        ProgressBar.Value = 0;
                        Cursor = Cursors.Arrow;
                    }
                }
            }
        }
        #endregion

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearField();

            dtpFrom.Value = clsSecurity.getServerDateTime();
            dtpTo.Value = clsSecurity.getServerDateTime();
        }
        #endregion

        #region ClearField
        private void clearField()
        {
            txtBranch.Tag = clsSecurity.BranchID;
            txtCustomer.Tag = null;
            txtCusClass.Tag = null;
            txtCusType.Tag = null;
            txtCusCategory.Tag = null;
            txtSalesRep.Tag = null;
            txtSalesNoteType.Tag = null;
            txtRoute.Tag = null;
            txtItemCategory.Tag = null;
            txtItemName.Tag = null;

            txtBranch.Text = clsSecurity.BranchName;
            txtCustomer.Text = "<All Customers>";
            txtCusClass.Text = "<All Classes>";
            txtCusType.Text = "<All Types>";
            txtCusCategory.Text = "<All Categories>";
            txtSalesRep.Text = "<All SalesReps>";
            txtSalesNoteType.Text = "<All Note Types>";
            txtRoute.Text = "<All Routes>";
            txtItemCategory.Text = "<All Categories>";
            txtItemName.Text = "<All Items>";

            clsCommon.SetEnableDisable_NormalCheckBox(chkShowAll, true);

            clsCommon.SetVisibility_Panel(pnlCustomer, false);
            clsCommon.SetVisibility_Panel(pnlCustomerCategory, false);
            clsCommon.SetVisibility_Panel(pnlCustomerClass, false);
            clsCommon.SetVisibility_Panel(pnlCustomerType, false);
            clsCommon.SetVisibility_Panel(pnlNoteType, false);
            clsCommon.SetVisibility_Panel(pnlSalesman, false);
            clsCommon.SetVisibility_Panel(pnlRoute, false);

            clsCommon.SetVisibility_Panel(pnlFromDate, false);
            clsCommon.SetVisibility_Panel(pnlToDate, false);
            clsCommon.SetVisibility_Panel(pnlShowAllCO, false);
            clsCommon.SetVisibility_Panel(pnlShowAllBranch, false);
            clsCommon.SetVisibility_Panel(pnlBranch, false);

            clsCommon.SetVisibility_Panel(pnlItemName, false);
            clsCommon.SetVisibility_Panel(pnlItemCategory, false);

            ckhShowAllCus.Checked = false;
            chkShowAll.Checked = false;
            chkUseCustomerMasterRoute.Checked = false;
            chkUseCustomerMastorSaleRep.Checked = false;

            txtCusCategory.Enabled = true;
            txtCusType.Enabled = true;
            txtCusClass.Enabled = true;
            txtItemCategory.Enabled = true;

            tbl_genCompanyBranchMaster oBranch = tbl_genCompanyBranchMaster.Select(clsSecurity.BranchID);
            if (oBranch != null)
            {
                if (!oBranch.IsHeadOffice)
                {
                    clsCommon.SetEnableDisable_NormalLabel(lblBranch, false);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBranch, false);
                    clsCommon.SetEnableDisable_NormalCheckBox(chkShowAll, false);
                }
            }
        }
        #endregion

        #region KeyDown Events
        private void txt_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerID();
        }
        private void txtSalesRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesRepID();
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


        private void txtRoute_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Routes();
        }
        #endregion

        #region Events DoublClick
        private void txtBranch_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_CompanyBranch(ref txtBranch);
        }
        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }
        private void txtSalesRep_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesRepID();
        }
        private void txtSalesNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesNoteType();
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
        private void txtRoute_DoubleClick(object sender, EventArgs e)
        {
            Search_Routes();
        }
        #endregion

        #region Search Methods
        private void Search_CustomerID()
        {
            //clsSearch.Search_MasterCustomer(ref txtCustomer, ckhShowAllCus.Checked);

            //if (txtCustomer.Tag != null)
            //{
            //    tbl_genCustomerMaster detail = tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString());
            //    if (detail != null && detail.Customer_ID != "default")
            //    {
            //        txtCusCategory.Tag = detail.CustomerCategory_ID;
            //        txtCusCategory.Text = clsGenaralName.getName_CustomerCategory(detail.CustomerCategory_ID);
            //        txtCusType.Tag = detail.CustomerType_ID;
            //        txtCusType.Text = clsGenaralName.getName_CustomerType(detail.CustomerType_ID);
            //        txtCusClass.Tag = detail.CustomerClass_ID;
            //        txtCusClass.Text = clsGenaralName.getName_CustomerClass(detail.CustomerClass_ID);

            //        txtCusCategory.Enabled = false;
            //        txtCusType.Enabled = false;
            //        txtCusClass.Enabled = false;
            //    }
            //}
        }

        private void Search_SalesRepID()
        {
            clsSearch.Search_MasterSalesRep(ref txtSalesRep);
        }

        private void Search_SalesNoteType()
        {
            clsSearch.Search_MasterSalesNoteType(ref txtSalesNoteType);
        }

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


        private void Search_Routes()
        {
            clsSearch.Search_MasterRoute(ref txtRoute);
        }

        private void txtItemCategory_DoubleClick(object sender, EventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ItemCategory);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtItemCategory.Tag = lstResult[0];
                txtItemCategory.Text = lstResult[1];
            }
        }

        private void txtItemName_DoubleClick(object sender, EventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = null;

            lstParameeters.Add(clsSecurity.BranchID);

            lstParameeters.Add("%%");
            lstParameeters.Add("%%");
            lstParameeters.Add(txtItemCategory.Tag == null ? "%%" : txtItemCategory.Tag.ToString());

            lstParameeters.Add("0");

            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.ItemMasterByCategories);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtItemName.Tag = lstResult[0];
                txtItemName.Text = lstResult[1];
            }

            if (txtItemName.Tag != null)
            {
                tbl_genItemMaster detail = tbl_genItemMaster.Select(txtItemName.Tag.ToString());
                if (detail != null && detail.Item_ID != "default")
                {
                    txtItemCategory.Tag = detail.ItemCategory_ID;
                    txtItemCategory.Text = clsGenaralName.getName_ItemCategory(detail.ItemCategory_ID);

                    txtItemCategory.Enabled = false;
                }
            }
        }
        #endregion

        #region Set Enable/Disable Controls
        private void setEnableDisableConctrol(int iReportID)
        {
            clearField();


            ////Customer / Sale Rep
            //if (iReportID == (int)enum_ReportName.CU_SalesDetailReport_InvoiceItemWise || iReportID == (int)enum_ReportName.CU_SalesDetailReport_InvoiceWise ||
            //    iReportID == (int)enum_ReportName.CU_SalesSummaryReport || iReportID == (int)enum_ReportName.CU_SalesSummaryReport_YTD ||
            //    iReportID == (int)enum_ReportName.CU_CollectionReportSummary_RepWise
            //    )
            //{
            //    clsCommon.SetVisibility_Panel(pnlBranch, true);
            //    clsCommon.SetVisibility_Panel(pnlCustomer, true);
            //    clsCommon.SetVisibility_Panel(pnlCustomerCategory, true);
            //    clsCommon.SetVisibility_Panel(pnlCustomerClass, true);
            //    clsCommon.SetVisibility_Panel(pnlCustomerType, true);
            //    clsCommon.SetVisibility_Panel(pnlNoteType, true);
            //    clsCommon.SetVisibility_Panel(pnlSalesman, true);
            //    clsCommon.SetVisibility_Panel(pnlRoute, true);
            //    clsCommon.SetVisibility_Panel(pnlFromDate, true);
            //    clsCommon.SetVisibility_Panel(pnlToDate, true);
            //    clsCommon.SetVisibility_Panel(pnlShowAllBranch, true);

            //    //From Date Visible
            //    dtpFrom.Visible = true;
            //    label1.Visible = true;

            //    //All Branch Selectiom
            //    chkShowAll.Visible = true;

            //    //Sales Note Type
            //    if (iReportID == (int)enum_ReportName.CU_SalesDetailReport_InvoiceItemWise || iReportID == (int)enum_ReportName.CU_SalesDetailReport_InvoiceWise)
            //    {
            //        clsCommon.SetVisibility_Panel(pnlNoteType, false);
            //        clsCommon.SetVisibility_Panel(pnlRoute, false);
            //    }

            //    //Collection Report Rep Wise
            //    if (iReportID == (int)enum_ReportName.CU_CollectionReportSummary_RepWise)
            //    {
            //        clsCommon.SetVisibility_Panel(pnlNoteType, false);
            //        clsCommon.SetVisibility_Panel(pnlRoute, false);
            //        chkUseCustomerMastorSaleRep.Checked = true;
            //    }

            //    //Sales Note Type
            //    if (iReportID == (int)enum_ReportName.CU_SalesSummaryReport || iReportID == (int)enum_ReportName.CU_SalesSummaryReport_YTD)
            //    {
            //        clsCommon.SetVisibility_Panel(pnlCustomer, false);
            //        clsCommon.SetVisibility_Panel(pnlRoute, false);
            //    }
            //}
            //else if (iReportID == (int)enum_ReportName.ST_MonthlyReturnsAgainst_Sales)
            //{
            //    clsCommon.SetVisibility_Panel(pnlRoute, true);
            //    clsCommon.SetVisibility_Panel(pnlSalesman, true);
            //    clsCommon.SetVisibility_Panel(pnlBranch, true);
            //    clsCommon.SetVisibility_Panel(pnlToDate, true);
            //    clsCommon.SetVisibility_Panel(pnlShowAllBranch, true);

            //    chkUseCustomerMasterRoute.Checked = true;
            //    chkUseCustomerMastorSaleRep.Checked = false;
            //}
            //else if (iReportID == (int)enum_ReportName.CU_PendingOrders)
            //{
            //    clsCommon.SetVisibility_Panel(pnlItemName, true);
            //    clsCommon.SetVisibility_Panel(pnlItemCategory, true);
            //    clsCommon.SetVisibility_Panel(pnlCustomer, true);
            //    clsCommon.SetVisibility_Panel(pnlCustomerCategory, true);
            //    clsCommon.SetVisibility_Panel(pnlCustomerType, true);
            //    clsCommon.SetVisibility_Panel(pnlSalesman, true);
            //    //clsCommon.SetVisibility_Panel(pnlRoute, true);
            //    clsCommon.SetVisibility_Panel(pnlFromDate, true);
            //    clsCommon.SetVisibility_Panel(pnlToDate, true);
            //    clsCommon.SetVisibility_Panel(pnlShowAllCO, true);
            //}
        }
        #endregion

        #region Data Grid Event
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

        #region Checked Changes
        private void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowAll.Checked == true)
            {
                clsCommon.SetVisibility_Panel(pnlBranch, false);
                txtBranch.Text = "<All Company Branches>";
                txtBranch.Tag = null;
            }
            else
            {
                clsCommon.SetVisibility_Panel(pnlBranch, true);
                txtBranch.Tag = clsSecurity.BranchID;
                txtBranch.Text = clsSecurity.BranchName;
            }
        }
        #endregion

        #region Help Methods
        public List<string> GetMonthYear(DateTime dtStart, DateTime dtEnd)
        {

            List<string> monthList = new List<string>();
            for (DateTime dt = dtStart; dt <= dtEnd; dt = dt.AddMonths(1))
            {
                monthList.Add(dt.ToString("MMMM yyyy"));
            }

            return monthList;
        }

        #endregion

    }
}






#region Fill Data Object List
//#region Invoice
//foreach (tbl_sasInvoice oInvoice in oInvoiceList)
//{
//    string sSalesmanID = "";
//    tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oInvoice.Customer_ID).FirstOrDefault();
//    if (oCustomer != null)
//    {


//        #region Filters
//        #region Customer Filters
//        if (bCustomerClassSelected)
//            if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                continue;
//        if (bCustomerTypeSelected)
//            if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                continue;
//        if (bCustomerCategorySelected)
//            if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                continue;
//        #endregion

//        #region Sales Rep Filter
//        if (!chkUseCustomerMastorSaleRep.Checked)
//        {
//            tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
//            if (oRef != null && oRef.OrderRefNo_ID != "default")
//                sSalesmanID = oRef.Employee_ID;
//        }
//        else
//            sSalesmanID = oCustomer.SalesRep_ID;

//        if (bSelesRepSelected)
//            if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                continue;
//        #endregion

//        #region Sales Note Filter
//        if (bSalesNoteTypeSelected)
//            if (txtSalesNoteType.Tag.ToString() != oInvoice.SalesNoteType_ID)
//                continue;
//        #endregion
//        #endregion

//        #region Tax
//        bool bVATable = false, bNBTable = false, bSVATable = false;
//        if (oInvoice.IsVatInvoice)
//        {
//            bVATable = true;
//            bNBTable = true;
//        }
//        else if (oInvoice.IsSVatInvoice)
//        {
//            bSVATable = true;
//            bNBTable = true;
//        }
//        #endregion

//        #region Detail Fill
//        decimal TotalQty = tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID).Sum(p => p.Qty);
//        decimal dNBTAmount = 0, dVATAmount = 0, dSVATAmount = 0, dSubTotal = 0, dBulkDiscount = 0;

//        clsHelpMethods.CalculateGrandTotalReverce(oInvoice.GrandTotal, ref dVATAmount, oInvoice.VatPercentage, bVATable, ref dSVATAmount, oInvoice.OtherTaxPercentage, bSVATable, ref dNBTAmount, oInvoice.NbtPercentage, bNBTable, ref dBulkDiscount, 0, ref dSubTotal);

//        lstSales.Add(new cls_sasSalesReportSummary_DTO()
//        {
//            TxType = "1-Sales",
//            Branch = clsGenaralName.getName_CompanyBranchMaster(oInvoice.CompanyBranch_ID),
//            Tx_ID = oInvoice.Invoice_ID,
//            TxDate = oInvoice.InvoiceDate.Date,
//            SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//            Customer = clsGenaralName.getName_Customer(oInvoice.Customer_ID),
//            CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
//            CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//            CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//            Sale = dSubTotal,
//            SalesReturn = 0,
//            CreditNote = 0,
//            DebitNote = 0,

//            SalesQty = TotalQty,
//            ReturnQty = 0,
//        });
//        #endregion

//        clsHelpMethods_Local.startProgressBar(0, oInvoiceList.Count, 1, ProgressBar);
//    }
//}
//ProgressBar.Value = 0;
//#endregion
//#region SRN
//foreach (tbl_sasSalesReturnedNote oSrn in oSrnList.Where(p => p.IsApproved == true))
//{
//    string sSalesmanID = "";
//    tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oSrn.Customer_ID).FirstOrDefault();
//    if (oCustomer != null)
//    {
//        #region Filters
//        #region Customer Filters
//        if (bCustomerClassSelected)
//            if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                continue;
//        if (bCustomerTypeSelected)
//            if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                continue;
//        if (bCustomerCategorySelected)
//            if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                continue;
//        #endregion

//        #region Sales Rep Filter
//        if (!chkUseCustomerMastorSaleRep.Checked)
//        {
//            tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oSrn.OrderRefNo_ID);
//            if (oRef != null && oRef.OrderRefNo_ID != "default")
//                sSalesmanID = oRef.Employee_ID;
//        }
//        else
//            sSalesmanID = oCustomer.SalesRep_ID;


//        if (bSelesRepSelected)
//            if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                continue;
//        #endregion

//        #region Sales Note Filter
//        if (bSalesNoteTypeSelected)
//            if (txtSalesNoteType.Tag.ToString() != oSrn.SalesNoteType_ID)
//                continue;
//        #endregion
//        #endregion

//        #region Tax
//        bool bVATable = false, bNBTable = false, bSVATable = false;
//        if (oSrn.VatTotal > 0)
//        {
//            bVATable = true;
//            bNBTable = true;
//        }
//        else if (oSrn.OtherTaxTotal > 0)
//        {
//            bSVATable = true;
//            bNBTable = true;
//        }
//        #endregion

//        #region Detail Fill
//        decimal TotalQty = tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSrn.SalesReturnedNote_ID).Sum(p => p.Qty);
//        decimal dNBTAmount = 0, dVATAmount = 0, dSVATAmount = 0, dSubTotal = 0, dBulkDiscount = 0;
//        clsHelpMethods.CalculateGrandTotalReverce(oSrn.GrandTotal, ref dVATAmount, oSrn.VatPercentage, bVATable, ref dSVATAmount, oSrn.OtherTaxPercentage, bSVATable, ref dNBTAmount, oSrn.NbtPercentage, bNBTable, ref dBulkDiscount, 0, ref dSubTotal);

//        lstSales.Add(new cls_sasSalesReportSummary_DTO()
//        {
//            TxType = "2-Sales Return",
//            Branch = clsGenaralName.getName_CompanyBranchMaster(oSrn.CompanyBranch_ID),
//            Tx_ID = oSrn.SalesReturnedNote_ID,
//            TxDate = oSrn.SalesReturnedNoteDate.Date,
//            SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//            Customer = clsGenaralName.getName_Customer(oSrn.Customer_ID),
//            CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
//            CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//            CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//            Sale = 0,
//            SalesReturn = dSubTotal,
//            CreditNote = 0,
//            DebitNote = 0,

//            SalesQty = 0,
//            ReturnQty = TotalQty
//        });
//        #endregion

//        clsHelpMethods_Local.startProgressBar(0, oSrnList.Count, 1, ProgressBar);
//    }
//}
//ProgressBar.Value = 0;
//#endregion
//#region CRN
//foreach (tbl_bpsCreditNote oCrn in oCrnList.Where(p => p.SalesReturnedNote_ID == "default" && p.PosReturnTransaction_Index == -1 && p.AdvanceReceived_Index == -1 && p.CreditNoteType_ID == "TP/002" || p.CreditNoteType_ID == "TP/007" || p.CreditNoteType_ID == "TP/004" || p.CreditNoteType_ID == "TP/005"))
//{
//    string sSalesmanID = "";
//    tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oCrn.Customer_ID).FirstOrDefault();
//    if (oCustomer != null)
//    {
//        #region Filters
//        #region Customer Filters
//        if (bCustomerClassSelected)
//            if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                continue;
//        if (bCustomerTypeSelected)
//            if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                continue;
//        if (bCustomerCategorySelected)
//            if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                continue;
//        #endregion

//        #region Sales Rep Filter
//        if (!chkUseCustomerMastorSaleRep.Checked)
//        {
//            tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oCrn.OrderRefNo_ID);
//            if (oRef != null && oRef.OrderRefNo_ID != "default")
//                sSalesmanID = oRef.Employee_ID;
//        }
//        else
//            sSalesmanID = oCustomer.SalesRep_ID;


//        if (bSelesRepSelected)
//            if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                continue;
//        #endregion

//        #region Sales Note Filter
//        if (bSalesNoteTypeSelected)
//            if (txtSalesNoteType.Tag.ToString() != oCrn.SalesNoteType_ID)
//                continue;
//        #endregion
//        #endregion

//        #region Tax
//        bool bVATable = false, bNBTable = false, bSVATable = false;
//        if (oCrn.VatTotal > 0)
//        {
//            bVATable = true;
//            bNBTable = true;
//        }
//        else if (oCrn.OtherTaxTotal > 0)
//        {
//            bSVATable = true;
//            bNBTable = true;
//        }
//        #endregion

//        #region Detail Fill
//        decimal dNBTAmount = 0, dVATAmount = 0, dSVATAmount = 0, dSubTotal = 0, dBulkDiscount = 0;
//        clsHelpMethods.CalculateGrandTotalReverce(oCrn.TotalAmount, ref dVATAmount, oCrn.VatPercentage, bVATable, ref dSVATAmount, oCrn.OtherTaxPercentage, bSVATable, ref dNBTAmount, oCrn.NbtPercentage, bNBTable, ref dBulkDiscount, 0, ref dSubTotal);

//        lstSales.Add(new cls_sasSalesReportSummary_DTO()
//        {
//            TxType = "3-Credit Note",
//            Branch = clsGenaralName.getName_CompanyBranchMaster(oCrn.CompanyBranch_ID),
//            Tx_ID = oCrn.CreditNote_ID,
//            TxDate = oCrn.CreditNoteDate.Date,
//            SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//            Customer = clsGenaralName.getName_Customer(oCrn.Customer_ID),
//            CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
//            CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//            CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//            Sale = 0,
//            SalesReturn = 0,
//            CreditNote = dSubTotal,
//            DebitNote = 0,

//            SalesQty = 0,
//            ReturnQty = 0
//        });
//        #endregion

//        clsHelpMethods_Local.startProgressBar(0, oCrnList.Count, 1, ProgressBar);
//    }
//}
//ProgressBar.Value = 0;
//#endregion
//#region DBN
//foreach (tbl_bpsDebitNote oDbn in oDbnList.Where(p => p.DebitNoteType_ID == "TP/003"))
//{
//    string sSalesmanID = "";
//    tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oDbn.Customer_ID).FirstOrDefault();
//    if (oCustomer != null)
//    {
//        #region Filters
//        #region Customer Filters
//        if (bCustomerClassSelected)
//            if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                continue;
//        if (bCustomerTypeSelected)
//            if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                continue;
//        if (bCustomerCategorySelected)
//            if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                continue;
//        #endregion

//        #region Sales Rep Filter
//        if (!chkUseCustomerMastorSaleRep.Checked)
//        {
//            tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oDbn.OrderRefNo_ID);
//            if (oRef != null && oRef.OrderRefNo_ID != "default")
//                sSalesmanID = oRef.Employee_ID;
//        }
//        else
//            sSalesmanID = oCustomer.SalesRep_ID;


//        if (bSelesRepSelected)
//            if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                continue;
//        #endregion

//        #region Sales Note Filter
//        if (bSalesNoteTypeSelected)
//            if (txtSalesNoteType.Tag.ToString() != oDbn.SalesNoteType_ID)
//                continue;
//        #endregion
//        #endregion

//        #region Tax
//        bool bVATable = false, bNBTable = false, bSVATable = false;
//        if (oDbn.VatTotal > 0)
//        {
//            bVATable = true;
//            bNBTable = true;
//        }
//        else if (oDbn.OtherTaxTotal > 0)
//        {
//            bSVATable = true;
//            bNBTable = true;
//        }
//        #endregion

//        #region Detail Fill
//        decimal dNBTAmount = 0, dVATAmount = 0, dSVATAmount = 0, dSubTotal = 0, dBulkDiscount = 0;
//        clsHelpMethods.CalculateGrandTotalReverce(oDbn.TotalAmount, ref dVATAmount, oDbn.VatPercentage, bVATable, ref dSVATAmount, oDbn.OtherTaxPercentage, bSVATable, ref dNBTAmount, oDbn.NbtPercentage, bNBTable, ref dBulkDiscount, 0, ref dSubTotal);

//        lstSales.Add(new cls_sasSalesReportSummary_DTO()
//        {
//            TxType = "4-Debit Note",
//            Branch = clsGenaralName.getName_CompanyBranchMaster(oDbn.CompanyBranch_ID),
//            Tx_ID = oDbn.DebitNote_ID,
//            TxDate = oDbn.DebitNoteDate.Date,
//            SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//            Customer = clsGenaralName.getName_Customer(oDbn.Customer_ID),
//            CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
//            CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//            CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//            Sale = 0,
//            SalesReturn = 0,
//            CreditNote = 0,
//            DebitNote = dSubTotal,

//            SalesQty = 0,
//            ReturnQty = 0
//        });
//        #endregion

//        clsHelpMethods_Local.startProgressBar(0, oDbnList.Count, 1, ProgressBar);
//    }
//}
//ProgressBar.Value = 0;
//#endregion
//#region POS Sales & Return
//foreach (tbl_posTransaction oPOS in oPosList)
//{
//    string sSalesmanID = "";
//    tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oPOS.Customer_ID).FirstOrDefault();
//    if (oCustomer != null)
//    {
//        #region Filters
//        #region Customer Filters
//        if (bCustomerClassSelected)
//            if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                continue;
//        if (bCustomerTypeSelected)
//            if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                continue;
//        if (bCustomerCategorySelected)
//            if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                continue;
//        #endregion

//        #region Sales Rep Filter
//        if (!chkUseCustomerMastorSaleRep.Checked)
//        {
//            tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oPOS.OrderRefNo_ID);
//            if (oRef != null && oRef.OrderRefNo_ID != "default")
//                sSalesmanID = oRef.Employee_ID;
//        }
//        else
//            sSalesmanID = oCustomer.SalesRep_ID;


//        if (bSelesRepSelected)
//            if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                continue;
//        #endregion

//        #region Sales Note Filter
//        if (bSalesNoteTypeSelected)
//            if (txtSalesNoteType.Tag.ToString() != oPOS.SalesNoteType_ID)
//                continue;
//        #endregion
//        #endregion

//        #region Tax
//        bool bVATable = false, bNBTable = false, bSVATable = false;
//        if (oPOS.VatTotal > 0)
//        {
//            bVATable = true;
//            bNBTable = true;
//        }
//        else if (oPOS.OtherTaxTotal > 0)
//        {
//            bSVATable = true;
//            bNBTable = true;
//        }
//        #endregion

//        #region Fill Detail
//        decimal TotalQty = tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oPOS.PosTransaction_Index).Sum(p => p.Qty);
//        decimal dNBTAmount = 0, dVATAmount = 0, dSVATAmount = 0, dSubTotal = 0, dBulkDiscount = 0;
//        clsHelpMethods.CalculateGrandTotalReverce(oPOS.GrandTotal, ref dVATAmount, oPOS.VatPercentage, bVATable, ref dSVATAmount, oPOS.OtherTaxPercentage, bSVATable, ref dNBTAmount, oPOS.NbtPercentage, bNBTable, ref dBulkDiscount, 0, ref dSubTotal);

//        lstSales.Add(new cls_sasSalesReportSummary_DTO()
//        {
//            TxType = "5-POS Sales & Return",
//            Branch = clsGenaralName.getName_CompanyBranchMaster(oPOS.CompanyBranch_ID),
//            Tx_ID = oPOS.PosTransaction_ID,
//            TxDate = oPOS.PosTransactiondate.Date,
//            SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//            Customer = clsGenaralName.getName_Customer(oPOS.Customer_ID),
//            CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
//            CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//            CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//            Sale = !oPOS.IsReturnedPOS_Invoice ? dSubTotal : 0,
//            SalesReturn = oPOS.IsReturnedPOS_Invoice ? dSubTotal * -1 : 0,
//            CreditNote = 0,
//            DebitNote = 0,

//            SalesQty = !oPOS.IsReturnedPOS_Invoice ? TotalQty : 0,
//            ReturnQty = oPOS.IsReturnedPOS_Invoice ? (TotalQty * -1) : 0
//        });


//        foreach (tbl_posReceipt oReceipt in tbl_posReceipt.SelectAllByPosTransaction_Index(oPOS.PosTransaction_Index))
//        {
//            foreach (tbl_bpsChequeRegister oChequeRegister in tbl_bpsChequeRegister.SelectAllByPosReceipt_ID(oReceipt.PosReceipt_ID).Where(p => p.PaymentMethod_ID == (int)PaymentMethod.Gift_Voucher))
//            {
//                decimal dNBTAmount2 = 0, dVATAmount2 = 0, dSVATAmount2 = 0, dSubTotal2 = 0, dBulkDiscount2 = 0;
//                clsHelpMethods.CalculateGrandTotalReverce(oChequeRegister.Amount, ref dVATAmount2, oPOS.VatPercentage, bVATable, ref dSVATAmount2, oPOS.OtherTaxPercentage, bSVATable, ref dNBTAmount2, oPOS.NbtPercentage, bNBTable, ref dBulkDiscount2, 0, ref dSubTotal2);

//                lstSales.Add(new cls_sasSalesReportSummary_DTO()
//                {
//                    TxType = "5-POS Sales & Return",
//                    Branch = clsGenaralName.getName_CompanyBranchMaster(oPOS.CompanyBranch_ID),
//                    Tx_ID = oPOS.PosTransaction_ID,
//                    TxDate = oPOS.PosTransactiondate.Date,
//                    SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//                    Customer = clsGenaralName.getName_Customer(oPOS.Customer_ID),
//                    CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
//                    CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//                    CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//                    Sale = !oPOS.IsReturnedPOS_Invoice ? -dSubTotal2 : 0,
//                    SalesReturn = 0,
//                    CreditNote = 0,
//                    DebitNote = 0,

//                    SalesQty = 0,
//                    ReturnQty = 0
//                });
//            }
//        }
//        #endregion

//        clsHelpMethods_Local.startProgressBar(0, oPosList.Count, 1, ProgressBar);
//    }
//}
//ProgressBar.Value = 0;
//#endregion
#endregion

#region Sales Summary Report - YTD
//else if (Report == enum_ReportName.CU_SalesSummaryReport_YTD)
//{
//    //Create list of Data Ojects
//    List<cls_sasSalesReportSummaryYTD_DTO> lstSales = new List<cls_sasSalesReportSummaryYTD_DTO>();

//    #region Fill Data Object List
//    #region Invoice
//    foreach (tbl_sasInvoice oInvoice in oInvoiceList)
//    {
//        string sSalesmanID = "";
//        tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oInvoice.Customer_ID).FirstOrDefault();
//        if (oCustomer != null)
//        {
//            #region Filters
//            #region Customer Filters
//            if (bCustomerClassSelected)
//                if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                    continue;
//            if (bCustomerTypeSelected)
//                if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                    continue;
//            if (bCustomerCategorySelected)
//                if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                    continue;
//            #endregion

//            #region Sales Rep Filter
//            if (!chkUseCustomerMastorSaleRep.Checked)
//            {
//                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
//                if (oRef != null && oRef.OrderRefNo_ID != "default")
//                    sSalesmanID = oRef.Employee_ID;
//            }
//            else
//                sSalesmanID = oCustomer.SalesRep_ID;


//            if (bSelesRepSelected)
//                if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                    continue;
//            #endregion

//            #region Sales Note Filter
//            if (bSalesNoteTypeSelected)
//                if (txtSalesNoteType.Tag.ToString() != oInvoice.SalesNoteType_ID)
//                    continue;
//            #endregion
//            #endregion

//            #region Detail Fill
//            decimal TotalQty = tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID).Sum(p => p.Qty);
//            decimal dGrandTotalWithout_Tax = oInvoice.GrandTotal - (oInvoice.VatTotal - oInvoice.NbtTotal);

//            lstSales.Add(new cls_sasSalesReportSummaryYTD_DTO()
//            {
//                TxType = "1-Sales",
//                Tx_ID = oInvoice.Invoice_ID,
//                TxDate = oInvoice.InvoiceDate.Date,
//                SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//                Customer = clsGenaralName.getName_Customer(oInvoice.Customer_ID),
//                CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
//                CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//                CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//                Sales = dGrandTotalWithout_Tax,
//                SalesReturn = 0,

//                SalesQty = TotalQty,
//                ReturnQty = 0
//            });
//            #endregion

//            clsHelpMethods_Local.startProgressBar(0, oInvoiceList.Count, 1, ProgressBar);
//        }
//    }
//    ProgressBar.Value = 0;
//    #endregion

//    #region SRN
//    foreach (tbl_sasSalesReturnedNote oSrn in oSrnList)
//    {
//        string sSalesmanID = "";
//        tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oSrn.Customer_ID).FirstOrDefault();
//        if (oCustomer != null)
//        {
//            #region Filters
//            #region Customer Filters
//            if (bCustomerClassSelected)
//                if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                    continue;
//            if (bCustomerTypeSelected)
//                if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                    continue;
//            if (bCustomerCategorySelected)
//                if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                    continue;
//            #endregion

//            #region Sales Rep Filter
//            if (!chkUseCustomerMastorSaleRep.Checked)
//            {
//                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oSrn.OrderRefNo_ID);
//                if (oRef != null && oRef.OrderRefNo_ID != "default")
//                    sSalesmanID = oRef.Employee_ID;
//            }
//            else
//                sSalesmanID = oCustomer.SalesRep_ID;


//            if (bSelesRepSelected)
//                if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                    continue;
//            #endregion

//            #region Sales Note Filter
//            if (bSalesNoteTypeSelected)
//                if (txtSalesNoteType.Tag.ToString() != oSrn.SalesNoteType_ID)
//                    continue;
//            #endregion
//            #endregion

//            #region Detail Fill
//            decimal TotalQty = tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSrn.SalesReturnedNote_ID).Sum(p => p.Qty);
//            decimal dGrandTotalWithout_Tax = oSrn.GrandTotal - (oSrn.VatTotal - oSrn.NbtTotal);

//            lstSales.Add(new cls_sasSalesReportSummaryYTD_DTO()
//            {
//                TxType = "2-Sales Return",
//                Tx_ID = oSrn.SalesReturnedNote_ID,
//                TxDate = oSrn.SalesReturnedNoteDate.Date,
//                SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//                Customer = clsGenaralName.getName_Customer(oSrn.Customer_ID),
//                CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
//                CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//                CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//                Sales = 0,
//                SalesReturn = dGrandTotalWithout_Tax,

//                SalesQty = 0,
//                ReturnQty = -TotalQty

//            });
//            #endregion

//            clsHelpMethods_Local.startProgressBar(0, oSrnList.Count, 1, ProgressBar);
//        }
//    }
//    ProgressBar.Value = 0;
//    #endregion

//    #region POS Sales
//    foreach (tbl_posTransaction oPOS in oPosList)
//    {
//        string sSalesmanID = "";
//        tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oPOS.Customer_ID).FirstOrDefault();
//        if (oCustomer != null)
//        {
//            #region Filters
//            #region Customer Filters
//            if (bCustomerClassSelected)
//                if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                    continue;
//            if (bCustomerTypeSelected)
//                if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                    continue;
//            if (bCustomerCategorySelected)
//                if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                    continue;
//            #endregion

//            #region Sales Rep Filter
//            if (!chkUseCustomerMastorSaleRep.Checked)
//            {
//                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oPOS.OrderRefNo_ID);
//                if (oRef != null && oRef.OrderRefNo_ID != "default")
//                    sSalesmanID = oRef.Employee_ID;
//            }
//            else
//                sSalesmanID = oCustomer.SalesRep_ID;


//            if (bSelesRepSelected)
//                if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                    continue;
//            #endregion

//            #region Sales Note Filter
//            if (bSalesNoteTypeSelected)
//                if (txtSalesNoteType.Tag.ToString() != oPOS.SalesNoteType_ID)
//                    continue;
//            #endregion
//            #endregion

//            #region Fill Detail
//            decimal dGrandTotalWithout_Tax = 0, BulkDiscount = oPOS.DiscountTotal;
//            decimal dWithNbtAmount = 0, dNbtAmount = 0, dVatAmount = 0;

//            decimal TotalQty = tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oPOS.PosTransaction_Index).Sum(p => p.Qty);
//            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oPOS.GrandTotal, oPOS.VatPercentage, oPOS.NbtPercentage, ref dWithNbtAmount, ref dGrandTotalWithout_Tax, ref dNbtAmount, ref dVatAmount);

//            lstSales.Add(new cls_sasSalesReportSummaryYTD_DTO()
//            {
//                TxType = "3-POS Sales & Return",
//                Tx_ID = oPOS.PosTransaction_ID,
//                TxDate = oPOS.PosTransactiondate.Date,
//                SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//                Customer = clsGenaralName.getName_Customer(oPOS.Customer_ID),
//                CustomerClass = clsGenaralName.getName_CustomerClass(oCustomer.CustomerClass_ID),
//                CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//                CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//                Sales = !oPOS.IsReturnedPOS_Invoice ? dGrandTotalWithout_Tax : 0,
//                SalesReturn = oPOS.IsReturnedPOS_Invoice ? (dGrandTotalWithout_Tax * -1) : 0,

//                SalesQty = !oPOS.IsReturnedPOS_Invoice ? TotalQty : 0,
//                ReturnQty = oPOS.IsReturnedPOS_Invoice ? (TotalQty * -1) : 0,

//                TotalCollection = 0,
//                TotalOutstanding = 0,
//                PostDatedCheques = 0,
//                UnrealizeCheques = 0,

//                CreditRisk = 0
//            });
//            #endregion

//            clsHelpMethods_Local.startProgressBar(0, oPosList.Count, 1, ProgressBar);
//        }
//    }
//    ProgressBar.Value = 0;
//    #endregion

//    #region Grouping List
//    List<cls_sasSalesReportSummaryYTD_DTO_Temp> lstTemp = lstSales.GroupBy(r => new { r.TxDate.Month, r.SalesRep, r.CustomerClass, r.CustomerType, r.CustomerCategory })
//                                    .Select(grp => new cls_sasSalesReportSummaryYTD_DTO_Temp
//                                    {
//                                        //Month = clsFormatter.GetMonthName(grp.Key.Month),
//                                        SalesRep = grp.Key.SalesRep,
//                                        CustomerClass = grp.Key.CustomerClass,
//                                        CustomerType = grp.Key.CustomerType,
//                                        CustomerCategory = grp.Key.CustomerCategory,

//                                        //TotalSales = grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn),

//                                        April = grp.Key.Month == 4 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        May = grp.Key.Month == 5 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        June = grp.Key.Month == 6 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        July = grp.Key.Month == 7 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        August = grp.Key.Month == 8 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        September = grp.Key.Month == 9 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        October = grp.Key.Month == 10 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        November = grp.Key.Month == 11 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        December = grp.Key.Month == 12 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        January = grp.Key.Month == 1 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        February = grp.Key.Month == 2 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,
//                                        March = grp.Key.Month == 3 ? grp.Sum(r => r.Sales) - grp.Sum(r => r.SalesReturn) : 0,

//                                        TotalQty = grp.Sum(r => r.SalesQty) - grp.Sum(r => r.ReturnQty),
//                                        TotalCollection = 0,
//                                        TotalOutstanding = 0,
//                                        PostDatedCheques = 0,
//                                        UnrealizeCheques = 0,
//                                        CreditRisk = 0
//                                    }).ToList();
//    #endregion
//    #endregion

//    if (lstTemp.Count > 0)
//    {
//        cls_sasSalesReportSummary_YTD.SalesReportSummary_YTD(lstTemp, dtFromDate, dtToDate, sReportTitle_Main);
//    }
//    else
//    {
//        MessageBox.Show("Data Not Found", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
//    }
//}
#endregion

#region Sales Report - Invoice Wice
//else if (Report == enum_ReportName.CU_SalesDetailReport_InvoiceWise)
//{
//    //Create list of Data Ojects-
//    List<cls_sasSalesReportDetail_InvoiceWise_DTO> lstSales = new List<cls_sasSalesReportDetail_InvoiceWise_DTO>();

//    #region Fill Data Object List
//    #region Invoice
//    foreach (tbl_sasInvoice oInvoice in oInvoiceList)
//    {
//        string sSalesmanID = "";
//        tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oInvoice.Customer_ID).FirstOrDefault();
//        if (oCustomer != null)
//        {
//            #region Filters
//            #region Customer Filters
//            if (bCustomerClassSelected)
//                if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                    continue;
//            if (bCustomerTypeSelected)
//                if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                    continue;
//            if (bCustomerCategorySelected)
//                if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                    continue;
//            #endregion

//            #region Sales Rep Filter 
//            if (!chkUseCustomerMastorSaleRep.Checked)
//            {
//                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
//                if (oRef != null && oRef.OrderRefNo_ID != "default")
//                    sSalesmanID = oRef.Employee_ID;
//            }
//            else
//                sSalesmanID = oCustomer.SalesRep_ID;

//            if (bSelesRepSelected)
//                if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                    continue;
//            #endregion
//            #endregion

//            #region Detail Fill
//            decimal dDiscountTotal_Flat = oInvoice.DiscountTotal + oInvoice.DiscountTotal1 + oInvoice.DiscountTotal2 + oInvoice.DiscountTotal3;

//            decimal dSubTotalWithoutDiscount = 0, dDiscountTotal = 0, dNetAmount = 0, TotalQty = 0, dLineDiscount = 0;
//            foreach (tbl_sasInvoice_Detail oDetail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID).OrderBy(r => r.Line_No))
//            {
//                TotalQty += oDetail.Qty;

//                if (oDetail.BIsFreeItem)
//                {
//                    dSubTotalWithoutDiscount += (oDetail.UnitPrice * oDetail.Qty);
//                    dLineDiscount += dSubTotalWithoutDiscount;
//                }
//                else
//                {
//                    dSubTotalWithoutDiscount += (oDetail.UnitPrice * oDetail.Qty);
//                    dLineDiscount += (oDetail.DiscountAmount * oDetail.Qty);
//                }
//            }
//            dDiscountTotal = (dLineDiscount + dDiscountTotal_Flat);
//            dNetAmount = dSubTotalWithoutDiscount - dDiscountTotal;

//            lstSales.Add(new cls_sasSalesReportDetail_InvoiceWise_DTO()
//            {
//                TxType = "1-Sales",
//                Tx_ID = oInvoice.Invoice_ID,
//                TxDate = oInvoice.InvoiceDate,
//                SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//                Customer = clsGenaralName.getName_Customer(oInvoice.Customer_ID),
//                CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//                CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//                TotalQty = TotalQty,

//                ItemAmount = dSubTotalWithoutDiscount,
//                Discount = dDiscountTotal,
//                SubTotal = dNetAmount,

//                NBTAmount = oInvoice.NbtTotal,
//                VATAmount = oInvoice.VatTotal,
//                GrandTotal = oInvoice.GrandTotal,
//                SVATAmount = oInvoice.OtherTaxTotal
//            });
//            #endregion

//            clsHelpMethods_Local.startProgressBar(0, oInvoiceList.Count, 1, ProgressBar);
//        }
//    }
//    ProgressBar.Value = 0;
//    #endregion

//    #region SRN
//    foreach (tbl_sasSalesReturnedNote oSrn in oSrnList)
//    {

//        string sSalesmanID = "";
//        tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oSrn.Customer_ID).FirstOrDefault();
//        if (oCustomer != null)
//        {
//            #region Filters
//            #region Customer Filters
//            if (bCustomerClassSelected)
//                if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                    continue;
//            if (bCustomerTypeSelected)
//                if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                    continue;
//            if (bCustomerCategorySelected)
//                if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                    continue;
//            #endregion

//            #region Sales Rep Filter
//            if (!chkUseCustomerMastorSaleRep.Checked)
//            {
//                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oSrn.OrderRefNo_ID);
//                if (oRef != null && oRef.OrderRefNo_ID != "default")
//                    sSalesmanID = oRef.Employee_ID;
//            }
//            else
//                sSalesmanID = oCustomer.SalesRep_ID;


//            if (bSelesRepSelected)
//                if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                    continue;
//            #endregion
//            #endregion

//            #region Detail Fill
//            decimal dSubTotalWithoutDiscount = 0, dDiscountTotal = 0, dNetAmount = 0, TotalQty = 0, dLineDiscount = 0;
//            foreach (tbl_sasSalesReturnedNote_Detail oDetail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSrn.SalesReturnedNote_ID))
//            {
//                TotalQty += oDetail.Qty;
//                if (oDetail.BIsFreeItem)
//                {
//                    dSubTotalWithoutDiscount += (oDetail.UnitPrice * oDetail.Qty);
//                    dLineDiscount += dSubTotalWithoutDiscount;
//                }
//                else
//                {
//                    dSubTotalWithoutDiscount += (oDetail.UnitPrice * oDetail.Qty);
//                    dLineDiscount += (oDetail.DiscountAmount * oDetail.Qty);
//                }
//            }

//            dDiscountTotal = (dLineDiscount + oSrn.DiscountTotal);
//            dNetAmount = dSubTotalWithoutDiscount - dDiscountTotal;


//            lstSales.Add(new cls_sasSalesReportDetail_InvoiceWise_DTO()
//            {
//                TxType = "2-Sales Return",
//                Tx_ID = oSrn.SalesReturnedNote_ID,
//                TxDate = oSrn.SalesReturnedNoteDate,
//                SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//                Customer = clsGenaralName.getName_Customer(oSrn.Customer_ID),
//                CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//                CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),

//                TotalQty = (TotalQty * -1),
//                ItemAmount = (dSubTotalWithoutDiscount * -1),
//                Discount = (dDiscountTotal * -1),
//                SubTotal = (dNetAmount * -1),

//                NBTAmount = (oSrn.NbtTotal * -1),
//                VATAmount = (oSrn.VatTotal * -1),
//                GrandTotal = (oSrn.GrandTotal * -1),
//                SVATAmount = (oSrn.OtherTaxTotal * -1)
//            });
//            #endregion

//            clsHelpMethods_Local.startProgressBar(0, oSrnList.Count, 1, ProgressBar);
//        }
//    }
//    ProgressBar.Value = 0;
//    #endregion

//    #region POS Sales
//    foreach (tbl_posTransaction oPOS in oPosList)
//    {
//        string sSalesmanID = "";
//        tbl_genCustomerMaster oCustomer = oCustomers.Where(p => p.Customer_ID == oPOS.Customer_ID).FirstOrDefault();
//        if (oCustomer != null)
//        {
//            #region Filters
//            #region Customer Filters
//            if (bCustomerClassSelected)
//                if (txtCusClass.Tag.ToString() != oCustomer.CustomerClass_ID)
//                    continue;
//            if (bCustomerTypeSelected)
//                if (txtCusType.Tag.ToString() != oCustomer.CustomerType_ID)
//                    continue;
//            if (bCustomerCategorySelected)
//                if (txtCusCategory.Tag.ToString() != oCustomer.CustomerCategory_ID)
//                    continue;
//            #endregion

//            #region Sales Rep Filter
//            if (!chkUseCustomerMastorSaleRep.Checked)
//            {
//                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oPOS.OrderRefNo_ID);
//                if (oRef != null && oRef.OrderRefNo_ID != "default")
//                    sSalesmanID = oRef.Employee_ID;
//            }
//            else
//                sSalesmanID = oCustomer.SalesRep_ID;

//            if (bSelesRepSelected)
//                if (txtSalesRep.Tag.ToString() != sSalesmanID)
//                    continue;
//            #endregion
//            #endregion

//            #region Fill Detail
//            decimal dSubTotalWithDiscount = 0, dDiscountTotal = 0, BulkDiscount = 0;
//            decimal dWithNbtAmount = 0, dNbtAmount = 0, dVatAmount = 0;

//            //if (oPOS.SubTotal < 0)
//            //    BulkDiscount *= -1;

//            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oPOS.GrandTotal, oPOS.VatPercentage, oPOS.NbtPercentage, ref dWithNbtAmount, ref dSubTotalWithDiscount, ref dNbtAmount, ref dVatAmount);

//            decimal TotalQty = 0, dTotalAmount = 0, dLineDiscount = 0;
//            foreach (tbl_posTransaction_Detail oDetail in tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oPOS.PosTransaction_Index))
//            {
//                TotalQty += oDetail.Qty;
//                //dTotalAmount += oDetail.UnitPrice * oDetail.Qty;
//                dLineDiscount += (oDetail.LineDiscountTotal * oDetail.Qty);

//                //dAmountBeforeLineDiscount = (dAmountBeforeBulkDiscount / (100 - oDetail.LineDiscountPresentage) * 100);
//                //dLineDiscount = dAmountBeforeLineDiscount - dAmountBeforeBulkDiscount;

//            }
//            BulkDiscount = (dSubTotalWithDiscount * oPOS.DiscountPercentage) / (100 - oPOS.DiscountPercentage);
//            dDiscountTotal = dLineDiscount + BulkDiscount;

//            dTotalAmount = dSubTotalWithDiscount + dDiscountTotal;

//            lstSales.Add(new cls_sasSalesReportDetail_InvoiceWise_DTO()
//            {
//                TxType = "3-POS Sales & Return",
//                Tx_ID = oPOS.PosTransaction_ID,
//                TxDate = oPOS.PosTransactiondate,
//                SalesRep = sSalesmanID == "default" ? "-" : clsGenaralName.getName_SalesRep(sSalesmanID),
//                Customer = clsGenaralName.getName_Customer(oPOS.Customer_ID),
//                CustomerType = clsGenaralName.getName_CustomerType(oCustomer.CustomerType_ID),
//                CustomerCategory = clsGenaralName.getName_CustomerCategory(oCustomer.CustomerCategory_ID),


//                TotalQty = TotalQty,
//                ItemAmount = dTotalAmount,
//                Discount = dDiscountTotal,
//                SubTotal = dSubTotalWithDiscount,

//                NBTAmount = dNbtAmount,
//                VATAmount = dVatAmount,
//                GrandTotal = oPOS.GrandTotal,
//                SVATAmount = oPOS.OtherTaxTotal
//            });
//            #endregion

//            clsHelpMethods_Local.startProgressBar(0, oPosList.Count, 1, ProgressBar);
//        }
//    }
//    ProgressBar.Value = 0;
//    #endregion
//    #endregion

//    if (lstSales.Count > 0)
//    {
//        cls_sasSalesReportDetail_InvoiceWise.SalesReportDetail_InvoiceWise(lstSales, dtFromDate, dtToDate, sReportTitle_Main);
//    }
//    else
//    {
//        MessageBox.Show("Data Not Found", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
//    }
//}
#endregion

#region Month Returns Against - Sales - Pure Excel
//DataTable dt = new DataTable();
//dt.Columns.Add("Route");
//                                        dt.Columns.Add("SalesRep");

//                                        dt.Columns.Add("GrossValue");
//                                        dt.Columns.Add("ReturnValue");
//                                        #endregion

//                                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
//ExcelApp.Application.Workbooks.Add(Type.Missing);
//var List = oMonthlyReturnsList
//        .GroupBy(u => new { u.Month, u.SalesRep, u.Route })
//        .Select(t => new 
//        {
//            Route = t.Key.Route,
//            SalesRep = t.Key.SalesRep,
//            Month = t.Key.Month,

//            GrossValueOne = t.Key.Month == 1 ? t.Sum(v => v.GrossValue) : 0,
//            ReturnValueOne = t.Key.Month == 1 ? t.Sum(v => v.ReturnValue) : 0,
//            GrossValueTwo = t.Key.Month == 2 ? t.Sum(v => v.GrossValue) : 0,
//            ReturnValueTwo = t.Key.Month == 2 ? t.Sum(v => v.ReturnValue) : 0,
//            GrossValueThree = t.Key.Month == 3 ? t.Sum(v => v.GrossValue) : 0,
//            ReturnValueThree = t.Key.Month == 3 ? t.Sum(v => v.ReturnValue) : 0,
//            GrossValueFour = t.Key.Month == 4 ? t.Sum(v => v.GrossValue) : 0,
//            ReturnValueFour = t.Key.Month == 4 ? t.Sum(v => v.ReturnValue) : 0,
//            GrossValueFive = t.Key.Month == 5 ? t.Sum(v => v.GrossValue) : 0,
//            ReturnValueFive = t.Key.Month == 5 ? t.Sum(v => v.ReturnValue) : 0
//        })
//        .ToList();

//DataTable tempDt = clsHelpMethods_Local.ToDataTable(List.ToList());

#region Set Header and Column Width
//ExcelApp.Cells[1, 1].Value = clsSecurity.CompanyName;
//ExcelApp.Cells[2, 1].Value = clsSecurity.CompanyAddress1;
//ExcelApp.Cells[3, 1].Value = clsSecurity.CompanyAddress2;
//ExcelApp.Cells[5, 1].Value = sReportTitle_Main;
//ExcelApp.Cells[6, 1].Value = "From : " + dtFromDate.Date.ToShortDateString() + " - To :" + dtToDate.Date.ToShortDateString();

//#region Merge Company Details
//ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 7]].Merge();
//ExcelApp.Range[ExcelApp.Cells[2, 1], ExcelApp.Cells[2, 7]].Merge();
//ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 7]].Merge();
//ExcelApp.Range[ExcelApp.Cells[5, 1], ExcelApp.Cells[5, 7]].Merge();
//ExcelApp.Range[ExcelApp.Cells[6, 1], ExcelApp.Cells[6, 7]].Merge();
//#endregion

////format orientation n alignments
////set column range as text format
////ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 20]].NumberFormat = "@";
////ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 20]].Orientation = "90";
////ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 20]].Style.VerticalAlignment = VerticalAlignment.Center;
////ExcelApp.Range[ExcelApp.Cells[3, 1], ExcelApp.Cells[3, 20]].Style.HorizontalAlignment = HorizontalAlignment.Center;
//ExcelApp.Range[ExcelApp.Cells[4, 1], ExcelApp.Cells[4, 20]].RowHeight = "20";

////format font style
//ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[6, 7]].Style.Font.Bold = true;
//ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[6, 7]].Style.Font.Name = "Calibri";
//ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[6, 7]].Style.Font.Size = 9F;

//#region Column Headers
////Header Top Line
////ExcelApp.Cells[8, 1] = "Route";
////ExcelApp.Cells[8, 2] = "Sales Rep";
//ExcelApp.Cells[8, 3] = "January";
//ExcelApp.Cells[8, 7] = "February";
//ExcelApp.Cells[8, 11] = "March";
//ExcelApp.Cells[8, 15] = "April";
//ExcelApp.Cells[8, 19] = "May";

////Header Bottom Line
//ExcelApp.Cells[9, 1] = "Route";
//ExcelApp.Cells[9, 2] = "Sales Rep";

//ExcelApp.Cells[9, 3] = "Gross Value";
//ExcelApp.Cells[9, 4] = "Return Value";
//ExcelApp.Cells[9, 5] = "Net Value";
//ExcelApp.Cells[9, 6] = "Rtn %";

//ExcelApp.Cells[9, 7] = "Gross Value";
//ExcelApp.Cells[9, 8] = "Return Value";
//ExcelApp.Cells[9, 9] = "Net Value";
//ExcelApp.Cells[9, 10] = "Rtn %";

//ExcelApp.Cells[9, 11] = "Gross Value";
//ExcelApp.Cells[9, 12] = "Return Value";
//ExcelApp.Cells[9, 13] = "Net Value";
//ExcelApp.Cells[9, 14] = "Rtn %";

//ExcelApp.Cells[9, 15] = "Gross Value";
//ExcelApp.Cells[9, 16] = "Return Value";
//ExcelApp.Cells[9, 17] = "Net Value";
//ExcelApp.Cells[9, 18] = "Rtn %";

//ExcelApp.Cells[9, 19] = "Gross Value";
//ExcelApp.Cells[9, 20] = "Return Value";
//ExcelApp.Cells[9, 21] = "Net Value";
//ExcelApp.Cells[9, 22] = "Rtn %";

//#region Merge Cells
//ExcelApp.Range[ExcelApp.Cells[8, 1], ExcelApp.Cells[9, 1]].Merge();
//ExcelApp.Range[ExcelApp.Cells[8, 2], ExcelApp.Cells[9, 2]].Merge();

//ExcelApp.Range[ExcelApp.Cells[8, 3], ExcelApp.Cells[8, 5]].Merge();
//ExcelApp.Range[ExcelApp.Cells[8, 7], ExcelApp.Cells[8, 9]].Merge();
//ExcelApp.Range[ExcelApp.Cells[8, 11], ExcelApp.Cells[8, 13]].Merge();
//ExcelApp.Range[ExcelApp.Cells[8, 15], ExcelApp.Cells[8, 17]].Merge();
//ExcelApp.Range[ExcelApp.Cells[8, 19], ExcelApp.Cells[8, 21]].Merge();
//#endregion

////format header borders
//ExcelApp.Range[ExcelApp.Cells[8, 1], ExcelApp.Cells[9, 22]].Borders.Color = System.Drawing.Color.Black;
//ExcelApp.Range[ExcelApp.Cells[8, 1], ExcelApp.Cells[9, 22]].Interior.Color = System.Drawing.Color.LightGray;

////ExcelApp.Range[ExcelApp.Cells[8, 1], ExcelApp.Cells[9, 22]].Style.VerticalAlignment = VerticalAlignment.Center;
////ExcelApp.Range[ExcelApp.Cells[8, 1], ExcelApp.Cells[9, 22]].Style.HorizontalAlignment = HorizontalAlignment.Center;
//#endregion
#endregion

#region Fill Cells
//int c = 10;
//foreach (var row in List)
//{
//    ExcelApp.Range[ExcelApp.Cells[c, 1], ExcelApp.Cells[c, 20]].Style.Font.Name = "Calibri";
//    ExcelApp.Range[ExcelApp.Cells[c, 1], ExcelApp.Cells[c, 20]].Style.Font.Size = 10F;
//    ExcelApp.Range[ExcelApp.Cells[c, 1], ExcelApp.Cells[c, 20]].Style.Font.Bold = false;

//    ExcelApp.Cells[c, 1] = row.Route;
//    ExcelApp.Cells[c, 2] = row.SalesRep;

//    ExcelApp.Cells[c, 3] = clsFormatter.RoundDecimalPlaces(row.GrossValueOne);
//    ExcelApp.Cells[c, 4] = clsFormatter.RoundDecimalPlaces(row.ReturnValueOne);
//    ExcelApp.Cells[c, 5] = clsFormatter.RoundDecimalPlaces(row.GrossValueOne - row.ReturnValueOne);
//    ExcelApp.Cells[c, 6] = row.GrossValueOne > 0 && row.ReturnValueOne > 0 ? clsFormatter.RoundDecimalPlaces(row.GrossValueOne / row.ReturnValueOne) + "%" : "0";

//    ExcelApp.Cells[c, 7] = clsFormatter.RoundDecimalPlaces(row.GrossValueTwo);
//    ExcelApp.Cells[c, 8] = clsFormatter.RoundDecimalPlaces(row.ReturnValueTwo);
//    ExcelApp.Cells[c, 9] = clsFormatter.RoundDecimalPlaces(row.GrossValueTwo - row.ReturnValueTwo);
//    ExcelApp.Cells[c, 10] = row.GrossValueTwo > 0 && row.ReturnValueTwo > 0 ? clsFormatter.RoundDecimalPlaces(row.GrossValueTwo / row.ReturnValueTwo) + "%" : "0";

//    ExcelApp.Cells[c, 11] = clsFormatter.RoundDecimalPlaces(row.GrossValueThree);
//    ExcelApp.Cells[c, 12] = clsFormatter.RoundDecimalPlaces(row.ReturnValueThree);
//    ExcelApp.Cells[c, 13] = clsFormatter.RoundDecimalPlaces(row.GrossValueThree - row.ReturnValueThree);
//    ExcelApp.Cells[c, 14] = row.GrossValueThree > 0 && row.ReturnValueThree > 0 ? clsFormatter.RoundDecimalPlaces(row.GrossValueThree / row.ReturnValueThree) + "%" : "0";

//    ExcelApp.Cells[c, 15] = clsFormatter.RoundDecimalPlaces(row.GrossValueFour);
//    ExcelApp.Cells[c, 16] = clsFormatter.RoundDecimalPlaces(row.ReturnValueFour);
//    ExcelApp.Cells[c, 17] = clsFormatter.RoundDecimalPlaces(row.GrossValueFour - row.ReturnValueFour);
//    ExcelApp.Cells[c, 18] = row.GrossValueFour > 0 && row.ReturnValueFour > 0 ? clsFormatter.RoundDecimalPlaces(row.GrossValueFour / row.ReturnValueFour) + "%" : "0";

//    ExcelApp.Cells[c, 19] = clsFormatter.RoundDecimalPlaces(row.GrossValueFive);
//    ExcelApp.Cells[c, 20] = clsFormatter.RoundDecimalPlaces(row.ReturnValueFive);
//    ExcelApp.Cells[c, 21] = clsFormatter.RoundDecimalPlaces(row.GrossValueFive - row.ReturnValueFive);
//    ExcelApp.Cells[c, 22] = row.GrossValueFive > 0 && row.ReturnValueFive > 0 ? clsFormatter.RoundDecimalPlaces(row.GrossValueFive / row.ReturnValueFive) + "%" : "0";

//    c++;
//}
#endregion

//ExcelApp.Columns.WrapText = true;
//ExcelApp.Columns.AutoFit();
//SaveFileDialog dlg = new SaveFileDialog();
//dlg.DefaultExt = ".xls";
//dlg.Filter = "Excel documents (.xls)|*.xlsx";
//if (dlg.ShowDialog() == DialogResult.OK)
//{
//    string filename = dlg.FileName;
//    ExcelApp.ActiveWorkbook.SaveAs(filename);

//    MessageBox.Show("Excel file is successfully created", "Successfully created", MessageBoxButtons.OK, MessageBoxIcon.Information);
//    ExcelApp.ActiveWorkbook.Saved = true;
//    ExcelApp.Visible = true;

//    //Marshal.FinalReleaseComObject(ExcelApp);
//} 
#endregion