using DataTire;
using Digiteq.DataSets;
using Digiteq_Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEACC_Functions;
using Digiteq;

namespace Digiteq.Reports.BSS
{
    public partial class frm_rpt_TaxReports : MettroForm
    {
        #region Class Variables
        public int iFormID;
        public bool bNoAccess;
        private int iReport;

        dts_Sales glb_dtsSales = new dts_Sales();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        private bool
            bComapanyBranchSelected = false,
            bRouteSelected = false,
            bSelesRepSelected = false,
            bCustomerSelected = false,
            bCustomerClassSelected = false,
            bCustomerTypeSelected = false,
            bCustomerCategorySelected = false,
            bSalesNoteTypeSelected = false,

            bSupplierSelected = false,
            bSupplierClassSelected = false,
            bSupplierTypeSelected = false,
            bSupplierCategorySelected = false,
            bStoskNoteTypeSelected = false;
        #endregion

        #region Form Load
        public frm_rpt_TaxReports()
        {
            iFormID = clsSecurity.getFormID(FormName.TaxReports);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }

        private void frm_rpt_TaxReports_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, clsHelpMethods.getFormName(iFormID), 2, iFormID);
            ClearField();
            DisplayReports();
        }
        #endregion

        #region Action Buttons

        #region Clear Button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearField();
        }
        #endregion

        #region Print Button
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvReports.Rows.Count > 0)
            {
                try
                {
                    int iRow = dgvReports.SelectedCells[0].RowIndex;
                    iReport = int.Parse(dgvReports.Rows[iRow].Cells[0].Value.ToString());
                    enum_ReportName Report = (enum_ReportName)iReport;

                    if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(Report)))
                    {
                        string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                        if (clsHelpMethods.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main,
                            ref sReportTitle_Sub, ref sReportPath))
                        {
                            Cursor = Cursors.WaitCursor;
                            ProgressBar.Value = 0;

                            #region Selected Search Fields

                            //Comapany Branch
                            bComapanyBranchSelected = false;

                            //Customer
                            bCustomerSelected = false;
                            bCustomerClassSelected = false;
                            bCustomerTypeSelected = false;
                            bCustomerCategorySelected = false;
                            bRouteSelected = false;
                            bSelesRepSelected = false;
                            bSalesNoteTypeSelected = false;

                            //Supplier
                            bSupplierClassSelected = false;
                            bSupplierTypeSelected = false;
                            bSupplierCategorySelected = false;
                            bSupplierSelected = false;
                            bStoskNoteTypeSelected = false;

                            string sFilter = "";
                            string sFormula = "";
                            string sDateRange = "From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "  To : " +
                                                dtpTo.Value.ToString("dd MMM yyyy");

                            if (txtBranch.Tag != null && txtBranch.Tag.ToString().Trim().Length > 0)
                                bComapanyBranchSelected = true;

                            //Customer
                            if (txtCusClass.Tag != null && txtCusClass.Tag.ToString().Trim().Length > 0)
                                bCustomerClassSelected = true;
                            if (txtCusType.Tag != null && txtCusType.Tag.ToString().Trim().Length > 0)
                                bCustomerTypeSelected = true;
                            if (txtCusCategory.Tag != null && txtCusCategory.Tag.ToString().Trim().Length > 0)
                                bCustomerCategorySelected = true;
                            if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Trim().Length > 0)
                                bCustomerSelected = true;
                            if (txtSalesRep.Tag != null && txtSalesRep.Tag.ToString().Trim().Length > 0)
                                bSelesRepSelected = true;
                            if (txtRoute.Tag != null && txtRoute.Tag.ToString().Trim().Length > 0)
                                bRouteSelected = true;
                            if (txtSalesNoteType.Tag != null && txtSalesNoteType.Tag.ToString().Trim().Length > 0)
                                bSalesNoteTypeSelected = true;

                            //Supplier
                            if (txtSupplier.Tag != null && txtSupplier.Tag.ToString().Trim().Length > 0)
                                bSupplierSelected = true;
                            if (txtSupClass.Tag != null && txtSupClass.Tag.ToString().Trim().Length > 0)
                                bSupplierClassSelected = true;
                            if (txtSupType.Tag != null && txtSupType.Tag.ToString().Trim().Length > 0)
                                bSupplierTypeSelected = true;
                            if (txtSupCategory.Tag != null && txtSupCategory.Tag.ToString().Trim().Length > 0)
                                bSupplierCategorySelected = true;
                            if (txtNoteType.Tag != null && txtNoteType.Tag.ToString().Trim().Length > 0)
                                bStoskNoteTypeSelected = true;

                            #endregion

                            #region Selected Filters

                            //Customer
                            if (bComapanyBranchSelected)
                                sFilter += (sFilter.Length != 0 ? " | " : "") + "Company Branch : " + txtBranch.Text.Trim();
                            if (bRouteSelected)
                                sFilter += (sFilter.Length != 0 ? " | " : "") + "Route : " + txtRoute.Text.Trim();
                            if (bSelesRepSelected)
                                sFilter += (sFilter.Length != 0 ? " | " : "") + "SalesMen : " + txtSalesRep.Text.Trim();
                            if (bCustomerSelected)
                                sFilter += (sFilter.Length != 0 ? " | " : "") + "Customer : " + txtCustomer.Text.Trim();
                            if (bCustomerTypeSelected)
                                sFilter += (sFilter.Length != 0 ? " | " : "") + "Customer Type : " +
                                           txtCusType.Text.Trim();
                            if (bSalesNoteTypeSelected)
                                sFilter += (sFilter.Length != 0 ? " | " : "") + "Sales note type : " +
                                           txtSalesNoteType.Text.Trim();
                            if (cmbTaxType.Tag != null && cmbTaxType.Tag.ToString().Length > 0)
                                sFilter += (sFilter.Length != 0 ? " | " : "") + "Tax Type : " + cmbTaxType.Text.Trim();

                            //Supplier
                            if (bSupplierSelected)
                                sFilter += (sFilter.Length != 0 ? " | " : "") + "Supplier : " + txtSupplier.Text.Trim();
                            if (bSupplierClassSelected)
                                sFilter += (sFilter.Length != 0 ? " | " : "") + "Supplier Class : " +
                                           txtSupClass.Text.Trim();
                            if (bSupplierTypeSelected)
                                sFilter += (sFilter.Length != 0 ? " | " : "") + "Supplier Type : " +
                                           txtSupType.Text.Trim();
                            if (bSupplierCategorySelected)
                                sFilter += (sFilter.Length != 0 ? " | " : "") + "Supplier Category : " +
                                           txtSupCategory.Text.Trim();
                            if (bStoskNoteTypeSelected)
                                sFilter += (sFilter.Length != 0 ? " | " : "") + "Note Type : " +
                                           txtNoteType.Text.Trim();

                            #endregion

                            #region Reports

                            #region Tax Reports Summary

                            if (Report == enum_ReportName.ST_Tax_Report_Invoice_ExportSVAT)
                            {
                                glb_dtsSales.Clear();
                                string sRouteID = "", sSalesmanID = "";

                                if (cmbTaxType.Text.Trim() == "Local NBT/VAT")
                                {
                                    Report = enum_ReportName.ST_Tax_Report_Invoice_LocalNBTVAT;

                                    #region Local NBT/VAT

                                    List<tbl_sasInvoice> Query = tbl_sasInvoice
                                        .SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p =>
                                            !p.IsDeleted && p.Invoice_ID != "default" &&
                                            p.InvoiceDate.Date >= dtpFrom.Value.Date &&
                                            p.InvoiceDate.Date <= dtpTo.Value.Date
                                            && !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque &&
                                            !p.IsSVatInvoice && p.Currency_ID == clsConfig.sLocalCurrencyCode).ToList();

                                    foreach (tbl_sasInvoice oInvoice in Query)
                                    {
                                        if (bCustomerSelected)
                                        {
                                            if (oInvoice.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                continue;
                                        }

                                        tbl_genCustomerMaster CusDetail =
                                            tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
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
                                                    foreach (tbl_genCustomerMaster_Branches oRoute in
                                                        tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(
                                                            oInvoice.Customer_ID))
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
                                                if (CusDetail.CustomerCategory_ID !=
                                                    txtCusCategory.Tag.ToString().Trim())
                                                    continue;
                                            }
                                        }

                                        decimal dWithNBTAmount = 0, dSubTotal = 0, dNBTAmount = 0, dVatAmount = 0;
                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvoice.GrandTotal,
                                            oInvoice.VatPercentage, oInvoice.NbtPercentage, ref dWithNBTAmount,
                                            ref dSubTotal, ref dNBTAmount, ref dVatAmount);

                                        glb_dtsSales.dtTaxSummary.AdddtTaxSummaryRow(oInvoice.InvoiceDate, dSubTotal,
                                            dNBTAmount, dWithNBTAmount, dVatAmount, "INV", oInvoice.GrandTotal,
                                            clsGenaralName.getName_CurrencyCode(oInvoice.Currency_ID),
                                            oInvoice.CurrencyRate,
                                            clsHelpMethods.getDisplayPrice(dWithNBTAmount, oInvoice.CurrencyRate),
                                            clsHelpMethods.getDisplayPrice(dVatAmount, oInvoice.CurrencyRate));
                                        clsHelpMethods.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
                                    }

                                    sReportTitle_Main = "Tax Reports Summary [Local NBT/VAT]";
                                    sReportPath = "\\reports\\SAS\\Standard\\rpt_sas_TaxReportSummary.rpt";

                                    #endregion
                                }
                                else if (cmbTaxType.Text.Trim() == "Export VAT") //"Local SVAT"
                                {
                                    Report = enum_ReportName.ST_Tax_Report_Invoice_LocalSVAT;

                                    #region Local SVAT

                                    foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice
                                        .SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p =>
                                            !p.IsDeleted && p.Invoice_ID != "default" &&
                                            p.InvoiceDate.Date >= dtpFrom.Value.Date &&
                                            p.InvoiceDate.Date <= dtpTo.Value.Date
                                            && !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque &&
                                            p.IsSVatInvoice && p.Currency_ID == clsConfig.sLocalCurrencyCode))
                                    {
                                        decimal dWithNBTAmount = 0, dSubTotal = 0, dNBTAmount = 0, dVatAmount = 0;
                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvoice.GrandTotal,
                                            oInvoice.VatPercentage, oInvoice.NbtPercentage, ref dWithNBTAmount,
                                            ref dSubTotal, ref dNBTAmount, ref dVatAmount);

                                        glb_dtsSales.dtTaxSummary.AdddtTaxSummaryRow(oInvoice.InvoiceDate, dSubTotal,
                                            dNBTAmount, dWithNBTAmount, dVatAmount, "INV",
                                            oInvoice.GrandTotal,
                                            clsGenaralName.getName_CurrencyCode(oInvoice.Currency_ID),
                                            oInvoice.CurrencyRate,
                                            clsHelpMethods.getDisplayPrice(dWithNBTAmount, oInvoice.CurrencyRate),
                                            clsHelpMethods.getDisplayPrice(dVatAmount, oInvoice.CurrencyRate));
                                    }

                                    sReportTitle_Main = "Tax Reports Summary [Local SVAT]";
                                    sReportPath =
                                        "\\reports\\SAS\\Standard\\rpt_sas_TaxReportSummary_InvoiceLocal_SVAT.rpt";

                                    #endregion
                                }
                                else if (cmbTaxType.Text.Trim() == "Export SVAT")
                                {
                                    Report = enum_ReportName.ST_Tax_Report_Invoice_ExportSVAT;

                                    #region Export SVAT

                                    foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice
                                        .SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p =>
                                            !p.IsDeleted && p.Invoice_ID != "default" &&
                                            p.InvoiceDate.Date >= dtpFrom.Value.Date &&
                                            p.InvoiceDate.Date <= dtpTo.Value.Date
                                            && !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque &&
                                            p.IsSVatInvoice && p.Currency_ID != clsConfig.sLocalCurrencyCode))
                                    {
                                        decimal dWithNBTAmount = 0, dSubTotal = 0, dNBTAmount = 0, dVatAmount = 0;
                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvoice.GrandTotal,
                                            oInvoice.VatPercentage, oInvoice.NbtPercentage, ref dWithNBTAmount,
                                            ref dSubTotal, ref dNBTAmount, ref dVatAmount);

                                        glb_dtsSales.dtTaxSummary.AdddtTaxSummaryRow(oInvoice.InvoiceDate, dSubTotal,
                                            dNBTAmount, dWithNBTAmount, dVatAmount, "INV", oInvoice.GrandTotal,
                                            clsGenaralName.getName_CurrencyCode(oInvoice.Currency_ID),
                                            oInvoice.CurrencyRate,
                                            clsHelpMethods.getDisplayPrice(dWithNBTAmount, oInvoice.CurrencyRate),
                                            clsHelpMethods.getDisplayPrice(dVatAmount, oInvoice.CurrencyRate));
                                    }

                                    sReportTitle_Main = "Tax Reports Summary [Export SVAT]";
                                    sReportPath =
                                        "\\reports\\SAS\\Standard\\rpt_sas_TaxReportSummary_InvoiceExport_SVAT.rpt";

                                    #endregion
                                }

                                #region tbl_bpsCreditNote

                                foreach (tbl_bpsCreditNote oCRN in tbl_bpsCreditNote.SelectAll().Where(p =>
                                    p.CompanyBranch_ID == txtBranch.Tag.ToString() && p.CreditNoteType_ID !=
                                    clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit))) //
                                {
                                    if (oCRN.IsDeleted == false && oCRN.CreditNoteDate >= dtpFrom.Value &&
                                        oCRN.CreditNoteDate <= dtpTo.Value &&
                                        oCRN.Currency_ID == clsConfig.sLocalCurrencyCode)
                                    {
                                        decimal dWithNBTAmount = 0, dSubTotal = 0, dNBTAmount = 0, dVatAmount = 0;
                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oCRN.TotalAmount,
                                            oCRN.VatPercentage, oCRN.NbtPercentage, ref dWithNBTAmount, ref dSubTotal,
                                            ref dNBTAmount, ref dVatAmount);

                                        glb_dtsSales.dtTaxSummary.AdddtTaxSummaryRow(oCRN.CreditNoteDate, dSubTotal,
                                            dNBTAmount, dWithNBTAmount, dVatAmount, "CRN", oCRN.TotalAmount,
                                            clsGenaralName.getName_CurrencyCode(oCRN.Currency_ID), oCRN.CurrencyRate,
                                            clsHelpMethods.getDisplayPrice(dWithNBTAmount, oCRN.CurrencyRate),
                                            clsHelpMethods.getDisplayPrice(dVatAmount, oCRN.CurrencyRate));

                                        sReportTitle_Main = "Tax Reports Summary [Export SVAT]";
                                        sReportPath =
                                            "\\reports\\SAS\\Standard\\rpt_sas_TaxReportSummary_InvoiceExport_SVAT.rpt";
                                    }
                                }

                                #endregion

                                glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName,
                                    clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1,
                                    clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "",
                                    sDateRange, clsSecurity.UserNameLoged, sFilter);

                                frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                rpt.print(sReportPath, glb_dtsSales, glb_dtsReportExport.dt_rptParameter,
                                    clsAutocode.getReportID(Report));
                            }

                            #endregion

                            #region Tax  Reports Details (Invoice)

                            else if (Report == enum_ReportName.ST_Tax_Report_Invoice_DetailLocalNBTVAT)
                            {
                                //glb_dtsSales.dt_sasTaxDetails_Invoice.Rows.Clear();
                                glb_dtsSales.Clear();
                                string sRouteID = "";
                                string sInvoiceType = "";

                                #region Local NBT/VAT

                                if (cmbTaxType.Text.Trim() == "Local NBT/VAT" ||
                                    cmbTaxType.Text.Trim() == "Local VAT (Excluding: NBT)")
                                {
                                    Report = enum_ReportName.ST_Tax_Report_Invoice_DetailLocalNBTVAT;
                                    List<tbl_sasInvoice> lstInvoice = tbl_sasInvoice
                                        .SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p =>
                                            !p.IsDeleted && p.Invoice_ID != "default" &&
                                            p.InvoiceDate.Date >= dtpFrom.Value.Date &&
                                            p.InvoiceDate.Date <= dtpTo.Value.Date
                                            && !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque &&
                                            p.OtherTaxTotal == 0 && !(!p.IsVatInvoice && !p.IsSVatInvoice)).ToList();

                                    foreach (tbl_sasInvoice oInvoice in lstInvoice)
                                    {
                                        #region Sales Note Type Filter
                                        if (bSalesNoteTypeSelected)
                                            if (txtSalesNoteType.Tag.ToString() != oInvoice.SalesNoteType_ID)
                                                continue;

                                        if (bCustomerSelected)
                                        {
                                            if (oInvoice.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                continue;
                                        }
                                        #endregion

                                        tbl_genCustomerMaster oCustomerMaster = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                        if (oCustomerMaster != null)
                                        {
                                            #region Route Filter

                                            if (bRouteSelected)
                                            {
                                                if (!chkUseCustomerMasterRoute.Checked)
                                                {
                                                    sRouteID = oInvoice.Route_ID.ToString();
                                                }
                                                else
                                                {
                                                    foreach (tbl_genCustomerMaster_Branches oRoute in
                                                        tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(
                                                            oInvoice.Customer_ID))
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
                                                if (oCustomerMaster.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            if (bCustomerTypeSelected)
                                            {
                                                if (oCustomerMaster.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            if (bCustomerCategorySelected)
                                            {
                                                if (oCustomerMaster.CustomerCategory_ID !=
                                                    txtCusCategory.Tag.ToString().Trim())
                                                    continue;
                                            }
                                            #endregion
                                        }

                                        if (clsConfig.bSalesNoteType_SerialNoActiveFor_Invoice)
                                            sInvoiceType = clsGenaralName.getName_SalesNoteType(oInvoice.SalesNoteType_ID);
                                        else
                                            sInvoiceType = (oInvoice.IsVatInvoice) ? "Vat Invoice" : (oInvoice.IsSVatInvoice) ? "SVat Invoice" : "Non Tax Invoice";

                                        if (oCustomerMaster != null)
                                        {
                                            string sPONo = "";
                                            if (oInvoice.Job_ID == "default" && oInvoice.DeliveryOrder_ID != "default") //Direct Sales
                                                sPONo = clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID);
                                            else if (oInvoice.Quotation_ID != "default" && oInvoice.DeliveryOrder_ID == "default") //Block Invoice
                                                sPONo = clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID);
                                            else if (oInvoice.Job_ID != "default" && oInvoice.DeliveryOrder_ID != "default") //Normal Invoice
                                                sPONo = clsHelpMethods.GetPONoByProductionJobID(oInvoice.Job_ID);

                                            decimal dWithNBTAmount = 0,
                                                dSubTotal = 0,
                                                dNBTAmount = 0,
                                                dVatAmount = 0,
                                                dCurrencyTotal = 0,
                                                dCurrencyVat = 0;

                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvoice.GrandTotal,
                                                oInvoice.VatPercentage, oInvoice.NbtPercentage, ref dWithNBTAmount,
                                                ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                            dCurrencyTotal = oInvoice.GrandTotal;
                                            dCurrencyVat = dVatAmount / oInvoice.CurrencyRate;

                                            if (cmbTaxType.Text.Trim() == "Local VAT (Excluding: NBT)")
                                            {
                                                dSubTotal = dWithNBTAmount;
                                                dNBTAmount = 0;
                                                if (oInvoice.SalesNoteType_ID == clsConfig.sHC_NonVatSalesNoteTypeID)
                                                {
                                                    dSubTotal += dVatAmount;
                                                    dWithNBTAmount = dSubTotal;
                                                    dVatAmount = 0;
                                                }
                                            }

                                            glb_dtsSales.dt_sasTaxDetails_Invoice.Adddt_sasTaxDetails_InvoiceRow(
                                                oInvoice.Invoice_ID, oInvoice.InvoiceDate,
                                                oCustomerMaster.VatRegistrationNo != ""
                                                    ? clsGenaralName.getName_Customer(oInvoice.Customer_ID) +
                                                      "\nVAT Reg : " + oCustomerMaster.VatRegistrationNo
                                                    : clsGenaralName.getName_Customer(oInvoice.Customer_ID),
                                                clsGenaralName.getName_BranchCustomer(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID)),
                                                oInvoice.GrandTotal, dSubTotal, dNBTAmount, dVatAmount, dWithNBTAmount,
                                                sPONo, oInvoice.DeliveryOrder_ID, oInvoice.Job_ID,
                                                oInvoice.CurrencyRate,
                                                clsGenaralName.getName_CurrencyCode(oInvoice.Currency_ID),
                                                "",
                                                oInvoice.DateCreate, dCurrencyTotal, dCurrencyVat, sInvoiceType);
                                        }

                                        clsHelpMethods.startProgressBar(0, lstInvoice.Count + 2, 1, ProgressBar);
                                    }

                                    if (cmbTaxType.Text.Trim() == "Local VAT (Excluding: NBT)")
                                        sReportTitle_Main = "Tax Report Detail - Invoice [Local VAT]";
                                    else
                                        sReportTitle_Main = "Tax Report Detail - Invoice [Local NBT/VAT]";

                                    sReportPath = clsHelpMethods.GetReportPath(clsAutocode.getReportID(Report));
                                    if (sReportPath == null || sReportPath.Length == 0)
                                    {
                                        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                            sReportPath =
                                                "\\reports\\SAS\\Standard\\rpt_sas_TaxReportDetail_InvoiceLocal_NBT_VAT.rpt";
                                        else
                                            sReportPath =
                                                "\\reports\\SAS\\Standard\\rpt_sas_TaxReportDetail_InvoiceLocal_NBT_VAT_AKI.rpt";
                                    }
                                }

                                #endregion

                                #region Export VAT

                                else if (cmbTaxType.Text.Trim() == "Export VAT" ||
                                         cmbTaxType.Text.Trim() == "DSE Zero Rated")
                                {
                                    List<tbl_sasInvoice> lstInvoice = tbl_sasInvoice
                                        .SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p =>
                                            !p.IsDeleted && p.Invoice_ID != "default" &&
                                            p.InvoiceDate.Date >= dtpFrom.Value.Date &&
                                            p.InvoiceDate.Date <= dtpTo.Value.Date
                                            && !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque &&
                                            p.VatTotal >= 0 && p.OtherTaxTotal == 0 &&
                                            !(!p.IsVatInvoice && !p.IsSVatInvoice)).ToList();

                                    foreach (tbl_sasInvoice oInvoice in lstInvoice)
                                    {
                                        if (bSalesNoteTypeSelected)
                                            if (txtSalesNoteType.Tag.ToString() != oInvoice.SalesNoteType_ID)
                                                continue;

                                        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                        {
                                            if (oInvoice.Quotation_ID != "default")
                                                sInvoiceType = "Block Invoice";
                                        }

                                        tbl_genCustomerMaster oCustomer =
                                            tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                        tbl_pmsProductionJobRegister oProductionRegister =
                                            tbl_pmsProductionJobRegister.Select(oInvoice.Job_ID);

                                        #region filter - DO type

                                        string sDoType = "";
                                        if (oProductionRegister != null)
                                        {
                                            if (oProductionRegister.ProductionJobType_ID == "PJT/001" ||
                                                oProductionRegister.ProductionJobType_ID == "PJT/002")
                                                sDoType = "Kandana";
                                            else if (oProductionRegister.ProductionJobType_ID == "PJT/003" ||
                                                     oProductionRegister.ProductionJobType_ID == "PJT/004")
                                                sDoType = "Pettah";
                                            else if (oProductionRegister.ProductionJobType_ID == "PJT/009" ||
                                                     oProductionRegister.ProductionJobType_ID == "PJT/010")
                                                sDoType = "Direct";
                                            else if (oProductionRegister.ProductionJobType_ID == "PJT/013" ||
                                                     oProductionRegister.ProductionJobType_ID == "PJT/014")
                                                sDoType = "Block";
                                            else if (oProductionRegister.ProductionJobType_ID == "PJT/011" ||
                                                     oProductionRegister.ProductionJobType_ID == "PJT/012")
                                                sDoType = "Chemical";
                                            else
                                                sDoType = "-";
                                        }

                                        #endregion

                                        string sPONo = "";
                                        if (oInvoice.Job_ID == "default" &&
                                            oInvoice.DeliveryOrder_ID != "default") //Direct Sales
                                            sPONo = clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID);
                                        else if (oInvoice.Quotation_ID != "default" &&
                                                 oInvoice.DeliveryOrder_ID == "default") //Block Invoice
                                            sPONo = clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID);
                                        else if (oInvoice.Job_ID != "default" &&
                                                 oInvoice.DeliveryOrder_ID != "default") //Normal Invoice
                                            sPONo = clsHelpMethods.GetPONoByProductionJobID(oInvoice.Job_ID);

                                        decimal dWithNBTAmount = 0,
                                            dSubTotal = 0,
                                            dNBTAmount = 0,
                                            dVatAmount = 0,
                                            dCurrencyTotal = 0,
                                            dCurrencyVat = 0;
                                        if (oProductionRegister != null & oCustomer != null)
                                        {
                                            if (oCustomer.CustomerType_ID == "2") //Export Customers Only
                                            {
                                                #region If Export VAT Selected

                                                if (cmbTaxType.Text.Trim() == "Export VAT")
                                                {
                                                    if (oCustomer.IsVATenable && !oCustomer.IsSVATenable &&
                                                        !oCustomer.IsNBTenable)
                                                    {
                                                        dSubTotal = oInvoice.GrandTotal;
                                                        dNBTAmount = 0;
                                                        dVatAmount = 0;
                                                        dWithNBTAmount = oInvoice.GrandTotal;
                                                        dCurrencyVat = 0;
                                                        dCurrencyTotal = oInvoice.GrandTotal;
                                                    }
                                                    else
                                                        continue;
                                                }

                                                #endregion

                                                clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvoice.GrandTotal,
                                                    oInvoice.VatPercentage, oInvoice.NbtPercentage, ref dWithNBTAmount,
                                                    ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                                dCurrencyTotal = dSubTotal / oInvoice.CurrencyRate;
                                                dCurrencyVat = dVatAmount / oInvoice.CurrencyRate;

                                                #region Only For AKT

                                                if (clsConfig.sSoftwareModel.Trim() ==
                                                    SoftwareModel_Sales.akt.ToString())
                                                {
                                                    if (oInvoice.Quotation_ID != "default") //for block invoice
                                                    {
                                                        dSubTotal = dWithNBTAmount;
                                                        dNBTAmount = 0;
                                                    }
                                                }

                                                #endregion

                                                #region If Zero Rated Selected

                                                if (cmbTaxType.Text.Trim() == "DSE Zero Rated")
                                                {
                                                    if (!oCustomer.IsVATenable && !oCustomer.IsSVATenable &&
                                                        !oCustomer.IsNBTenable)
                                                    {
                                                        dSubTotal = oInvoice.GrandTotal;
                                                        dNBTAmount = 0;
                                                        dVatAmount = 0;
                                                        dWithNBTAmount = oInvoice.GrandTotal;
                                                        dCurrencyVat = 0;
                                                        dCurrencyTotal = oInvoice.GrandTotal;
                                                    }
                                                    else
                                                        continue;
                                                }

                                                #endregion

                                                glb_dtsSales.dt_sasTaxDetails_Invoice.Adddt_sasTaxDetails_InvoiceRow(
                                                    oInvoice.Invoice_ID, oInvoice.InvoiceDate,
                                                    oCustomer.VatRegistrationNo != ""
                                                        ? clsGenaralName.getName_Customer(oInvoice.Customer_ID) +
                                                          "\nVAT Reg : " + oCustomer.VatRegistrationNo
                                                        : clsGenaralName.getName_Customer(oInvoice.Customer_ID),
                                                    clsGenaralName.getName_BranchCustomer(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID)),
                                                    oInvoice.GrandTotal, dSubTotal,
                                                    dNBTAmount, dVatAmount, dWithNBTAmount, sPONo,
                                                    oInvoice.DeliveryOrder_ID, oInvoice.Job_ID, oInvoice.CurrencyRate,
                                                    clsGenaralName.getName_CurrencyCode(oInvoice.Currency_ID),
                                                    clsGenaralName.getName_ProductionJobType(oProductionRegister
                                                        .ProductionJobType_ID), oInvoice.DateCreate, dCurrencyTotal,
                                                    dCurrencyVat, sInvoiceType);
                                            }
                                        }

                                        clsHelpMethods.startProgressBar(0, lstInvoice.Count + 2, 1, ProgressBar);
                                    }

                                    if (cmbTaxType.Text.Trim() == "DSE Zero Rated")
                                        sReportTitle_Main = "Tax Report Detail - Invoice [Zero Rated]";
                                    else
                                        sReportTitle_Main = "Tax Report Detail - Invoice [Export VAT]";

                                    sReportPath = "\\reports\\SAS\\Standard\\rpt_sas_TaxReportDetail_InvoiceExport_VAT.rpt";
                                }

                                #endregion

                                #region Export SVAT

                                else if (cmbTaxType.Text.Trim() == "Export SVAT")
                                {
                                    int iInvoicecount = 0;
                                    decimal dTotalAmount = 0;
                                    Invoice_ExportSvat(ref sReportPath, ref sReportTitle_Main, ref sInvoiceType,
                                        ref iInvoicecount, ref dTotalAmount);
                                }

                                #endregion

                                //if (bPermissionValid)
                                glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName,
                                    clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1,
                                    clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "",
                                    sDateRange, clsSecurity.UserNameLoged, sFilter);

                                frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                rpt.print(sReportPath, glb_dtsSales, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                            }

                            #endregion

                            #region Tax  Reports Details (Invoice) - New (TW)

                            else if (Report == enum_ReportName.ST_Tax_Report_Invoice_Detail)
                            {
                                glb_dtsSales.Clear();
                                string sInvoiceType = "";

                                List<tbl_sasInvoice> lstInvoice = tbl_sasInvoice
                                    .SelectAllByCompanyBranch_ID(txtBranch.Tag.ToString()).Where(p => !p.IsDeleted && p.Invoice_ID != "default" && p.InvoiceDate.Date >= dtpFrom.Value.Date && p.InvoiceDate.Date <= dtpTo.Value.Date
                                        && !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque && p.OtherTaxTotal == 0 && !p.IsSVatInvoice).ToList();

                                foreach (tbl_sasInvoice oInvoice in lstInvoice)
                                {
                                    #region Filters
                                    if (bSalesNoteTypeSelected)
                                        if (txtSalesNoteType.Tag.ToString() != oInvoice.SalesNoteType_ID)
                                            continue;

                                    if (bCustomerSelected)
                                    {
                                        if (oInvoice.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                            continue;
                                    }
                                    #endregion

                                    tbl_genCustomerMaster oCustomerMaster = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                    if (oCustomerMaster != null)
                                    {
                                        #region Customer Filters
                                        if (bCustomerClassSelected)
                                        {
                                            if (oCustomerMaster.CustomerClass_ID != txtCusClass.Tag.ToString().Trim())
                                                continue;
                                        }

                                        if (bCustomerTypeSelected)
                                        {
                                            if (oCustomerMaster.CustomerType_ID != txtCusType.Tag.ToString().Trim())
                                                continue;
                                        }

                                        if (bCustomerCategorySelected)
                                        {
                                            if (oCustomerMaster.CustomerCategory_ID !=
                                                txtCusCategory.Tag.ToString().Trim())
                                                continue;
                                        }
                                        #endregion
                                    }

                                    sInvoiceType = (oInvoice.SalesNoteType_ID == "NT031") ? "VAT Exemption Invoices" : (oInvoice.IsVatInvoice) ? "TAX Invoices" : "Non Tax Invoices";

                                    #region Po No.
                                    string sPONo = "-";
                                    if (oInvoice.CustomerOrder_ID != "default")
                                        sPONo = oInvoice.CustomerOrder_ID;
                                    else if (oInvoice.DeliveryOrder_ID != "default")
                                    {
                                        tbl_sasDeliveryOrder oDO = tbl_sasDeliveryOrder.Select(oInvoice.DeliveryOrder_ID);
                                        if (oDO != null)
                                        {
                                            sPONo = oDO.CustomerOrder_ID;
                                        }
                                    }
                                    #endregion

                                    decimal dWithNBTAmount = 0, dSubTotal = 0, dNBTAmount = 0, dVatAmount = 0, dCurrencyTotal = 0, dCurrencyVat = 0;

                                    if (oInvoice.SalesNoteType_ID == "NT031")
                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvoice.GrandTotal, 0, oInvoice.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);

                                    else
                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvoice.GrandTotal, oInvoice.VatPercentage, oInvoice.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);

                                    dCurrencyTotal = oInvoice.GrandTotal;
                                    dCurrencyVat = dVatAmount / oInvoice.CurrencyRate;

                                    #region MyRegion
                                    //if (cmbTaxType.Text.Trim() == "Local VAT (Excluding: NBT)")
                                    //{
                                    //    dSubTotal = dWithNBTAmount;
                                    //    dNBTAmount = 0;
                                    //    if (oInvoice.SalesNoteType_ID == clsConfig.sHC_NonVatSalesNoteTypeID)
                                    //    {
                                    //        dSubTotal += dVatAmount;
                                    //        dWithNBTAmount = dSubTotal;
                                    //        dVatAmount = 0;
                                    //    }
                                    //} 
                                    #endregion

                                    glb_dtsSales.dt_sasTaxDetails_Invoice.Adddt_sasTaxDetails_InvoiceRow(oInvoice.Invoice_ID, oInvoice.InvoiceDate,
                                                oCustomerMaster.VatRegistrationNo != "" ? clsGenaralName.getName_Customer(oInvoice.Customer_ID) + "\nVAT Reg : " + oCustomerMaster.VatRegistrationNo : clsGenaralName.getName_Customer(oInvoice.Customer_ID),
                                                clsGenaralName.getName_BranchCustomer(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID)),
                                                oInvoice.GrandTotal, dSubTotal, dNBTAmount, dVatAmount, dWithNBTAmount,
                                                sPONo, oInvoice.DeliveryOrder_ID, oInvoice.Job_ID, oInvoice.CurrencyRate, clsGenaralName.getName_CurrencyCode(oInvoice.Currency_ID), "",
                                                oInvoice.DateCreate, dCurrencyTotal, dCurrencyVat, sInvoiceType);

                                    clsHelpMethods.startProgressBar(0, lstInvoice.Count + 2, 1, ProgressBar);
                                }

                                glb_dtsSales.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), sReportTitle_Main, "", sDateRange, clsSecurity.UserNameLoged, sFilter);

                                frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                rpt.print(sReportPath, glb_dtsSales, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(Report));
                            }

                            #endregion

                            #region Tax  Reports (Credit Note-Local)

                            else if (Report == enum_ReportName.ST_Tax_Report_CreditNote)
                            {
                                glb_dtsSales.dt_sasTaxDetails_CreditNote.Rows.Clear();
                                glb_dtsSales.dt_sasCreditNote_InvoiceAllocation.Rows.Clear();

                                bool bSVAT = false;
                                string sSalesmanID = "";

                                if (cmbTaxType.Text.Trim() == "Local NBT/VAT")
                                {
                                    #region Local NBT/VAT

                                    List<tbl_bpsCreditNote> Query = tbl_bpsCreditNote.SelectAll().Where(p =>
                                        !p.IsDeleted && p.CreditNote_ID != "default" &&
                                        p.Currency_ID == clsConfig.sLocalCurrencyCode
                                        && p.CreditNoteDate.Date >= dtpFrom.Value.Date &&
                                        p.CreditNoteDate.Date <= dtpTo.Value.Date
                                        && p.CreditNoteType_ID !=
                                        clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit) &&
                                        p.CreditNoteType_ID != clsAutocode.getCreditNoteTypeID(CreditNoteType.BadDebts)
                                        && p.CompanyBranch_ID == txtBranch.Tag.ToString()).ToList();

                                    foreach (tbl_bpsCreditNote oCreditNote in Query)
                                    {
                                        if (bCustomerSelected)
                                        {
                                            if (oCreditNote.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                continue;
                                        }

                                        tbl_genCustomerMaster oCustomer =
                                            tbl_genCustomerMaster.Select(oCreditNote.Customer_ID);
                                        if (oCustomer != null)
                                        {
                                            #region Sales Rep

                                            if (chkUseCustomerMastorSaleRep.Checked)
                                                sSalesmanID = oCustomer.SalesRep_ID;
                                            else
                                            {
                                                tbl_zOrderRefNo oRef =
                                                    tbl_zOrderRefNo.Select(oCreditNote.OrderRefNo_ID);
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
                                                if (oCustomer.CustomerCategory_ID !=
                                                    txtCusCategory.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            #endregion

                                            if (oCustomer.CustomerType_ID != "2")
                                            {
                                                decimal dWithNBTAmount = 0,
                                                    dSubTotal = 0,
                                                    dNBTAmount = 0,
                                                    dVatAmount = 0;
                                                int iRecordCount = 0;

                                                foreach (tbl_bpsCreditNote_Invoice oCRNInvoice in
                                                    tbl_bpsCreditNote_Invoice.SelectAllByCreditNote_ID(oCreditNote
                                                        .CreditNote_ID))
                                                {
                                                    tbl_sasInvoice_Sattled oInvStl =
                                                        tbl_sasInvoice_Sattled.Select(oCRNInvoice.Invoice_ID, "default",
                                                            "default", oCreditNote.CreditNote_ID, "default", "default",
                                                            "default");
                                                    if (oInvStl != null)
                                                    {
                                                        tbl_sasInvoice oInvoice =
                                                            tbl_sasInvoice.Select(oCRNInvoice.Invoice_ID);
                                                        if (oInvoice != null)
                                                        {
                                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(
                                                                oInvStl.SattledAmount, oInvoice.VatPercentage,
                                                                oInvoice.NbtPercentage, ref dWithNBTAmount,
                                                                ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                                            glb_dtsSales.dt_sasTaxDetails_CreditNote
                                                                .Adddt_sasTaxDetails_CreditNoteRow(
                                                                    oCreditNote.CreditNote_ID,
                                                                    oCreditNote.CreditNoteDate,
                                                                    oCustomer.VatRegistrationNo != ""
                                                                        ? clsGenaralName.getName_Customer(oCreditNote
                                                                              .Customer_ID) + "\nVAT Reg : " +
                                                                          oCustomer.VatRegistrationNo
                                                                        : clsGenaralName.getName_Customer(oCreditNote
                                                                            .Customer_ID), oInvStl.SattledAmount,
                                                                    dSubTotal,
                                                                    clsGenaralName.getName_CreditNoteType(oCreditNote
                                                                        .CreditNoteType_ID), oCreditNote.Invoice_ID,
                                                                    oInvoice.InvoiceDate, dVatAmount, dNBTAmount,
                                                                    dWithNBTAmount,
                                                                    clsGenaralName.getName_CurrencyCode(oCreditNote
                                                                        .Currency_ID),
                                                                    oCreditNote.CurrencyRate,
                                                                    clsHelpMethods.getDisplayPrice(dSubTotal,
                                                                        oCreditNote.CurrencyRate),
                                                                    clsHelpMethods.getDisplayPrice(dVatAmount,
                                                                        oCreditNote.CurrencyRate),
                                                                    dSubTotal, "", oCreditNote.IsDeleted,
                                                                    oCreditNote.PrintCount, oCRNInvoice.Invoice_ID,
                                                                    oInvStl.SattledAmount, oCreditNote.Remark, "",
                                                                    clsSecurity.getServerDateTime().Date,
                                                                    oCreditNote.TotalAmount, oCreditNote.VatTotal,
                                                                    oCreditNote.NbtTotal, oCreditNote.SubTotal,
                                                                    iRecordCount, "", "", 0, 0, "");
                                                            iRecordCount++;
                                                        }
                                                    }
                                                }

                                                if (iRecordCount == 0) // If No Invoice record available
                                                {
                                                    string sInvoiceID = "-";
                                                    DateTime dtmInvoiceDate = new DateTime();

                                                    tbl_sasInvoice oInvoice =
                                                        tbl_sasInvoice.Select(oCreditNote.Invoice_ID);
                                                    if (oInvoice != null || oInvoice.Invoice_ID == "default")
                                                    {
                                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(
                                                            oCreditNote.TotalAmount, oInvoice.VatPercentage,
                                                            oInvoice.NbtPercentage, ref dWithNBTAmount, ref dSubTotal,
                                                            ref dNBTAmount, ref dVatAmount);
                                                    }
                                                    else
                                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(
                                                            oCreditNote.TotalAmount, oCreditNote.VatPercentage,
                                                            oCreditNote.NbtPercentage, ref dWithNBTAmount,
                                                            ref dSubTotal, ref dNBTAmount, ref dVatAmount);

                                                    glb_dtsSales.dt_sasTaxDetails_CreditNote
                                                        .Adddt_sasTaxDetails_CreditNoteRow(oCreditNote.CreditNote_ID,
                                                            oCreditNote.CreditNoteDate,
                                                            oCustomer.VatRegistrationNo != ""
                                                                ? clsGenaralName.getName_Customer(oCreditNote
                                                                      .Customer_ID) + "\nVAT Reg : " +
                                                                  oCustomer.VatRegistrationNo
                                                                : clsGenaralName.getName_Customer(oCreditNote
                                                                    .Customer_ID), oCreditNote.TotalAmount,
                                                            dSubTotal,
                                                            clsGenaralName.getName_CreditNoteType(oCreditNote
                                                                .CreditNoteType_ID), sInvoiceID, dtmInvoiceDate,
                                                            dVatAmount, dNBTAmount, dWithNBTAmount,
                                                            clsGenaralName.getName_CurrencyCode(oCreditNote
                                                                .Currency_ID),
                                                            oCreditNote.CurrencyRate,
                                                            clsHelpMethods.getDisplayPrice(dSubTotal,
                                                                oCreditNote.CurrencyRate),
                                                            clsHelpMethods.getDisplayPrice(dVatAmount,
                                                                oCreditNote.CurrencyRate), dSubTotal, "",
                                                            oCreditNote.IsDeleted, oCreditNote.PrintCount,
                                                            oCreditNote.Invoice_ID, 0, oCreditNote.Remark, "",
                                                            clsSecurity.getServerDateTime().Date,
                                                            oCreditNote.TotalAmount, oCreditNote.VatTotal,
                                                            oCreditNote.NbtTotal, oCreditNote.SubTotal, iRecordCount,
                                                            "", "", 0, 0, "");
                                                }
                                            }
                                        }

                                        clsHelpMethods.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
                                    }

                                    sReportTitle_Main = "Tax Report Detail - Credit Note [Local NBT/VAT]";
                                    sReportPath =
                                        "\\reports\\SAS\\Standard\\rpt_sas_TaxReportDetail_CreditNoteLocal_NBT_VAT.rpt";

                                    #endregion
                                }
                                else if (cmbTaxType.Text.Trim() == "Export VAT")
                                {
                                    #region Local SVAT

                                    List<tbl_bpsCreditNote> Query = tbl_bpsCreditNote.SelectAll().Where(p =>
                                        !p.IsDeleted && p.CreditNote_ID != "default" && p.OtherTaxTotal == 0
                                        && p.CreditNoteDate.Date >= dtpFrom.Value.Date &&
                                        p.CreditNoteDate.Date <= dtpTo.Value.Date &&
                                        p.CreditNoteType_ID !=
                                        clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit) &&
                                        p.CreditNoteType_ID !=
                                        clsAutocode.getCreditNoteTypeID(CreditNoteType.BadDebts) &&
                                        p.CompanyBranch_ID == txtBranch.Tag.ToString()).ToList();

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
                                                if (oCustomer.CustomerCategory_ID !=
                                                    txtCusCategory.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            #endregion

                                            if (oCustomer.CustomerType_ID == "2")
                                            {
                                                foreach (tbl_bpsCreditNote_Invoice oCRNInvoice in
                                                    tbl_bpsCreditNote_Invoice.SelectAllByCreditNote_ID(oCreditNote
                                                        .CreditNote_ID))
                                                {
                                                    tbl_sasInvoice_Sattled oInvStl =
                                                        tbl_sasInvoice_Sattled.Select(oCRNInvoice.Invoice_ID, "default",
                                                            "default", oCreditNote.CreditNote_ID, "default", "default",
                                                            "default");
                                                    if (oInvStl != null)
                                                    {
                                                        tbl_sasInvoice oInvoice =
                                                            tbl_sasInvoice.Select(oCRNInvoice.Invoice_ID);
                                                        if (oInvoice != null)
                                                        {
                                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(
                                                                oInvStl.SattledAmount, oCreditNote.VatPercentage,
                                                                oCreditNote.NbtPercentage, ref dWithNBTAmount,
                                                                ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                                            glb_dtsSales.dt_sasTaxDetails_CreditNote
                                                                .Adddt_sasTaxDetails_CreditNoteRow(
                                                                    oCreditNote.CreditNote_ID,
                                                                    oCreditNote.CreditNoteDate,
                                                                    oCustomer.VatRegistrationNo != ""
                                                                        ? clsGenaralName.getName_Customer(oCreditNote
                                                                              .Customer_ID) + "\nVAT Reg : " +
                                                                          oCustomer.VatRegistrationNo
                                                                        : clsGenaralName.getName_Customer(oCreditNote
                                                                            .Customer_ID), oInvStl.SattledAmount,
                                                                    dSubTotal, oCreditNote.CreditNoteType_ID,
                                                                    oCreditNote.Invoice_ID, oInvoice.InvoiceDate,
                                                                    dVatAmount, dNBTAmount, dWithNBTAmount,
                                                                    clsGenaralName.getName_CurrencyCode(oCreditNote
                                                                        .Currency_ID),
                                                                    oCreditNote.CurrencyRate,
                                                                    clsHelpMethods.getDisplayPrice(dSubTotal,
                                                                        oCreditNote.CurrencyRate),
                                                                    clsHelpMethods.getDisplayPrice(dVatAmount,
                                                                        oCreditNote.CurrencyRate),
                                                                    dSubTotal, "", oCreditNote.IsDeleted,
                                                                    oCreditNote.PrintCount, oCRNInvoice.Invoice_ID,
                                                                    oInvStl.SattledAmount, oCreditNote.Remark, "",
                                                                    clsSecurity.getServerDateTime().Date,
                                                                    oCreditNote.TotalAmount, oCreditNote.VatTotal,
                                                                    oCreditNote.NbtTotal, oCreditNote.SubTotal,
                                                                    iRecordCount, "", "", 0, 0, "");
                                                            iRecordCount++;
                                                        }
                                                    }
                                                }

                                                if (iRecordCount == 0 && oCreditNote.Invoice_ID != "default"
                                                ) // If No record available
                                                {
                                                    tbl_sasInvoice oInvoice =
                                                        tbl_sasInvoice.Select(oCreditNote.Invoice_ID);
                                                    if (oInvoice != null)
                                                    {
                                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(
                                                            oCreditNote.TotalAmount, oCreditNote.VatPercentage,
                                                            oCreditNote.NbtPercentage, ref dWithNBTAmount,
                                                            ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                                        glb_dtsSales.dt_sasTaxDetails_CreditNote
                                                            .Adddt_sasTaxDetails_CreditNoteRow(
                                                                oCreditNote.CreditNote_ID, oCreditNote.CreditNoteDate,
                                                                oCustomer.VatRegistrationNo != ""
                                                                    ? clsGenaralName.getName_Customer(oCreditNote
                                                                          .Customer_ID) + "\nVAT Reg : " +
                                                                      oCustomer.VatRegistrationNo
                                                                    : clsGenaralName.getName_Customer(oCreditNote
                                                                        .Customer_ID), oCreditNote.TotalAmount,
                                                                dSubTotal, oCreditNote.CreditNoteType_ID,
                                                                oCreditNote.Invoice_ID, oInvoice.InvoiceDate,
                                                                dVatAmount, dNBTAmount, dWithNBTAmount,
                                                                clsGenaralName.getName_CurrencyCode(oCreditNote
                                                                    .Currency_ID),
                                                                oCreditNote.CurrencyRate,
                                                                clsHelpMethods.getDisplayPrice(dSubTotal,
                                                                    oCreditNote.CurrencyRate),
                                                                clsHelpMethods.getDisplayPrice(dVatAmount,
                                                                    oCreditNote.CurrencyRate),
                                                                dSubTotal, "", oCreditNote.IsDeleted,
                                                                oCreditNote.PrintCount, oCreditNote.Invoice_ID,
                                                                oCreditNote.TotalAmount, oCreditNote.Remark, "",
                                                                clsSecurity.getServerDateTime().Date,
                                                                oCreditNote.TotalAmount, oCreditNote.VatTotal,
                                                                oCreditNote.NbtTotal, oCreditNote.SubTotal,
                                                                iRecordCount, "", "", 0, 0, "");
                                                    }
                                                }
                                            }
                                        }

                                        clsHelpMethods.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
                                    }

                                    sReportTitle_Main = "Tax Report Detail - Credit Note [Export VAT]";
                                    sReportPath =
                                        "\\reports\\SAS\\Standard\\rpt_sas_TaxReportDetail_CreditNoteLocal_SVAT.rpt";

                                    #endregion
                                }
                                else if (cmbTaxType.Text.Trim() == "Export SVAT")
                                {
                                    #region Export SVAT

                                    int iCreditnotecount = 0;
                                    decimal dTotalAmount = 0;
                                    Creditnote_ExportSvat(ref sReportPath, ref sReportTitle_Main, ref bSVAT,
                                        ref iCreditnotecount, ref dTotalAmount);

                                    #endregion
                                }
                                else if (cmbTaxType.Text.Trim() == "Local VAT (Excluding: NBT)")
                                {
                                    #region Local VAT (Excluding: NBT)

                                    List<tbl_bpsCreditNote> Query = tbl_bpsCreditNote.SelectAll().Where(p =>
                                        !p.IsDeleted && p.CreditNote_ID != "default" &&
                                        p.Currency_ID == clsConfig.sLocalCurrencyCode
                                        && p.CreditNoteDate.Date >= dtpFrom.Value.Date &&
                                        p.CreditNoteDate.Date <= dtpTo.Value.Date &&
                                        p.CreditNoteType_ID !=
                                        "'" + clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit) +
                                        "'" && p.CreditNoteType_ID !=
                                        clsAutocode.getCreditNoteTypeID(CreditNoteType.BadDebts) &&
                                        p.CompanyBranch_ID == txtBranch.Tag.ToString()).ToList();

                                    foreach (tbl_bpsCreditNote oCreditNote in Query)
                                    {
                                        if (bCustomerSelected)
                                        {
                                            if (oCreditNote.Customer_ID != txtCustomer.Tag.ToString().Trim())
                                                continue;
                                        }

                                        tbl_genCustomerMaster oCustomer =
                                            tbl_genCustomerMaster.Select(oCreditNote.Customer_ID);
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
                                                if (oCustomer.CustomerCategory_ID !=
                                                    txtCusCategory.Tag.ToString().Trim())
                                                    continue;
                                            }

                                            #endregion

                                            if (oCustomer.CustomerType_ID != "2")
                                            {
                                                decimal dWithNBTAmount = 0,
                                                    dSubTotal = 0,
                                                    dNBTAmount = 0,
                                                    dVatAmount = 0;
                                                int iRecordCount = 0;
                                                string sCreditNoteType = "";

                                                foreach (tbl_bpsCreditNote_Invoice oCRNInvoice in
                                                    tbl_bpsCreditNote_Invoice.SelectAllByCreditNote_ID(oCreditNote
                                                        .CreditNote_ID))
                                                {
                                                    tbl_sasInvoice_Sattled oInvStl =
                                                        tbl_sasInvoice_Sattled.Select(oCRNInvoice.Invoice_ID, "default",
                                                            "default", oCreditNote.CreditNote_ID, "default", "default",
                                                            "default");
                                                    if (oInvStl != null)
                                                    {
                                                        tbl_sasInvoice oInvoice =
                                                            tbl_sasInvoice.Select(oCRNInvoice.Invoice_ID);
                                                        if (oInvoice != null && oInvoice.Invoice_ID != "default")
                                                        {
                                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(
                                                                oInvStl.SattledAmount, oInvoice.VatPercentage,
                                                                oInvoice.NbtPercentage, ref dWithNBTAmount,
                                                                ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                                            if (oInvoice.SalesNoteType_ID ==
                                                                clsConfig.sHC_NonVatSalesNoteTypeID
                                                            ) //"SN001") //SN001 = VAT Sales                                                            
                                                            {
                                                                dVatAmount = 0;
                                                                dWithNBTAmount = oInvStl.SattledAmount;
                                                            }

                                                            sCreditNoteType =
                                                                clsGenaralName.getName_SalesNoteType(
                                                                    oInvoice.SalesNoteType_ID);
                                                            dSubTotal = dWithNBTAmount;
                                                            dNBTAmount = 0;

                                                            glb_dtsSales.dt_sasTaxDetails_CreditNote
                                                                .Adddt_sasTaxDetails_CreditNoteRow(
                                                                    oCreditNote.CreditNote_ID,
                                                                    oCreditNote.CreditNoteDate,
                                                                    oCustomer.VatRegistrationNo != ""
                                                                        ? clsGenaralName.getName_Customer(oCreditNote
                                                                              .Customer_ID) + "\nVAT Reg : " +
                                                                          oCustomer.VatRegistrationNo
                                                                        : clsGenaralName.getName_Customer(oCreditNote
                                                                            .Customer_ID), oInvStl.SattledAmount,
                                                                    dSubTotal, sCreditNoteType, oCreditNote.Invoice_ID,
                                                                    oInvoice.InvoiceDate, dVatAmount, dNBTAmount,
                                                                    dWithNBTAmount,
                                                                    clsGenaralName.getName_CurrencyCode(oCreditNote
                                                                        .Currency_ID),
                                                                    oCreditNote.CurrencyRate,
                                                                    clsHelpMethods.getDisplayPrice(dSubTotal,
                                                                        oCreditNote.CurrencyRate),
                                                                    clsHelpMethods.getDisplayPrice(dVatAmount,
                                                                        oCreditNote.CurrencyRate),
                                                                    dSubTotal, "", oCreditNote.IsDeleted,
                                                                    oCreditNote.PrintCount, oCRNInvoice.Invoice_ID,
                                                                    oInvStl.SattledAmount, oCreditNote.Remark, "",
                                                                    clsSecurity.getServerDateTime().Date,
                                                                    oCreditNote.TotalAmount, oCreditNote.VatTotal,
                                                                    oCreditNote.NbtTotal, oCreditNote.SubTotal,
                                                                    iRecordCount, "", "", 0, 0, "");
                                                            iRecordCount++;
                                                        }
                                                    }
                                                }

                                                if (iRecordCount == 0 && oCreditNote.Invoice_ID != "default"
                                                ) // If No Invoice record available
                                                {
                                                    string sInvoiceID = "";
                                                    DateTime dtmInvoiceDate = new DateTime();
                                                    tbl_sasInvoice oInvoice1 =
                                                        tbl_sasInvoice.Select(oCreditNote.Invoice_ID);
                                                    if (oInvoice1 != null && oInvoice1.Invoice_ID != "default")
                                                    {
                                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(
                                                            oCreditNote.TotalAmount, oInvoice1.VatPercentage,
                                                            oInvoice1.NbtPercentage, ref dWithNBTAmount, ref dSubTotal,
                                                            ref dNBTAmount, ref dVatAmount);
                                                        sInvoiceID = oInvoice1.Invoice_ID;
                                                        dtmInvoiceDate = oInvoice1.InvoiceDate;
                                                        sCreditNoteType =
                                                            clsGenaralName.getName_SalesNoteType(oInvoice1
                                                                .SalesNoteType_ID);

                                                        if (oCreditNote.SalesNoteType_ID != "SN001"
                                                        ) //SN001 = VAT Sales                                                            
                                                        {
                                                            dVatAmount = 0;
                                                            dWithNBTAmount =
                                                                oCreditNote.TotalAmount * 100 /
                                                                (100 + oInvoice1.VatPercentage);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(
                                                            oCreditNote.TotalAmount, oCreditNote.VatPercentage,
                                                            oCreditNote.NbtPercentage, ref dWithNBTAmount,
                                                            ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                                        sCreditNoteType =
                                                            clsGenaralName.getName_SalesNoteType(oCreditNote
                                                                .SalesNoteType_ID);
                                                        if (oCreditNote.SalesNoteType_ID != "SN001"
                                                        ) //SN001 = VAT Sales                                                            
                                                        {
                                                            dVatAmount = 0;
                                                            dWithNBTAmount =
                                                                oCreditNote.TotalAmount * 100 /
                                                                (100 + oCreditNote.VatPercentage);
                                                        }
                                                    }

                                                    dSubTotal = dWithNBTAmount;
                                                    dNBTAmount = 0;
                                                    if (oCreditNote.SalesNoteType_ID ==
                                                        clsConfig.sHC_NonVatSalesNoteTypeID)
                                                    {
                                                        dSubTotal += dVatAmount;
                                                        dVatAmount = 0;
                                                    }

                                                    glb_dtsSales.dt_sasTaxDetails_CreditNote
                                                        .Adddt_sasTaxDetails_CreditNoteRow(oCreditNote.CreditNote_ID,
                                                            oCreditNote.CreditNoteDate,
                                                            oCustomer.VatRegistrationNo != ""
                                                                ? clsGenaralName.getName_Customer(oCreditNote
                                                                      .Customer_ID) + "\nVAT Reg : " +
                                                                  oCustomer.VatRegistrationNo
                                                                : clsGenaralName.getName_Customer(oCreditNote
                                                                    .Customer_ID), oCreditNote.TotalAmount,
                                                            dSubTotal, sCreditNoteType, sInvoiceID, dtmInvoiceDate,
                                                            dVatAmount, dNBTAmount, dWithNBTAmount,
                                                            clsGenaralName.getName_CurrencyCode(oCreditNote
                                                                .Currency_ID),
                                                            oCreditNote.CurrencyRate,
                                                            clsHelpMethods.getDisplayPrice(dSubTotal,
                                                                oCreditNote.CurrencyRate),
                                                            clsHelpMethods.getDisplayPrice(dVatAmount,
                                                                oCreditNote.CurrencyRate), dSubTotal, "",
                                                            oCreditNote.IsDeleted, oCreditNote.PrintCount,
                                                            oCreditNote.Invoice_ID, oCreditNote.TotalAmount,
                                                            oCreditNote.Remark, "",
                                                            clsSecurity.getServerDateTime().Date,
                                                            oCreditNote.TotalAmount, oCreditNote.VatTotal,
                                                            oCreditNote.NbtTotal, oCreditNote.SubTotal, iRecordCount,
                                                            "", "", 0, 0, "");
                                                }
                                            }
                                        }

                                        clsHelpMethods.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
                                    }

                                    sReportTitle_Main = "Tax Report Detail - Credit Note - Local VAT (Excluding: NBT)";
                                    sReportPath =
                                        "\\reports\\SAS\\Standard\\rpt_sas_TaxReportDetail_CreditNoteLocal_NBT_VAT.rpt";

                                    #endregion
                                }

                                if (cmbTaxType.Text.Trim() == "Export SVAT" && txtCustomer.Tag != null)

                                    print(sReportPath, sReportTitle_Main, glb_dtsSales.dt_sasTaxDetails_CreditNote,
                                        sFilter);
                                else
                                    print(sReportPath, sReportTitle_Main, glb_dtsSales, sFilter,
                                        clsAutocode.getReportID(Report));

                            }

                            #endregion

                            #region Tax  Reports (Credit Note) - New (TW)

                            else if (Report == enum_ReportName.ST_Tax_Report_Detail_CreditNote)
                            {
                                glb_dtsSales.Clear();

                                bool bSVAT = false;
                                string sCreditNoteType = "";

                                List<tbl_bpsCreditNote> Query = tbl_bpsCreditNote.SelectAll().Where(p => !p.IsDeleted && p.CreditNote_ID != "default" && p.Currency_ID == clsConfig.sLocalCurrencyCode && p.CreditNoteDate.Date >= dtpFrom.Value.Date && p.CreditNoteDate.Date <= dtpTo.Value.Date
                                    && p.CreditNoteType_ID != clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit) && p.CreditNoteType_ID != clsAutocode.getCreditNoteTypeID(CreditNoteType.BadDebts) && p.CompanyBranch_ID == txtBranch.Tag.ToString()).ToList();

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
                                            if (oCustomer.CustomerCategory_ID !=
                                                txtCusCategory.Tag.ToString().Trim())
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
                                                        if (bSalesNoteTypeSelected)
                                                            if (txtSalesNoteType.Tag.ToString() != oInvoice.SalesNoteType_ID)
                                                                continue;

                                                        sCreditNoteType = oInvoice.SalesNoteType_ID == "NT031" ? "VAT Exemption Credit Note" : clsGenaralName.getName_CreditNoteType(oCreditNote.CreditNoteType_ID);

                                                        if (oInvoice.SalesNoteType_ID == "NT031")
                                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvStl.SattledAmount, 0, oInvoice.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                                        else
                                                            clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvStl.SattledAmount, oInvoice.VatPercentage, oInvoice.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);

                                                        glb_dtsSales.dt_sasTaxDetails_CreditNote.Adddt_sasTaxDetails_CreditNoteRow(oCreditNote.CreditNote_ID, oCreditNote.CreditNoteDate,
                                                            oCustomer.VatRegistrationNo != "" ? clsGenaralName.getName_Customer(oCreditNote.Customer_ID) + "\nVAT Reg : " + oCustomer.VatRegistrationNo : clsGenaralName.getName_Customer(oCreditNote.Customer_ID),
                                                            oInvStl.SattledAmount, dSubTotal,
                                                            sCreditNoteType,
                                                            oCreditNote.Invoice_ID, oInvoice.InvoiceDate, dVatAmount, dNBTAmount, dWithNBTAmount, clsGenaralName.getName_CurrencyCode(oCreditNote.Currency_ID), oCreditNote.CurrencyRate,
                                                                    clsHelpMethods.getDisplayPrice(dSubTotal, oCreditNote.CurrencyRate), clsHelpMethods.getDisplayPrice(dVatAmount, oCreditNote.CurrencyRate),
                                                                    dSubTotal, "", oCreditNote.IsDeleted, oCreditNote.PrintCount, oCRNInvoice.Invoice_ID, oInvStl.SattledAmount, oCreditNote.Remark, "",
                                                                    clsSecurity.getServerDateTime().Date, oCreditNote.TotalAmount, oCreditNote.VatTotal, oCreditNote.NbtTotal, oCreditNote.SubTotal, iRecordCount, "", "", 0, 0, "");
                                                        iRecordCount++;
                                                    }
                                                }
                                            }

                                            #region No Invoice record available in tbl_sasInvoice_Sattled
                                            if (iRecordCount == 0)
                                            {
                                                string sInvoiceID = "-";
                                                DateTime dtmInvoiceDate = new DateTime();

                                                tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oCreditNote.Invoice_ID);
                                                if (oInvoice != null || oInvoice.Invoice_ID == "default")
                                                {
                                                    if (bSalesNoteTypeSelected)
                                                        if (txtSalesNoteType.Tag.ToString() != oInvoice.SalesNoteType_ID)
                                                            continue;

                                                    sCreditNoteType = oInvoice.SalesNoteType_ID == "NT031" ? "VAT Exemption Credit Note" : clsGenaralName.getName_CreditNoteType(oCreditNote.CreditNoteType_ID);

                                                    if (oInvoice.SalesNoteType_ID == "NT031")
                                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oCreditNote.TotalAmount, 0, oInvoice.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                                    else
                                                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oCreditNote.TotalAmount, oInvoice.VatPercentage, oInvoice.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                                }
                                                else
                                                {
                                                    sCreditNoteType = clsGenaralName.getName_CreditNoteType(oCreditNote.CreditNoteType_ID);
                                                    clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oCreditNote.TotalAmount, oCreditNote.VatPercentage, oCreditNote.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                                }

                                                glb_dtsSales.dt_sasTaxDetails_CreditNote.Adddt_sasTaxDetails_CreditNoteRow(oCreditNote.CreditNote_ID, oCreditNote.CreditNoteDate,
                                                        oCustomer.VatRegistrationNo != "" ? clsGenaralName.getName_Customer(oCreditNote.Customer_ID) + "\nVAT Reg : " + oCustomer.VatRegistrationNo : clsGenaralName.getName_Customer(oCreditNote.Customer_ID), oCreditNote.TotalAmount,
                                                        dSubTotal, sCreditNoteType, sInvoiceID, dtmInvoiceDate,
                                                        dVatAmount, dNBTAmount, dWithNBTAmount, clsGenaralName.getName_CurrencyCode(oCreditNote.Currency_ID), oCreditNote.CurrencyRate,
                                                        clsHelpMethods.getDisplayPrice(dSubTotal, oCreditNote.CurrencyRate), clsHelpMethods.getDisplayPrice(dVatAmount, oCreditNote.CurrencyRate), dSubTotal, "",
                                                        oCreditNote.IsDeleted, oCreditNote.PrintCount, oCreditNote.Invoice_ID, 0, oCreditNote.Remark, "", clsSecurity.getServerDateTime().Date,
                                                        oCreditNote.TotalAmount, oCreditNote.VatTotal, oCreditNote.NbtTotal, oCreditNote.SubTotal, iRecordCount, "", "", 0, 0, "");
                                            }
                                            #endregion
                                        }
                                    }

                                    clsHelpMethods.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
                                }

                                print(sReportPath, sReportTitle_Main, glb_dtsSales, sFilter, clsAutocode.getReportID(Report));
                            }

                            #endregion

                            #region VAT Schedule 01 Excel Report

                            else if (Report == enum_ReportName.ST_Tax_Reports_VAT_Schedule01)
                            {
                                DataTable dtVAT_Schedule01 = new DataTable();
                                dtVAT_Schedule01.Columns.Add("Invoice_Date");
                                dtVAT_Schedule01.Columns.Add("Tax_Invoice_No");
                                dtVAT_Schedule01.Columns.Add("Customer_TIN");
                                dtVAT_Schedule01.Columns.Add("Name_of_the_Customer");
                                dtVAT_Schedule01.Columns.Add("Description");
                                dtVAT_Schedule01.Columns.Add("Value_of_Supply");
                                dtVAT_Schedule01.Columns.Add("VAT_Amount");

                                var oCustomers = tbl_genCustomerMaster.SelectAll().ToList();

                                if (bCustomerClassSelected)
                                    oCustomers = oCustomers.Where(r => r.CustomerClass_ID == txtCusClass.Tag.ToString()).ToList();
                                if (bCustomerTypeSelected)
                                    oCustomers = oCustomers.Where(r => r.CustomerType_ID == txtCusType.Tag.ToString()).ToList();
                                if (bCustomerCategorySelected)
                                    oCustomers = oCustomers.Where(r => r.CustomerCategory_ID == txtCusCategory.Tag.ToString()).ToList();
                                if (bCustomerSelected)
                                    oCustomers = oCustomers.Where(r => r.Customer_ID == txtCustomer.Tag.ToString()).ToList();
                                if (bSelesRepSelected && chkUseCustomerMastorSaleRep.Checked)
                                    oCustomers = oCustomers.Where(r => r.SalesRep_ID == txtSalesRep.Tag.ToString()).ToList();
                                if (bRouteSelected && chkUseCustomerMasterRoute.Checked)
                                    oCustomers = oCustomers.Where(r => r.Route_ID == txtRoute.Tag.ToString()).ToList();

                                foreach (var oCustomer in oCustomers)
                                {
                                    clsHelpMethods.startProgressBar(0, oCustomers.Count() + 2, 1, ProgressBar);

                                    #region Invoices
                                    foreach (var oInvoice in tbl_sasInvoice.SelectAllByCustomer_ID(oCustomer.Customer_ID)
                                        .Where(r => !r.IsDeleted && !r.IsDebitNote && r.IsVatInvoice && r.InvoiceDate.Date >= dtpFrom.Value.Date
                                            && r.InvoiceDate.Date <= dtpTo.Value.Date))
                                    {
                                        if (bComapanyBranchSelected)
                                            if (oInvoice.CompanyBranch_ID != txtBranch.Tag.ToString())
                                                continue;

                                        if (bSelesRepSelected && !chkUseCustomerMastorSaleRep.Checked)
                                            if (oInvoice.Employee_ID.ToString() != txtSalesRep.Tag.ToString())
                                                continue;
                                        if (bRouteSelected && !chkUseCustomerMasterRoute.Checked)
                                            if (oInvoice.Route_ID.ToString() != txtRoute.Tag.ToString())
                                                continue;
                                        if (bSalesNoteTypeSelected)
                                            if (oInvoice.SalesNoteType_ID != txtSalesNoteType.Tag.ToString())
                                                continue;

                                        dtVAT_Schedule01.Rows.Add(
                                            string.Format("'{0}", oInvoice.InvoiceDate.ToString("MM/dd/yyyy")),
                                            oInvoice.Invoice_ID,
                                            oCustomer.VatRegistrationNo,
                                            oCustomer.CustomerName, "",
                                            cls_Formater.FormatDecimal(oInvoice.GrandTotal - oInvoice.VatTotal, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                                            cls_Formater.FormatDecimal(oInvoice.VatTotal, clsConfig.sCurrencyDecimalPlaces_UnitPrice));
                                    }
                                    #endregion

                                    #region POS Invoices
                                    foreach (var vPOSTransactions in tbl_posTransaction.SelectAllByCustomer_ID(oCustomer.Customer_ID).Where(r =>
                                                                       !r.IsReturnedPOS_Invoice && !r.IsDeleted && !r.IsHold &&
                                                                       r.PosTransactiondate.Date >= dtpFrom.Value.Date && r.PosTransactiondate.Date <= dtpTo.Value.Date))
                                    {
                                        if (bComapanyBranchSelected)
                                            if (vPOSTransactions.CompanyBranch_ID != txtBranch.Tag.ToString())
                                                continue;

                                        if (bSelesRepSelected && !chkUseCustomerMastorSaleRep.Checked)
                                            if (vPOSTransactions.SalesRep_ID.ToString() != txtSalesRep.Tag.ToString())
                                                continue;
                                        //if (bRouteSelected && !chkUseCustomerMasterRoute.Checked)
                                        //    if (vPOSTransactions.Route_ID.ToString() != txtRoute.Tag.ToString())
                                        //        continue;
                                        if (bSalesNoteTypeSelected)
                                            if (vPOSTransactions.SalesNoteType_ID != txtSalesNoteType.Tag.ToString())
                                                continue;

                                        decimal dNbtAmout = 0, dvatAmount = 0, dSvatAmount = 0, dSubTotal = vPOSTransactions.SubTotal;
                                        decimal dDiscountTotal = vPOSTransactions.DiscountTotal;
                                        decimal dDiscountPresentage = (vPOSTransactions.SubTotal == 0) ? 0 : (dDiscountTotal * 100 / vPOSTransactions.SubTotal);

                                        clsHelpMethods.CalculateGrandTotalReverce(vPOSTransactions.GrandTotal, ref dvatAmount, vPOSTransactions.VatPercentage, true,
                                            ref dSvatAmount, vPOSTransactions.OtherTaxPercentage, false,
                                            ref dNbtAmout, vPOSTransactions.NbtPercentage, false,
                                            ref dDiscountTotal, dDiscountPresentage, ref dSubTotal);

                                        dtVAT_Schedule01.Rows.Add(
                                            string.Format("'{0}", vPOSTransactions.PosTransactiondate.ToString("MM/dd/yyyy")),
                                            vPOSTransactions.PosTransaction_ID,
                                            oCustomer.VatRegistrationNo,
                                            oCustomer.CustomerName, "",
                                            cls_Formater.FormatDecimal(vPOSTransactions.GrandTotal - dvatAmount, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                                            cls_Formater.FormatDecimal(dvatAmount, clsConfig.sCurrencyDecimalPlaces_UnitPrice));
                                    }
                                    #endregion
                                }

                                if (dtVAT_Schedule01.Rows.Count > 0)
                                    ExportToExcel(dtVAT_Schedule01);
                                else
                                    MessageBox.Show("No Data Found...", clsFormatter.GetMessageCaption(),
                                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }

                            #endregion

                            #region VAT Schedule 02 Excel Report
                            else if (Report == enum_ReportName.ST_Tax_Reports_VAT_Schedule02)
                            {
                                DataTable dtVAT_Schedule02 = new DataTable();
                                dtVAT_Schedule02.Columns.Add("Bill_Date");
                                dtVAT_Schedule02.Columns.Add("Tax_Bill_No");
                                dtVAT_Schedule02.Columns.Add("Supplier_TIN");
                                dtVAT_Schedule02.Columns.Add("Name_of_the_Supplier");
                                dtVAT_Schedule02.Columns.Add("Description");
                                dtVAT_Schedule02.Columns.Add("Value_of_Purchase");
                                dtVAT_Schedule02.Columns.Add("VAT_Amount");

                                var vSuppliers = tbl_genSupplierMaster.SelectAll().Where(r => !r.IsDeleted);

                                if (bSupplierClassSelected)
                                    vSuppliers = vSuppliers.Where(r => r.SupplierClass_ID == txtSupClass.Tag.ToString());
                                if (bSupplierTypeSelected)
                                    vSuppliers = vSuppliers.Where(r => r.SupplierType_ID == txtSupType.Tag.ToString());
                                if (bSupplierCategorySelected)
                                    vSuppliers = vSuppliers.Where(r => r.SupplierCategory_ID == txtSupCategory.Tag.ToString());
                                if (bSupplierSelected)
                                    vSuppliers = vSuppliers.Where(r => r.Supplier_ID == txtSupplier.Tag.ToString());

                                foreach (var vSupplier in vSuppliers)
                                {
                                    clsHelpMethods.startProgressBar(0, vSuppliers.Count() + 2, 1, ProgressBar);

                                    foreach (var oAPN in tbl_accAccountPayableNote
                                        .SelectAllBySupplier_ID(vSupplier.Supplier_ID).Where(r =>
                                            !r.IsDeleted && r.VatTotal != 0m &&
                                            r.AccountPayableNoteDate.Date >= dtpFrom.Value.Date.Date &&
                                            r.AccountPayableNoteDate.Date <= dtpTo.Value.Date.Date))
                                    {
                                        if (bComapanyBranchSelected)
                                            if (oAPN.CompanyBranch_ID != txtBranch.Tag.ToString())
                                                continue;

                                        if (bStoskNoteTypeSelected)
                                            if (oAPN.StockNoteType_ID != txtNoteType.Tag.ToString())
                                                continue;

                                        dtVAT_Schedule02.Rows.Add(
                                          oAPN.BillDate.ToString(cls_Formater.Format_Date3),
                                            oAPN.BillNo, vSupplier.VatRegistrationNo,
                                            vSupplier.SupplierName,
                                            "",
                                            cls_Formater.FormatDecimal(oAPN.GrandTotal - oAPN.VatTotal, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                                            cls_Formater.FormatDecimal(oAPN.VatTotal, clsConfig.sCurrencyDecimalPlaces_UnitPrice));
                                    }
                                }

                                DataView dv = dtVAT_Schedule02.DefaultView;
                                dv.Sort = "Bill_Date";
                                DataTable sortedDT = dv.ToTable();

                                if (dtVAT_Schedule02.Rows.Count > 0)
                                    ExportToExcel(sortedDT);
                                else
                                    MessageBox.Show("No Data Found...", clsFormatter.GetMessageCaption(),
                                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }

                            #endregion

                            #region VAT Schedule 04 Excel Report

                            else if (Report == enum_ReportName.ST_Tax_Reports_VAT_Schedule04)
                            {
                                DataTable dtVAT_Schedule04 = new DataTable();
                                dtVAT_Schedule04.Columns.Add("TIN_No");
                                dtVAT_Schedule04.Columns.Add("Invoice_Date");
                                dtVAT_Schedule04.Columns.Add("Invoice_No");
                                dtVAT_Schedule04.Columns.Add("DebitOrCredit_Note");
                                dtVAT_Schedule04.Columns.Add("DebitOrCredit_Note_Date");
                                dtVAT_Schedule04.Columns.Add("DebitOrCredit_Note_No");
                                dtVAT_Schedule04.Columns.Add("CreditNoteOrDebitNote_Value");
                                dtVAT_Schedule04.Columns.Add("VAT_Amount");
                                dtVAT_Schedule04.Columns.Add("IssuedByMe");

                                var vCustomers = tbl_genCustomerMaster.SelectAll().ToList();

                                if (bCustomerClassSelected)
                                    vCustomers = vCustomers.Where(r => r.CustomerClass_ID == txtCusClass.Tag.ToString()).ToList();
                                if (bCustomerTypeSelected)
                                    vCustomers = vCustomers.Where(r => r.CustomerType_ID == txtCusType.Tag.ToString()).ToList();
                                if (bCustomerCategorySelected)
                                    vCustomers = vCustomers.Where(r => r.CustomerCategory_ID == txtCusCategory.Tag.ToString()).ToList();
                                if (bCustomerSelected)
                                    vCustomers = vCustomers.Where(r => r.Customer_ID == txtCustomer.Tag.ToString()).ToList();
                                if (bSelesRepSelected && chkUseCustomerMastorSaleRep.Checked)
                                    vCustomers = vCustomers.Where(r => r.SalesRep_ID == txtSalesRep.Tag.ToString()).ToList();
                                if (bRouteSelected && chkUseCustomerMasterRoute.Checked)
                                    vCustomers = vCustomers.Where(r => r.Route_ID == txtRoute.Tag.ToString()).ToList();

                                foreach (var oCustomer in vCustomers)
                                {
                                    clsHelpMethods.startProgressBar(0, vCustomers.Count() + 2, 1, ProgressBar);

                                    #region Debit Notes
                                    foreach (var oDebitNote in tbl_bpsDebitNote.SelectAllByCustomer_ID(oCustomer.Customer_ID).Where(r => !r.IsDeleted && r.VatTotal != 0m &&
                                              r.DebitNoteDate.Date >= dtpFrom.Value.Date && r.DebitNoteDate.Date <= dtpTo.Value.Date && r.VatTotal != 0))
                                    {
                                        if (bComapanyBranchSelected)
                                            if (oDebitNote.CompanyBranch_ID != txtBranch.Tag.ToString())
                                                continue;

                                        if (bSalesNoteTypeSelected)
                                            if (oDebitNote.SalesNoteType_ID != txtSalesNoteType.Tag.ToString())
                                                continue;

                                        tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oDebitNote.Invoice_ID);
                                        if (oInvoice != null)
                                        {
                                            dtVAT_Schedule04.Rows.Add(oCustomer.VatRegistrationNo, (oInvoice != null ? oInvoice.InvoiceDate.ToString(cls_Formater.Format_Date3) : ""), oDebitNote.Invoice_ID != "default" ? oDebitNote.Invoice_ID : "", "Debit",
                                                oDebitNote.DebitNoteDate.ToString(cls_Formater.Format_Date3), oDebitNote.DebitNote_ID, cls_Formater.FormatDecimal((oDebitNote.TotalAmount - oDebitNote.VatTotal), clsConfig.sCurrencyDecimalPlaces_UnitPrice), cls_Formater.FormatDecimal(oDebitNote.VatTotal, clsConfig.sCurrencyDecimalPlaces_UnitPrice), "");
                                        }
                                    }
                                    #endregion

                                    #region  Credit Notes
                                    foreach (var oCreditNote in tbl_bpsCreditNote.SelectAllByCustomer_ID(oCustomer.Customer_ID).Where(r => !r.IsDeleted && r.AdvanceReceived_Index == -1 &&
                                           r.CreditNoteDate.Date >= dtpFrom.Value.Date && r.CreditNoteDate.Date <= dtpTo.Value.Date))
                                    {
                                        if (oCreditNote.PosReturnTransaction_Index == -1)
                                            if (oCreditNote.VatTotal == 0)
                                                continue;

                                        if (bComapanyBranchSelected)
                                            if (oCreditNote.CompanyBranch_ID != txtBranch.Tag.ToString())
                                                continue;

                                        if (bSalesNoteTypeSelected)
                                            if (oCreditNote.SalesNoteType_ID != txtSalesNoteType.Tag.ToString())
                                                continue;

                                        #region Pos Txn
                                        tbl_posTransaction oPOS = tbl_posTransaction.Select(oCreditNote.PosReturnTransaction_Index);
                                        if (oPOS != null && oCreditNote.PosReturnTransaction_Index != -1)
                                        {
                                            decimal dTotalAmount = oCreditNote.TotalAmount < 0 ? -1 * oCreditNote.TotalAmount : oCreditNote.TotalAmount;

                                            #region Reverse calculation
                                            decimal dNbtAmout = 0, dvatAmount = 0, dSvatAmount = 0, dSubTotal = dTotalAmount;
                                            decimal dDiscountTotal = oCreditNote.DiscountTotal;
                                            decimal dDiscountPresentage = (dTotalAmount == 0) ? 0 : (dDiscountTotal * 100 / dTotalAmount);

                                            clsHelpMethods.CalculateGrandTotalReverce(dTotalAmount, ref dvatAmount, oCreditNote.VatPercentage, true, ref dSvatAmount, oCreditNote.OtherTaxPercentage, false,
                                                ref dNbtAmout, oCreditNote.NbtPercentage, false, ref dDiscountTotal, dDiscountPresentage, ref dSubTotal);
                                            #endregion

                                            //dtVAT_Schedule04.Rows.Add(
                                            //    oCustomer.VatRegistrationNo, 
                                            //    (oPOS != null ?  oPOS.PosTransactiondate.ToString(cls_Formater.Format_Date3) : ""), 
                                            //    oCreditNote.Invoice_ID != "default" ? oCreditNote.Invoice_ID : "",
                                            //    "Credit",
                                            //    "'", 
                                            //    oCreditNote.CreditNoteDate.ToString(cls_Formater.Format_Date3), 
                                            //    oCreditNote.CreditNote_ID, 
                                            //    cls_Formater.FormatDecimal(dTotalAmount - dvatAmount, clsConfig.sCurrencyDecimalPlaces_UnitPrice), 
                                            //    cls_Formater.FormatDecimal(dvatAmount, clsConfig.sCurrencyDecimalPlaces_UnitPrice), "");

                                            dtVAT_Schedule04.Rows.Add(
                                                oCustomer.VatRegistrationNo,
                                                (oPOS != null ? oPOS.PosTransactiondate.ToString(cls_Formater.Format_Date3) : ""),
                                                oCreditNote.Invoice_ID != "default" ? oCreditNote.Invoice_ID : "",
                                                "Credit",
                                                oCreditNote.CreditNoteDate.ToString(cls_Formater.Format_Date3),
                                                oCreditNote.CreditNote_ID,
                                                cls_Formater.FormatDecimal(dTotalAmount - dvatAmount, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                                                cls_Formater.FormatDecimal(dvatAmount, clsConfig.sCurrencyDecimalPlaces_UnitPrice), "");
                                        }
                                        #endregion

                                        #region Invoice
                                        else
                                        {
                                            tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oCreditNote.Invoice_ID);
                                            if (oInvoice != null && oCreditNote.VatTotal != 0m && oCreditNote.Invoice_ID != "default")
                                            {
                                                dtVAT_Schedule04.Rows.Add(oCustomer.VatRegistrationNo, oInvoice.InvoiceDate.ToString(cls_Formater.Format_Date3), oCreditNote.Invoice_ID, "Credit", oCreditNote.CreditNoteDate.ToString(cls_Formater.Format_Date3), oCreditNote.CreditNote_ID,
                                                    cls_Formater.FormatDecimal(oCreditNote.TotalAmount - oCreditNote.VatTotal, clsConfig.sCurrencyDecimalPlaces_UnitPrice), cls_Formater.FormatDecimal(oCreditNote.VatTotal, clsConfig.sCurrencyDecimalPlaces_UnitPrice), "");
                                            }
                                            else
                                            {
                                                dtVAT_Schedule04.Rows.Add(oCustomer.VatRegistrationNo, "", "-", "Credit", oCreditNote.CreditNoteDate.ToString(cls_Formater.Format_Date3), oCreditNote.CreditNote_ID,
                                                    cls_Formater.FormatDecimal(oCreditNote.TotalAmount - oCreditNote.VatTotal, clsConfig.sCurrencyDecimalPlaces_UnitPrice), cls_Formater.FormatDecimal(oCreditNote.VatTotal, clsConfig.sCurrencyDecimalPlaces_UnitPrice), "");
                                            }
                                        }
                                        #endregion
                                    }
                                    #endregion

                                    foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByCustomer_ID(oCustomer.Customer_ID).Where(p => !p.IsDeleted && p.PaymentMethod_ID == 5 && p.DateRegister.Date >= dtpFrom.Value.Date && p.DateRegister.Date <= dtpTo.Value.Date))
                                    {
                                        tbl_posReceipt oPR = tbl_posReceipt.Select(oCheque.PosReceipt_ID);
                                        if (oPR != null)
                                        {
                                            tbl_posTransaction oPOS = tbl_posTransaction.Select(oPR.PosTransaction_Index);
                                            if (oPOS != null)
                                            {

                                                #region Reverse calculation
                                                decimal dNbtAmout = 0, dvatAmount = 0, dSvatAmount = 0, dSubTotal = oCheque.Amount;
                                                decimal dDiscountTotal = 0;
                                                decimal dDiscountPresentage = 0;

                                                clsHelpMethods.CalculateGrandTotalReverce(oCheque.Amount, ref dvatAmount, oPOS.VatPercentage, true, ref dSvatAmount, oPOS.OtherTaxPercentage, false,
                                                    ref dNbtAmout, oPOS.NbtPercentage, false, ref dDiscountTotal, dDiscountPresentage, ref dSubTotal);
                                                #endregion

                                                dtVAT_Schedule04.Rows.Add(
                                                    oCustomer.VatRegistrationNo,
                                                    "'" + oCheque.DateRegister.ToString(cls_Formater.Format_Date3),
                                                    "Gift Voucher - " + oCheque.GiftVoucherID,
                                                    "Credit",
                                                    oCheque.DateRegister.ToString(cls_Formater.Format_Date3),
                                                    "Gift Voucher - " + oCheque.GiftVoucherID,
                                                    cls_Formater.FormatDecimal(oCheque.Amount - dvatAmount, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                                                    cls_Formater.FormatDecimal(dvatAmount, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                                                    "");
                                            }
                                        }
                                    }
                                }
                                DataView dv = dtVAT_Schedule04.DefaultView;
                                dv.Sort = "DebitOrCredit_Note_Date";
                                DataTable sortedDT = dv.ToTable();


                                if (dtVAT_Schedule04.Rows.Count > 0)
                                    ExportToExcel(sortedDT);
                                else
                                    MessageBox.Show("No Data Found...", clsFormatter.GetMessageCaption(),
                                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }

                            #endregion

                            #region SVAT Schedule 04 
                            else if (Report == enum_ReportName.ST_Tax_Reports_SVAT_Schedule04)
                            {
                                try
                                {
                                    if (txtCustomer.Tag != null)
                                    {
                                        Cursor = Cursors.WaitCursor;

                                        #region For Cpnsignee
                                        bool isConsignee = false;
                                        tbl_genCustomerMaster_Consignee oConsignee = tbl_genCustomerMaster_Consignee.Select(1, (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Length > 0) ? txtCustomer.Tag.ToString() : "defult");
                                      //  if (oConsignee != null && oConsignee.Customer_ID != "default")
                                        //    isConsignee = true;
                                        #endregion

                                        string s_Path = "";
                                        s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                                        s_Path += @"\Reports\SAS\Standard\rpt_sas_Svat_04.rpt";

                                        CrystalDecisions.CrystalReports.Engine.ReportDocument objRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                                        objRpt.Load(s_Path);

                                        string  sReportTitle = "Goods/Services Declaration under SVATS";

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

                                        tbl_genCustomerMaster odetail = tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString().Trim());
                                        if (odetail != null && odetail.Customer_ID != "default")
                                        {
                                            objRpt.DataDefinition.FormulaFields["CustomerName"].Text = isConsignee ? clsCommon.fncsetstring(oConsignee.ConsigneeName.ToString()) : clsCommon.fncsetstring(txtCustomer.Text.Trim());
                                            objRpt.DataDefinition.FormulaFields["CustomeVatNo"].Text = isConsignee ? clsCommon.fncsetstring(oConsignee.VatRegistrationNo.ToString()) : clsCommon.fncsetstring(odetail.VatRegistrationNo);
                                            objRpt.DataDefinition.FormulaFields["CustomeSVatNo"].Text = isConsignee ? clsCommon.fncsetstring(oConsignee.SvatRegistrationNo.ToString()) : clsCommon.fncsetstring(odetail.SvatRegistrationNo);
                                            objRpt.DataDefinition.FormulaFields["CustomerAddress"].Text = isConsignee ? clsCommon.fncsetstring(oConsignee.ConsigneeAddress.ToString().Replace("\n", " ").Replace("\t", " ").Replace("\r", " ")) : clsCommon.fncsetstring(clsGenaralName.getName_CustomerRegisterAddress(odetail.Customer_ID).Replace("\n", " ").Replace("\t", " ").Replace("\r", " "));
                                            objRpt.DataDefinition.FormulaFields["CustomerEmail"].Text = clsCommon.fncsetstring(odetail.Email);
                                        }


                                      

                                        string sCustomer_id = "";
                                        string sCompanyBranch_id = "";

                                        if (bCustomerSelected)
                                            sCustomer_id = txtCustomer.Tag.ToString();
                                        if (bComapanyBranchSelected)
                                            sCompanyBranch_id = txtBranch.Tag.ToString();

                                        decimal dSvat5Amount=0, dSvat5aAmount=0 , dSvat5bAmount=0;
                                        decimal d5Amount = 0, d5aAmount = 0, d5bAmount = 0;
                                        int iSvat5Count = 0, iSvat5aCount=0, iSvat5bCount=0;

                                      DataTable  dt = DBHandling.ExecQuery("select isNull(sum(Value_of_Supply),0) Amount ,isNull(sum(Suspended_VAT_Amount),0) SVATAmount,count(Suspended_VAT_Amount) count from  dbo.func_Tax_Reports_SVAT_Schedule05('" + dtpFrom.Value.Date + "', '"+ dtpTo.Value.Date + "', '"+sCustomer_id+"', '"+ sCompanyBranch_id + "')"    ).Tables[0];
                                        if (dt != null && dt.Rows.Count > 0)
                                        {
                                            foreach (DataRow dtRow1 in dt.Rows)
                                            {
                                                dSvat5Amount =decimal.Parse( dtRow1["SVATAmount"].ToString());
                                                iSvat5Count = int.Parse(dtRow1["count"].ToString());
                                                d5Amount= decimal.Parse(dtRow1["Amount"].ToString());
                                            }
                                        }

                                        DataTable dt2 = DBHandling.ExecQuery("select isNull(sum(Value_of_SVAT_Debit_Note),0) Amount ,isNull(sum(Suspended_VAT_Amount),0) SVATAmount,count(Suspended_VAT_Amount) count from  dbo.func_Tax_Reports_SVAT_Schedule05a('" + dtpFrom.Value.Date + "', '" + dtpTo.Value.Date + "', '" + sCustomer_id + "', '" + sCompanyBranch_id + "')").Tables[0];
                                        if (dt2 != null && dt.Rows.Count > 0)
                                        {
                                            foreach (DataRow dtRow1 in dt2.Rows)
                                            {
                                                dSvat5aAmount = decimal.Parse(dtRow1["SVATAmount"].ToString());
                                                iSvat5aCount = int.Parse(dtRow1["count"].ToString());
                                                d5aAmount = decimal.Parse(dtRow1["Amount"].ToString());
                                            }
                                        }
                                        DataTable dt3 = DBHandling.ExecQuery("select isNull(sum(Value_of_SVAT_Credit_Note),0) Amount ,isNull(sum(Suspended_VAT_Amount),0) SVATAmount,count(Suspended_VAT_Amount) count from  dbo.func_Tax_Reports_SVAT_Schedule05b('" + dtpFrom.Value.Date + "', '" + dtpTo.Value.Date + "', '" + sCustomer_id + "', '" + sCompanyBranch_id + "')").Tables[0];
                                        if (dt3 != null && dt3.Rows.Count > 0)
                                        {
                                            foreach (DataRow dtRow1 in dt.Rows)
                                            {
                                                dSvat5bAmount = decimal.Parse(dtRow1["SVATAmount"].ToString());
                                                iSvat5bCount = int.Parse(dtRow1["count"].ToString());
                                                d5bAmount = decimal.Parse(dtRow1["Amount"].ToString());
                                            }
                                        }

                                        objRpt.DataDefinition.FormulaFields["InvoiceTotal"].Text = clsCommon.fncsetstring(clsFormatter.FormatDecimalPlaces_Price(dSvat5Amount));
                                        objRpt.DataDefinition.FormulaFields["InvoiceTotal"].Text = clsCommon.fncsetstring(clsFormatter.FormatDecimalPlaces_Price(dSvat5aAmount).ToString());
                                        objRpt.DataDefinition.FormulaFields["CreditNoteTotal"].Text = clsCommon.fncsetstring(clsFormatter.FormatDecimalPlaces_Price(dSvat5bAmount).ToString());
                                        objRpt.DataDefinition.FormulaFields["TotalAmount"].Text = clsCommon.fncsetstring(clsFormatter.FormatDecimalPlaces_Price(dSvat5Amount- dSvat5bAmount+ dSvat5aAmount).ToString());
                                        objRpt.DataDefinition.FormulaFields["SvatAmount"].Text = clsCommon.fncsetstring(clsFormatter.FormatDecimalPlaces_Price(d5Amount - d5aAmount + d5aAmount).ToString());

                                        //        objRpt.DataDefinition.FormulaFields["CreditNoteTotal"].Text = clsCommon.fncsetstring(clsFormatter.FormatDecimalPlaces_Price(dTotalAmount).ToString());
                                        //     objRpt.DataDefinition.FormulaFields["CreditNoteCount"].Text = clsCommon.fncsetstring(iCreditnotecount.ToString());

                                        //    objRpt.DataDefinition.FormulaFields["TotalAmount"].Text = clsCommon.fncsetstring(clsFormatter.FormatDecimalPlaces_Price(dTotalAmountInvoice - dTotalAmount).ToString());
                                        //   objRpt.DataDefinition.FormulaFields["SvatAmount"].Text = clsCommon.fncsetstring(clsFormatter.FormatDecimalPlaces_Price((dTotalAmountInvoice - dTotalAmount) * clsCommon.getPesentageOtherTax() / 100).ToString());

                                        //if (isConsignee)
                                        //{
                                        //    objRpt.DataDefinition.FormulaFields["ConInvoiceTotal"].Text = clsCommon.fncsetstring(clsFormatter.FormatDecimalPlaces_Price(dTotalAmountInvoice).ToString());
                                        //    objRpt.DataDefinition.FormulaFields["InvoiceCount"].Text = clsCommon.fncsetstring(iInvoicecount.ToString());
                                        //    objRpt.DataDefinition.FormulaFields["InvoiceTotal"].Text = clsCommon.fncsetstring("-");
                                        //}
                                        //else
                                        //{
                                        //    objRpt.DataDefinition.FormulaFields["InvoiceTotal"].Text = clsCommon.fncsetstring(clsFormatter.FormatDecimalPlaces_Price(dTotalAmountInvoice).ToString());
                                        //    objRpt.DataDefinition.FormulaFields["InvoiceCount"].Text = clsCommon.fncsetstring(iInvoicecount.ToString());
                                        //    objRpt.DataDefinition.FormulaFields["ConInvoiceTotal"].Text = clsCommon.fncsetstring("-");
                                        //}

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

                            #region SVAT Schedule 05 Excel Report
                            else if (Report == enum_ReportName.ST_Tax_Reports_SVAT_Schedule05)
                            {
                                try
                                {
                                    Cursor = Cursors.WaitCursor;
                                    DataTable dt = new DataTable();

                                    string sCustomer_id = "";
                                    string sCompanyBranch_id = "";
                                    if (bCustomerSelected)
                                        sCustomer_id = txtCustomer.Tag.ToString();
                                    if (bComapanyBranchSelected)
                                        sCompanyBranch_id = txtBranch.Tag.ToString();

                                    dt = DBHandling.ExecQuery("Exec sp_Tax_Reports_SVAT_Schedule05 '" + dtpFrom.Value.Date + "','" + dtpTo.Value.Date + "','" + sCustomer_id + "', '" + sCompanyBranch_id + "'").Tables[0];

                                    if (dt.Rows.Count > 0)
                                        ExportToExcel(dt);
                                    else
                                        MessageBox.Show("No Data Found...", clsFormatter.GetMessageCaption(),
                                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                catch (Exception)
                                {
                                }
                                finally
                                {
                                    Cursor = Cursors.Default;
                                }
                            }
                            #endregion

                            #region SVAT Schedule 05a Excel Report
                            else if (Report == enum_ReportName.ST_Tax_Reports_SVAT_Schedule05a)
                            {
                                try
                                {
                                    Cursor = Cursors.WaitCursor;
                                    DataTable dt = new DataTable();

                                    string sCustomer_id = "";
                                    string sCompanyBranch_id = "";
                                    if (bCustomerSelected)
                                        sCustomer_id = txtCustomer.Tag.ToString();
                                    if (bComapanyBranchSelected)
                                        sCompanyBranch_id = txtBranch.Tag.ToString();

                                    dt = DBHandling.ExecQuery("Exec sp_Tax_Reports_SVAT_Schedule05a '" + dtpFrom.Value.Date + "','" + dtpTo.Value.Date + "','" + sCustomer_id + "', '" + sCompanyBranch_id + "'").Tables[0];

                                    if (dt.Rows.Count > 0)
                                        ExportToExcel(dt);
                                    else
                                        MessageBox.Show("No Data Found...", clsFormatter.GetMessageCaption(),
                                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                catch (Exception)
                                {
                                   
                                }
                                finally
                                {
                                    Cursor = Cursors.Default;
                                }
                            }
                            #endregion

                            #region SVAT Schedule 05b Excel Report
                            else if (Report == enum_ReportName.ST_Tax_Reports_SVAT_Schedule05b)
                            {
                                try
                                {
                                    Cursor = Cursors.WaitCursor;
                                    DataTable dt = new DataTable();

                                    string sCustomer_id = "";
                                    string sCompanyBranch_id = "";

                                    if (bCustomerSelected)
                                        sCustomer_id = txtCustomer.Tag.ToString();
                                    if (bComapanyBranchSelected)
                                        sCompanyBranch_id = txtBranch.Tag.ToString();

                                    dt = DBHandling.ExecQuery("Exec sp_Tax_Reports_SVAT_Schedule05b '" + dtpFrom.Value.Date + "','" + dtpTo.Value.Date + "','" + sCustomer_id + "', '" + sCompanyBranch_id + "'").Tables[0];

                                    if (dt.Rows.Count > 0)
                                        ExportToExcel(dt);
                                    else
                                        MessageBox.Show("No Data Found...", clsFormatter.GetMessageCaption(),
                                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                catch (Exception)
                                {
                                }
                                finally
                                {
                                    Cursor = Cursors.Default;
                                }
                            }
                            #endregion

                            #region SVAT Schedule 06 Excel Report
                            else if (Report == enum_ReportName.ST_Tax_Reports_SVAT_Schedule06)
                            {
                                try
                                {
                                    Cursor = Cursors.WaitCursor;
                                    DataTable dt = new DataTable();

                                    string sCustomer_id = "";
                                    string sCompanyBranch_id = "";

                                    if (bCustomerSelected)
                                        sCustomer_id = txtSupplier.Tag.ToString();
                                    if (bComapanyBranchSelected)
                                        sCompanyBranch_id = txtBranch.Tag.ToString();

                                    dt = DBHandling.ExecQuery("Exec sp_Tax_Reports_SVAT_Schedule06 '" + dtpFrom.Value.Date + "','" + dtpTo.Value.Date + "','" + sCustomer_id + "', '" + sCompanyBranch_id + "'").Tables[0];

                                    if (dt.Rows.Count > 0)
                                        ExportToExcel(dt);
                                    else
                                        MessageBox.Show("No Data Found...", clsFormatter.GetMessageCaption(),
                                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                catch (Exception)
                                {
                                }
                                finally
                                {
                                    Cursor = Cursors.Default;
                                }
                            }
                            #endregion

                            #region SVAT Schedule 07 Excel Report
                            else if (Report == enum_ReportName.ST_Tax_Reports_SVAT_Schedule07)
                            {
                                try
                                {
                                    Cursor = Cursors.WaitCursor;
                                    DataTable dt = new DataTable();

                                    string sCustomer_id = "";
                                    string sCompanyBranch_id = "";

                                    if (bCustomerSelected)
                                        sCustomer_id = txtCustomer.Tag.ToString();
                                    if (bComapanyBranchSelected)
                                        sCompanyBranch_id = txtBranch.Tag.ToString();

                                    dt = DBHandling.ExecQuery("Exec sp_Tax_Reports_SVAT_Schedule07 '" + dtpFrom.Value.Date + "','" + dtpTo.Value.Date + "','" + sCustomer_id + "', '" + sCompanyBranch_id + "'").Tables[0];

                                    if (dt.Rows.Count > 0)
                                        ExportToExcel(dt);
                                    else
                                        MessageBox.Show("No Data Found...", clsFormatter.GetMessageCaption(),
                                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                catch (Exception)
                                {
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
                }
                catch (Exception ex)
                {
                    SEACCException.Show(ex);
                    clsValidate.WriteErrorLog("Print Button Click - Error", iFormID, ex);
                }
                finally
                {
                    ProgressBar.Value = 0;
                    Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        #endregion

        #region Clear Fields

        private void ClearField()
        {
            txtCustomer.Tag = null;
            txtCusClass.Tag = null;
            txtCusType.Tag = null;
            txtCusCategory.Tag = null;
            txtSalesNoteType.Tag = null;
            txtSalesRep.Tag = null;
            txtRoute.Tag = null;

            txtSupplier.Tag = null;
            txtNoteType.Tag = null;
            txtSupClass.Tag = null;
            txtSupType.Tag = null;
            txtSupCategory.Tag = null;

            txtBranch.Tag = clsSecurity.BranchID;
            txtBranch.Text = clsSecurity.BranchName;

            txtCustomer.Text = "<All Customers>";
            txtCusClass.Text = "<All Classes>";
            txtCusType.Text = "<All Types>";
            txtCusCategory.Text = "<All Categories>";
            txtSalesRep.Text = "<All SalesReps>";
            txtRoute.Text = "<All Routes>"; ;
            txtSalesNoteType.Text = "<All Note Types>";

            txtSupplier.Text = "<All Supplier>";
            txtNoteType.Text = "<All Stock Notes>";
            txtSupClass.Text = "<All Supplier Class>";
            txtSupType.Text = "<All Supplier Type>";
            txtSupCategory.Text = "<All Supplier Category>";

            cmbTaxType.SelectedIndex = 0;

            dtpFrom.Value = clsSecurity.getServerDateTime();
            dtpTo.Value = clsSecurity.getServerDateTime();

            chkShowAll_Branch.Checked = false;
            chkShowAll_Customers.Checked = false;
            chkShowAll_Customers.Checked = false;

            txtCusCategory.Enabled = true;
            txtCusType.Enabled = true;
            txtCusClass.Enabled = true;

            txtSupClass.Enabled = true;
            txtSupType.Enabled = true;
            txtCusCategory.Enabled = true;

            tbl_genCompanyBranchMaster oBranch = tbl_genCompanyBranchMaster.Select(clsSecurity.BranchID);
            if (oBranch != null)
            {
                txtBranch.Text = clsGenaralName.getName_CompanyBranchMaster(clsSecurity.BranchID);
                txtBranch.Tag = clsSecurity.BranchID;

                if (!oBranch.IsHeadOffice)
                {
                    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBranch, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblBranch, false);
                    clsCommon.SetEnableDisable_NormalCheckBox(chkShowAll_Branch, false);
                }
            }

            flowLayoutCustomerDetailPanel.Visible = true;
            flowLayoutSupplierDetailPanel.Visible = true;

            clsCommon.SetEnableDisable_NormalCheckBox(chkShowAll_Customers, true);
            
            clsCommon.SetVisibility_Panel(pnlBranch, false);
            clsCommon.SetVisibility_Panel(pnlCusName, false);
            clsCommon.SetVisibility_Panel(pnlCusType, false);
            clsCommon.SetVisibility_Panel(pnlSalesman, false);
            clsCommon.SetVisibility_Panel(pnlRoute, false);
            clsCommon.SetVisibility_Panel(pnlNoteType, false);
            clsCommon.SetVisibility_Panel(pnlTaxType, false);
            clsCommon.SetVisibility_Panel(pnlSupplier, false);
            clsCommon.SetVisibility_Panel(pnlNoteT, false);
        }

        #endregion

        #region Refresh Grid - Display Reports
        private void DisplayReports()
        {
            try
            {
                dgvReports.Rows.Clear();

                dgvReports.DataSource = DBHandling.ExecQuery("EXEC sp_Reports '" + 35 + "'").Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Grid Events
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

        #region Search Events
        private void txtBranch_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_CompanyBranch(ref txtBranch);
        }


        private void txtCusClass_DoubleClick(object sender, EventArgs e)
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CustomerClass();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtCusClass.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtCusClass.Tag = frmSearchMaster.s_SearchID;
        }

        private void txtCusType_DoubleClick(object sender, EventArgs e)
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CustomerType();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtCusType.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtCusType.Tag = frmSearchMaster.s_SearchID;
        }

        private void txtCusCategory_DoubleClick(object sender, EventArgs e)
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_CustomerCategory();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtCusCategory.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtCusCategory.Tag = frmSearchMaster.s_SearchID;
        }

        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            //clsSearch.Search_MasterCustomer(ref txtCustomer, chkShowAll_Customers.Checked);
            clsSearch.Search_MasterCustomerAll(ref txtCustomer, chkShowAll_Customers.Checked);

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

        private void txtSalesRep_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterSalesRep(ref txtSalesRep);
        }

        private void txtRoute_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterRoute(ref txtRoute);
        }

        private void txtSalesNoteType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            clsSearch.Search_MasterSalesNoteType(ref txtSalesNoteType);
        }

        private void txtSupClass_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_SupplierClass();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtSupClass.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtSupClass.Tag = frmSearchMaster.s_SearchID;
        }

        private void txtSupType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_SupplierType();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtSupType.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtSupType.Tag = frmSearchMaster.s_SearchID;
        }

        private void txtSupCategory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_SupplierCategory();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtSupCategory.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtSupCategory.Tag = frmSearchMaster.s_SearchID;
        }

        private void txtSupplier_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_SupplierMaster();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtSupplier.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtSupplier.Tag = frmSearchMaster.s_SearchID;

                tbl_genSupplierMaster oSupplier = tbl_genSupplierMaster.Select(frmSearchMaster.s_SearchID);
                if (oSupplier != null && oSupplier.Supplier_ID != "default")
                {
                    txtSupClass.Tag = oSupplier.SupplierClass_ID;
                    txtSupType.Tag = oSupplier.SupplierType_ID;
                    txtSupCategory.Tag = oSupplier.SupplierCategory_ID;

                    txtSupClass.Text = clsGenaralName.getName_SupplierClass(oSupplier.SupplierClass_ID);
                    txtSupType.Text = clsGenaralName.getName_SupplierType(oSupplier.SupplierType_ID);
                    txtSupCategory.Text = clsGenaralName.getName_SupplierCategory(oSupplier.SupplierCategory_ID);

                    txtSupClass.Enabled = false;
                    txtSupType.Enabled = false;
                    txtCusCategory.Enabled = false;
                }
            }
        }

        private void txtNoteType_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStockNoteType(ref txtNoteType);
        }
        #endregion

        #region Checked Change
        private void chkShowAll_Branch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowAll_Branch.Checked == true)
            {
                txtBranch.Tag = null;
                txtBranch.Text = "<All Company Branches>";

                clsCommon.SetEnableDisable_NormalLabel(lblBranch, false);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBranch, false);
            }
            else
            {
                txtBranch.Tag = clsSecurity.BranchID;
                txtBranch.Text = clsGenaralName.getName_CompanyBranchMaster(clsSecurity.BranchID);

                clsCommon.SetEnableDisable_NormalLabel(lblBranch, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBranch, true);
            }
        }
        #endregion

        #region Help Methods

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
                        tbl_pmsProductionJobRegister oJob = tbl_pmsProductionJobRegister.Select(oInvoice.Job_ID);
                        if (oJob != null)
                            sInvoiceType = clsGenaralName.getName_ProductionJobType(oJob.ProductionJobType_ID);
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
                tbl_pmsProductionJobRegister oProductionRegister = tbl_pmsProductionJobRegister.Select(oInvoice.Job_ID);
                if (oProductionRegister != null & oCustomer != null)
                {
                    if (oCustomer.CustomerType_ID == "2" && oCustomer.IsSVATenable)
                    {
                        string sPONo = "";
                        if (oInvoice.Job_ID == "default" && oInvoice.DeliveryOrder_ID != "default") //Direct Sales
                            sPONo = clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID);
                        else if (oInvoice.Quotation_ID != "default" && oInvoice.DeliveryOrder_ID == "default") //Block Invoice
                            sPONo = clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID);
                        else if (oInvoice.Job_ID != "default" && oInvoice.DeliveryOrder_ID != "default") //Normal Invoice
                            sPONo = clsHelpMethods.GetPONoByProductionJobID(oInvoice.Job_ID);
                        decimal dCurrencyTotal = 0, dCurrencyVat = 0;

                        dCurrencyTotal = (oInvoice.Currency_ID == clsConfig.sLocalCurrencyCode) ? 0 : oInvoice.GrandTotal / oInvoice.CurrencyRate;
                        dCurrencyVat = (oInvoice.Currency_ID == clsConfig.sLocalCurrencyCode) ? 0 : oInvoice.OtherTaxTotal / oInvoice.CurrencyRate;

                        glb_dtsSales.dt_sasTaxDetails_Invoice.Adddt_sasTaxDetails_InvoiceRow(oInvoice.Invoice_ID, oInvoice.InvoiceDate, clsGenaralName.getName_Customer(oInvoice.Customer_ID),
                            clsGenaralName.getName_BranchCustomer(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID)), oInvoice.GrandTotal, oInvoice.GrandTotal,
                            0, oInvoice.OtherTaxTotal, oInvoice.GrandTotal, sPONo, oInvoice.DeliveryOrder_ID, oInvoice.Job_ID, oInvoice.CurrencyRate, clsGenaralName.getName_CurrencyCode(oInvoice.Currency_ID),
                            clsGenaralName.getName_ProductionJobType(oProductionRegister.ProductionJobType_ID), oInvoice.DateCreate, dCurrencyTotal, dCurrencyVat, sInvoiceType);
                        iInvoiceCount += 1;
                        dTotalAmount += oInvoice.GrandTotal;
                    }
                }
                clsHelpMethods.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
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
                                    oCreditNote.CurrencyRate, clsHelpMethods.getDisplayPrice(dSubTotal, oCreditNote.CurrencyRate), clsHelpMethods.getDisplayPrice(dVatAmount, oCreditNote.CurrencyRate), dSubTotal, "",
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
                                    oCreditNote.CurrencyRate, clsHelpMethods.getDisplayPrice(dSubTotal, oCreditNote.CurrencyRate), clsHelpMethods.getDisplayPrice(dVatAmount, oCreditNote.CurrencyRate), dSubTotal, "",
                                    oCreditNote.IsDeleted, oCreditNote.PrintCount, oCreditNote.Invoice_ID, oCreditNote.TotalAmount, oCreditNote.Remark, "", clsSecurity.getServerDateTime().Date,
                                     oCreditNote.TotalAmount, oCreditNote.VatTotal, oCreditNote.NbtTotal, oCreditNote.SubTotal, 1, "", "", 0, 0, "");
                            }
                        }
                        iCreditNoteCount++;
                        dTotalAmount += oCreditNote.TotalAmount;
                    }
                }
                clsHelpMethods.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
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

        #region Print Method

        #region print Method For Sql View
        private void print(string path, string sReportTitle, string sFormula, string sFilter)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Standed Reports";
                CrystalDecisions.CrystalReports.Engine.ReportDocument RD = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                frm_ReportViewer viewer = new frm_ReportViewer();
                RD.Load(s_Path);
                clsSecurity.LogonServer(ref RD);
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

        #region Print method for Data Set
        private void print(string path, string sReportTitle, DataTable objDataTable, string sFilter)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "Standed Reports", sSeperator;
                CrystalDecisions.CrystalReports.Engine.ReportDocument objRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
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

                sSeperator = sFilter.Length > 0 ? " / " : "";
                if (cmbTaxType.Tag != null && cmbTaxType.Tag.ToString().Length > 0)
                    sFilter += sSeperator + "Tax Type : " + cmbTaxType.Text.Trim();
                sSeperator = sFilter.Length > 0 ? " / " : "";
                if (txtRoute.Tag != null && txtRoute.Tag.ToString().Length > 0)
                    sFilter += "Route Name : " + txtRoute.Text.Trim();
                sSeperator = sFilter.Length > 0 ? " / " : "";

                objRpt.DataDefinition.FormulaFields["Filter"].Text = clsCommon.fncsetstring(sFilter);

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

                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sReportTitle, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("HeaderTitle", sHeaderTitle, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqEmail", clsCommon.getCompanyEmail(), true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DateRange", "From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"), true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("UserName", clsSecurity.UserNameLoged, true, false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("sReportNo", iReport.ToString(), true, false);

                if (sFilter != "")
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Filter", sFilter, true, false);

                int iRow = dgvReports.SelectedCells[0].RowIndex;
                iReport = int.Parse(dgvReports.Rows[iRow].Cells[0].Value.ToString());
                enum_ReportName Report = (enum_ReportName)iReport;
                if ((iReport == (int)enum_ReportName.ST_Tax_Report_Invoice_DetailLocalNBTVAT || iReport == (int)enum_ReportName.ST_Tax_Report_Invoice_DetailExportVAT || iReport == (int)enum_ReportName.ST_Tax_Report_Invoice_DetailExportSVAT) && cmbTaxType.Text.Trim() == "Export SVAT" && txtCustomer.Tag != null)
                {
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CustomerName", txtCustomer.Text.Trim(), true, false);
                    tbl_genCustomerMaster odetail = tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString().Trim());
                    if (odetail != null && odetail.Customer_ID != "default")
                    {
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CustomeVatNo", odetail.VatRegistrationNo, true, false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CustomeSVatNo", odetail.SvatRegistrationNo, true, false);
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

        #region Print Method for Excel
        public void ExportToExcel(DataTable dt)
        {
            Microsoft.Office.Interop.Excel.Application WsObj = new Microsoft.Office.Interop.Excel.Application();
            WsObj.Application.Workbooks.Add(Type.Missing);
            WsObj.Visible = false;
            WsObj.Cells[1, 1] = "Created Date & Time : " + DateTime.Now.ToString();
            WsObj.Range[WsObj.Cells[1, 1], WsObj.Cells[1, 5]].Merge();
            try
            {
                int row = 2; int col = 1;
                foreach (DataColumn column in dt.Columns)
                {
                    WsObj.Cells[row, col] = column.ColumnName;
                    WsObj.Cells[row, col].Borders.Color = System.Drawing.Color.Black;
                    WsObj.Cells[row, col].Interior.Color = System.Drawing.Color.LightGray;
                    col++;
                }

                col = 1;
                row++;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    foreach (var cell in dt.Rows[i].ItemArray)
                    {
                        WsObj.Cells[row, col] = cell;
                        WsObj.Cells[row, col].Borders.Color = System.Drawing.Color.Black;

                        col++;
                    }
                    col = 1;
                    row++;
                }

                WsObj.Columns.AutoFit();

                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = ".xls";
                dlg.Filter = "Text documents (.xls)|*.xlsx";
                //   dlg.ShowDialog()
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string filename = dlg.FileName;
                    WsObj.ActiveWorkbook.SaveCopyAs(filename);
                    MessageBox.Show("Excel File is successfully created", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                WsObj.Visible = true;
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("ExportToExcel Method - Error", iFormID, ex);
            }
            finally
            {
                //System.Runtime.InteropServices;
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(WsObj);
            }
        }
        #endregion

        #endregion

        #region Controls/Enable Disable
        private void setEnableDisableConctrol(int iReportID)
        {
            ClearField();

            if ((iReportID == (int)enum_ReportName.ST_Tax_Report_CreditNote) ||
                (iReportID == (int)enum_ReportName.ST_Tax_Report_Invoice_ExportSVAT) ||
                (iReportID == (int)enum_ReportName.ST_Tax_Report_Invoice_DetailLocalNBTVAT))
            {
                clsCommon.SetVisibility_Panel(pnlBranch, true);
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlCusType, true);
                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlNoteType, true);
                clsCommon.SetVisibility_Panel(pnlTaxType, true);
            }

            else if ((iReportID == (int)enum_ReportName.ST_Tax_Report_Invoice_Detail)||
                (iReportID == (int)enum_ReportName.ST_Tax_Report_Detail_CreditNote))
            {
                clsCommon.SetVisibility_Panel(pnlBranch, true);
                clsCommon.SetVisibility_Panel(pnlCusName, true);
                clsCommon.SetVisibility_Panel(pnlCusType, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
                clsCommon.SetVisibility_Panel(pnlNoteType, true);
            }          
          
            else if ((iReportID == (int)enum_ReportName.ST_Tax_Reports_VAT_Schedule01)||
                iReportID == (int)enum_ReportName.ST_Tax_Reports_VAT_Schedule04)
            {
                clsCommon.SetVisibility_Panel(pnlCusName, true);
            }

            else if ((iReportID == (int)enum_ReportName.ST_Tax_Reports_VAT_Schedule02)|| 
                (iReportID == (int)enum_ReportName.ST_Tax_Reports_SVAT_Schedule06))
            {
                clsCommon.SetVisibility_Panel(pnlSupplier, true);
            }

            else if ((iReportID == (int)enum_ReportName.ST_Tax_Reports_SVAT_Schedule04) ||
                    (iReportID == (int)enum_ReportName.ST_Tax_Reports_SVAT_Schedule05)||
                (iReportID == (int)enum_ReportName.ST_Tax_Reports_SVAT_Schedule05a)||
                (iReportID == (int)enum_ReportName.ST_Tax_Reports_SVAT_Schedule05b)||
                (iReportID == (int)enum_ReportName.ST_Tax_Reports_SVAT_Schedule07))
            {
                clsCommon.SetVisibility_Panel(pnlCusName, true);
            }
        }
        #endregion
        #endregion
    }
}