using DataTire;
using Zion.ERP.Reports.DataSets;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
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
using ZION.ERP.Reports.DataSets;

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
            clsFormatter.setFormatForm(this, clsHelpMethods_Local.getFormName(iFormID), 2, iFormID);
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
                        if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(Report), ref sReportTitle_Main,
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
                                            clsHelpMethods_Local.getDisplayPrice(dWithNBTAmount, oInvoice.CurrencyRate),
                                            clsHelpMethods_Local.getDisplayPrice(dVatAmount, oInvoice.CurrencyRate));
                                        clsHelpMethods_Local.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
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
                                            clsHelpMethods_Local.getDisplayPrice(dWithNBTAmount, oInvoice.CurrencyRate),
                                            clsHelpMethods_Local.getDisplayPrice(dVatAmount, oInvoice.CurrencyRate));
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
                                            clsHelpMethods_Local.getDisplayPrice(dWithNBTAmount, oInvoice.CurrencyRate),
                                            clsHelpMethods_Local.getDisplayPrice(dVatAmount, oInvoice.CurrencyRate));
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
                                            clsHelpMethods_Local.getDisplayPrice(dWithNBTAmount, oCRN.CurrencyRate),
                                            clsHelpMethods_Local.getDisplayPrice(dVatAmount, oCRN.CurrencyRate));

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
                                                sPONo = clsHelpMethods_Local.GetPONoByProductionJobID(oInvoice.Job_ID);

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

                                        clsHelpMethods_Local.startProgressBar(0, lstInvoice.Count + 2, 1, ProgressBar);
                                    }

                                    if (cmbTaxType.Text.Trim() == "Local VAT (Excluding: NBT)")
                                        sReportTitle_Main = "Tax Report Detail - Invoice [Local VAT]";
                                    else
                                        sReportTitle_Main = "Tax Report Detail - Invoice [Local NBT/VAT]";

                                    sReportPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(Report));
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
                                        //tbl_pmsProductionJobRegister oProductionRegister =
                                        //    tbl_pmsProductionJobRegister.Select(oInvoice.Job_ID);

                                        #region filter - DO type

                                        string sDoType = "";
                                        //if (oProductionRegister != null)
                                        //{
                                        //    if (oProductionRegister.ProductionJobType_ID == "PJT/001" ||
                                        //        oProductionRegister.ProductionJobType_ID == "PJT/002")
                                        //        sDoType = "Kandana";
                                        //    else if (oProductionRegister.ProductionJobType_ID == "PJT/003" ||
                                        //             oProductionRegister.ProductionJobType_ID == "PJT/004")
                                        //        sDoType = "Pettah";
                                        //    else if (oProductionRegister.ProductionJobType_ID == "PJT/009" ||
                                        //             oProductionRegister.ProductionJobType_ID == "PJT/010")
                                        //        sDoType = "Direct";
                                        //    else if (oProductionRegister.ProductionJobType_ID == "PJT/013" ||
                                        //             oProductionRegister.ProductionJobType_ID == "PJT/014")
                                        //        sDoType = "Block";
                                        //    else if (oProductionRegister.ProductionJobType_ID == "PJT/011" ||
                                        //             oProductionRegister.ProductionJobType_ID == "PJT/012")
                                        //        sDoType = "Chemical";
                                        //    else
                                        //        sDoType = "-";
                                        //}

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
                                            sPONo = clsHelpMethods_Local.GetPONoByProductionJobID(oInvoice.Job_ID);

                                        decimal dWithNBTAmount = 0,
                                            dSubTotal = 0,
                                            dNBTAmount = 0,
                                            dVatAmount = 0,
                                            dCurrencyTotal = 0,
                                            dCurrencyVat = 0;
                                        //if (oProductionRegister != null & oCustomer != null)
                                        //{
                                        //    if (oCustomer.CustomerType_ID == "2") //Export Customers Only
                                        //    {
                                        //        #region If Export VAT Selected

                                        //        if (cmbTaxType.Text.Trim() == "Export VAT")
                                        //        {
                                        //            if (oCustomer.IsVATenable && !oCustomer.IsSVATenable &&
                                        //                !oCustomer.IsNBTenable)
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

                                        //        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(oInvoice.GrandTotal,
                                        //            oInvoice.VatPercentage, oInvoice.NbtPercentage, ref dWithNBTAmount,
                                        //            ref dSubTotal, ref dNBTAmount, ref dVatAmount);
                                        //        dCurrencyTotal = dSubTotal / oInvoice.CurrencyRate;
                                        //        dCurrencyVat = dVatAmount / oInvoice.CurrencyRate;

                                        //        #region Only For AKT

                                        //        if (clsConfig.sSoftwareModel.Trim() ==
                                        //            SoftwareModel_Sales.akt.ToString())
                                        //        {
                                        //            if (oInvoice.Quotation_ID != "default") //for block invoice
                                        //            {
                                        //                dSubTotal = dWithNBTAmount;
                                        //                dNBTAmount = 0;
                                        //            }
                                        //        }

                                        //        #endregion

                                        //        #region If Zero Rated Selected

                                        //        if (cmbTaxType.Text.Trim() == "DSE Zero Rated")
                                        //        {
                                        //            if (!oCustomer.IsVATenable && !oCustomer.IsSVATenable &&
                                        //                !oCustomer.IsNBTenable)
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

                                        //        glb_dtsSales.dt_sasTaxDetails_Invoice.Adddt_sasTaxDetails_InvoiceRow(
                                        //            oInvoice.Invoice_ID, oInvoice.InvoiceDate,
                                        //            oCustomer.VatRegistrationNo != ""
                                        //                ? clsGenaralName.getName_Customer(oInvoice.Customer_ID) +
                                        //                  "\nVAT Reg : " + oCustomer.VatRegistrationNo
                                        //                : clsGenaralName.getName_Customer(oInvoice.Customer_ID), 
                                        //            clsGenaralName.getName_BranchCustomer(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID)),
                                        //            oInvoice.GrandTotal, dSubTotal,
                                        //            dNBTAmount, dVatAmount, dWithNBTAmount, sPONo,
                                        //            oInvoice.DeliveryOrder_ID, oInvoice.Job_ID, oInvoice.CurrencyRate,
                                        //            clsGenaralName.getName_CurrencyCode(oInvoice.Currency_ID),
                                        //            clsGenaralName.getName_ProductionJobType(oProductionRegister
                                        //                .ProductionJobType_ID), oInvoice.DateCreate, dCurrencyTotal,
                                        //            dCurrencyVat, sInvoiceType);
                                        //    }
                                        //}

                                        clsHelpMethods_Local.startProgressBar(0, lstInvoice.Count + 2, 1, ProgressBar);
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

                                    clsHelpMethods_Local.startProgressBar(0, lstInvoice.Count + 2, 1, ProgressBar);
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
                                                                    clsHelpMethods_Local.getDisplayPrice(dSubTotal,
                                                                        oCreditNote.CurrencyRate),
                                                                    clsHelpMethods_Local.getDisplayPrice(dVatAmount,
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
                                                            clsHelpMethods_Local.getDisplayPrice(dSubTotal,
                                                                oCreditNote.CurrencyRate),
                                                            clsHelpMethods_Local.getDisplayPrice(dVatAmount,
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

                                        clsHelpMethods_Local.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
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
                                                                    clsHelpMethods_Local.getDisplayPrice(dSubTotal,
                                                                        oCreditNote.CurrencyRate),
                                                                    clsHelpMethods_Local.getDisplayPrice(dVatAmount,
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
                                                                clsHelpMethods_Local.getDisplayPrice(dSubTotal,
                                                                    oCreditNote.CurrencyRate),
                                                                clsHelpMethods_Local.getDisplayPrice(dVatAmount,
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

                                        clsHelpMethods_Local.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
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
                                                                    clsHelpMethods_Local.getDisplayPrice(dSubTotal,
                                                                        oCreditNote.CurrencyRate),
                                                                    clsHelpMethods_Local.getDisplayPrice(dVatAmount,
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
                                                            clsHelpMethods_Local.getDisplayPrice(dSubTotal,
                                                                oCreditNote.CurrencyRate),
                                                            clsHelpMethods_Local.getDisplayPrice(dVatAmount,
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

                                        clsHelpMethods_Local.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
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
                                                                    clsHelpMethods_Local.getDisplayPrice(dSubTotal, oCreditNote.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(dVatAmount, oCreditNote.CurrencyRate),
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
                                                        clsHelpMethods_Local.getDisplayPrice(dSubTotal, oCreditNote.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(dVatAmount, oCreditNote.CurrencyRate), dSubTotal, "",
                                                        oCreditNote.IsDeleted, oCreditNote.PrintCount, oCreditNote.Invoice_ID, 0, oCreditNote.Remark, "", clsSecurity.getServerDateTime().Date,
                                                        oCreditNote.TotalAmount, oCreditNote.VatTotal, oCreditNote.NbtTotal, oCreditNote.SubTotal, iRecordCount, "", "", 0, 0, "");
                                            }
                                            #endregion
                                        }
                                    }

                                    clsHelpMethods_Local.startProgressBar(0, Query.Count + 2, 1, ProgressBar);
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

                                var vCustomers = tbl_genCustomerMaster.SelectAll().Where(r => !r.IsDeleted);

                                if (bCustomerClassSelected)
                                    vCustomers = vCustomers.Where(r => r.CustomerClass_ID == txtCusClass.Tag.ToString());
                                if (bCustomerTypeSelected)
                                    vCustomers = vCustomers.Where(r => r.CustomerType_ID == txtCusType.Tag.ToString());
                                if (bCustomerCategorySelected)
                                    vCustomers = vCustomers.Where(r =>  r.CustomerCategory_ID == txtCusCategory.Tag.ToString());
                                if (bCustomerSelected)
                                    vCustomers = vCustomers.Where(r => r.Customer_ID == txtCustomer.Tag.ToString());
                                if (bSelesRepSelected && chkUseCustomerMastorSaleRep.Checked)
                                    vCustomers = vCustomers.Where(r => r.SalesRep_ID == txtSalesRep.Tag.ToString());
                                if (bRouteSelected && chkUseCustomerMasterRoute.Checked)
                                    vCustomers = vCustomers.Where(r => r.Route_ID == txtRoute.Tag.ToString());

                                foreach (var vCustomer in vCustomers)
                                {
                                    clsHelpMethods_Local.startProgressBar(0, vCustomers.Count() + 2, 1, ProgressBar);

                                    foreach (var vInvoice in tbl_sasInvoice.SelectAllByCustomer_ID(vCustomer.Customer_ID).Where(r =>
                                            !r.IsDeleted && !r.IsDebitNote && r.IsVatInvoice &&
                                            r.InvoiceDate.Date >= dtpFrom.Value.Date &&
                                            r.InvoiceDate.Date <= dtpTo.Value.Date))
                                    {
                                        if (bComapanyBranchSelected)
                                            if (vInvoice.CompanyBranch_ID != txtBranch.Tag.ToString())
                                                continue;

                                        if (bSelesRepSelected && !chkUseCustomerMastorSaleRep.Checked)
                                            if (vInvoice.Employee_ID.ToString() != txtSalesRep.Tag.ToString())
                                                continue;
                                        if (bRouteSelected && !chkUseCustomerMasterRoute.Checked)
                                            if (vInvoice.Route_ID.ToString() != txtRoute.Tag.ToString())
                                                continue;
                                        if (bSalesNoteTypeSelected)
                                            if (vInvoice.SalesNoteType_ID != txtSalesNoteType.Tag.ToString())
                                                continue;

                                        dtVAT_Schedule01.Rows.Add(
                                            string.Format("'{0}", vInvoice.InvoiceDate.ToString("MM/dd/yyyy")),
                                            vInvoice.Invoice_ID, 
                                            vCustomer.VatRegistrationNo, 
                                            vCustomer.CustomerName, "",
                                            clsFormatter.FormatDecimal(vInvoice.GrandTotal - vInvoice.VatTotal, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                                            clsFormatter.FormatDecimal(vInvoice.VatTotal, clsConfig.sCurrencyDecimalPlaces_UnitPrice));
                                    }
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
                                    vSuppliers = vSuppliers.Where(r =>
                                        r.SupplierClass_ID == txtSupClass.Tag.ToString());
                                if (bSupplierTypeSelected)
                                    vSuppliers = vSuppliers.Where(r => r.SupplierType_ID == txtSupType.Tag.ToString());
                                if (bSupplierCategorySelected)
                                    vSuppliers = vSuppliers.Where(r =>
                                        r.SupplierCategory_ID == txtSupCategory.Tag.ToString());
                                if (bSupplierSelected)
                                    vSuppliers = vSuppliers.Where(r => r.Supplier_ID == txtSupplier.Tag.ToString());

                                foreach (var vSupplier in vSuppliers)
                                {
                                    clsHelpMethods_Local.startProgressBar(0, vSuppliers.Count() + 2, 1, ProgressBar);

                                    foreach (var vAPN in tbl_accAccountPayableNote
                                        .SelectAllBySupplier_ID(vSupplier.Supplier_ID).Where(r =>
                                            !r.IsDeleted && r.VatTotal != 0m &&
                                            r.AccountPayableNoteDate.Date >= dtpFrom.Value.Date.Date &&
                                            r.AccountPayableNoteDate.Date <= dtpTo.Value.Date.Date))
                                    {
                                        if (bComapanyBranchSelected)
                                            if (vAPN.CompanyBranch_ID != txtBranch.Tag.ToString())
                                                continue;

                                        if (bStoskNoteTypeSelected)
                                            if (vAPN.StockNoteType_ID != txtNoteType.Tag.ToString())
                                                continue;

                                        dtVAT_Schedule02.Rows.Add(
                                            vAPN.AccountPayableNoteDate.ToString(clsFormatter.Format_Date2),
                                            vAPN.AccountPayableNote_ID, vSupplier.VatRegistrationNo,
                                            vSupplier.SupplierName,
                                            "",
                                            clsFormatter.FormatDecimal(vAPN.GrandTotal,
                                                clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                                            clsFormatter.FormatDecimal(vAPN.VatTotal,
                                                clsConfig.sCurrencyDecimalPlaces_UnitPrice));
                                    }
                                }

                                if (dtVAT_Schedule02.Rows.Count > 0)
                                    ExportToExcel(dtVAT_Schedule02);
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

                                var vCustomers = tbl_genCustomerMaster.SelectAll().Where(r => !r.IsDeleted);

                                if (bCustomerClassSelected)
                                    vCustomers = vCustomers.Where(r =>
                                        r.CustomerClass_ID == txtCusClass.Tag.ToString());
                                if (bCustomerTypeSelected)
                                    vCustomers = vCustomers.Where(r => r.CustomerType_ID == txtCusType.Tag.ToString());
                                if (bCustomerCategorySelected)
                                    vCustomers = vCustomers.Where(r =>
                                        r.CustomerCategory_ID == txtCusCategory.Tag.ToString());
                                if (bCustomerSelected)
                                    vCustomers = vCustomers.Where(r => r.Customer_ID == txtCustomer.Tag.ToString());
                                if (bSelesRepSelected && chkUseCustomerMastorSaleRep.Checked)
                                    vCustomers = vCustomers.Where(r => r.SalesRep_ID == txtSalesRep.Tag.ToString());
                                if (bRouteSelected && chkUseCustomerMasterRoute.Checked)
                                    vCustomers = vCustomers.Where(r => r.Route_ID == txtRoute.Tag.ToString());

                                foreach (var vCustomer in vCustomers)
                                {
                                    clsHelpMethods_Local.startProgressBar(0, vCustomers.Count() + 2, 1, ProgressBar);

                                    //Debit Notes
                                    foreach (var vDebitNote in tbl_bpsDebitNote
                                        .SelectAllByCustomer_ID(vCustomer.Customer_ID).Where(r =>
                                            !r.IsDeleted && r.VatTotal != 0m &&
                                            r.DebitNoteDate.Date >= dtpFrom.Value.Date.Date &&
                                            r.DebitNoteDate.Date <= dtpTo.Value.Date.Date))
                                    {
                                        if (bComapanyBranchSelected)
                                            if (vDebitNote.CompanyBranch_ID != txtBranch.Tag.ToString())
                                                continue;

                                        if (bSalesNoteTypeSelected)
                                            if (vDebitNote.SalesNoteType_ID != txtSalesNoteType.Tag.ToString())
                                                continue;

                                        tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(vDebitNote.Invoice_ID);
                                        dtVAT_Schedule04.Rows.Add(vCustomer.VatRegistrationNo,
                                            (oInvoice != null
                                                ? oInvoice.InvoiceDate.ToString(clsFormatter.Format_Date2)
                                                : ""), vDebitNote.Invoice_ID != "default" ? vDebitNote.Invoice_ID : "", "Debit",
                                            vDebitNote.DebitNoteDate.ToString(clsFormatter.Format_Date2),
                                            vDebitNote.DebitNote_ID,
                                            clsFormatter.FormatDecimal(vDebitNote.TotalAmount,
                                                clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                                            clsFormatter.FormatDecimal(vDebitNote.VatTotal,
                                                clsConfig.sCurrencyDecimalPlaces_UnitPrice), "");
                                    }

                                    //Credit Notes
                                    foreach (var vCreditNote in tbl_bpsCreditNote
                                        .SelectAllByCustomer_ID(vCustomer.Customer_ID).Where(r =>
                                            !r.IsDeleted && r.VatTotal != 0m &&
                                            r.CreditNoteDate.Date >= dtpFrom.Value.Date.Date &&
                                            r.CreditNoteDate.Date <= dtpTo.Value.Date.Date))
                                    {
                                        if (bComapanyBranchSelected)
                                            if (vCreditNote.CompanyBranch_ID != txtBranch.Tag.ToString())
                                                continue;

                                        if (bSalesNoteTypeSelected)
                                            if (vCreditNote.SalesNoteType_ID != txtSalesNoteType.Tag.ToString())
                                                continue;

                                        tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(vCreditNote.Invoice_ID);
                                        dtVAT_Schedule04.Rows.Add(vCustomer.VatRegistrationNo,
                                            (oInvoice != null
                                                ? oInvoice.InvoiceDate.ToString(clsFormatter.Format_Date2)
                                                : ""), vCreditNote.Invoice_ID != "default" ? vCreditNote.Invoice_ID : "", "Credit",
                                            vCreditNote.CreditNoteDate.ToString(clsFormatter.Format_Date2),
                                            vCreditNote.CreditNote_ID,
                                            clsFormatter.FormatDecimal(vCreditNote.TotalAmount,
                                                clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                                            clsFormatter.FormatDecimal(vCreditNote.VatTotal,
                                                clsConfig.sCurrencyDecimalPlaces_UnitPrice), "");
                                    }
                                }

                                if (dtVAT_Schedule04.Rows.Count > 0)
                                    ExportToExcel(dtVAT_Schedule04);
                                else
                                    MessageBox.Show("No Data Found...", clsFormatter.GetMessageCaption(),
                                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            txtBranch.Tag = clsSecurity.BranchID;
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
            clsCommon.SetEnableDisable_NormalCheckBox(chkShowAll_Customers, true);

            dtpFrom.Value = clsSecurity.getServerDateTime();
            dtpTo.Value = clsSecurity.getServerDateTime();

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
                if (!oBranch.IsHeadOffice)
                {
                    clsCommon.SetEnableDisable_NormalLabel(lblBranch, false);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtBranch, false);
                    clsCommon.SetEnableDisable_NormalCheckBox(chkShowAll_Customers, false);
                }
            }

            flowLayoutCustomerDetailPanel.Visible = true;
            flowLayoutSupplierDetailPanel.Visible = false;
            clsCommon.SetVisibility_Panel(pnlTaxType, false);
        }

        #endregion

        #region Refresh Grid - Display Reports
        private void DisplayReports()
        {
            try
            {
                dgvReports.Rows.Clear();

                //Tax Reports
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
            clsSearch.Search_MasterCustomer(ref txtCustomer, chkShowAll_Customers.Checked);

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

                //        glb_dtsSales.dt_sasTaxDetails_Invoice.Adddt_sasTaxDetails_InvoiceRow(oInvoice.Invoice_ID, oInvoice.InvoiceDate, clsGenaralName.getName_Customer(oInvoice.Customer_ID), 
                //            clsGenaralName.getName_BranchCustomer(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID)), oInvoice.GrandTotal, oInvoice.GrandTotal,
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

        #region Print Method

 

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

        #region Print Method for Excel
        public void ExportToExcel(DataTable dt)
        {
            //Microsoft.Office.Interop.Excel.Application WsObj = new Microsoft.Office.Interop.Excel.Application();
            //WsObj.Application.Workbooks.Add(Type.Missing);
            //WsObj.Visible = false;
            //WsObj.Cells[1, 1] = "Created Date & Time : " + DateTime.Now.ToString();
            //WsObj.Range[WsObj.Cells[1, 1], WsObj.Cells[1, 5]].Merge();
            //try
            //{
            //    int row = 2; int col = 1;
            //    foreach (DataColumn column in dt.Columns)
            //    {
            //        WsObj.Cells[row, col] = column.ColumnName;
            //        WsObj.Cells[row, col].Borders.Color = System.Drawing.Color.Black;
            //        WsObj.Cells[row, col].Interior.Color = System.Drawing.Color.LightGray;
            //        col++;
            //    }

            //    col = 1;
            //    row++;
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        foreach (var cell in dt.Rows[i].ItemArray)
            //        {
            //            WsObj.Cells[row, col] = cell;
            //            WsObj.Cells[row, col].Borders.Color = System.Drawing.Color.Black;

            //            col++;
            //        }
            //        col = 1;
            //        row++;
            //    }

            //    WsObj.Columns.AutoFit();

            //    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            //    dlg.DefaultExt = ".xls";
            //    dlg.Filter = "Text documents (.xls)|*.xlsx";
            //    if (dlg.ShowDialog() == true)
            //    {
            //        string filename = dlg.FileName;
            //        WsObj.ActiveWorkbook.SaveCopyAs(filename);
            //        MessageBox.Show("Excel File is successfully created", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    WsObj.Visible = true;
            //}
            //catch (Exception ex)
            //{
            //    SEACCException.Show(ex);
            //    clsValidate.WriteErrorLog("ExportToExcel Method - Error", iFormID, ex);
            //}
            //finally
            //{
            //    //System.Runtime.InteropServices;
            //    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(WsObj);
            //}
        }
        #endregion

        #endregion

        #region Controls/Enable Disable
        private void setEnableDisableConctrol(int iReportID)
        {
            if (iReportID == (int)enum_ReportName.ST_Tax_Report_Invoice_ExportSVAT)
            {
                flowLayoutCustomerDetailPanel.Visible = true;
                flowLayoutSupplierDetailPanel.Visible = false;
                clsCommon.SetVisibility_Panel(pnlTaxType, true);

                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Tax_Report_Invoice_DetailLocalNBTVAT)
            {
                flowLayoutCustomerDetailPanel.Visible = true;
                flowLayoutSupplierDetailPanel.Visible = false;
                clsCommon.SetVisibility_Panel(pnlTaxType, true);

                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Tax_Report_Invoice_Detail)
            {
                flowLayoutCustomerDetailPanel.Visible = true;
                flowLayoutSupplierDetailPanel.Visible = false;
                clsCommon.SetVisibility_Panel(pnlTaxType, false);

                clsCommon.SetVisibility_Panel(pnlSalesman, false);
                clsCommon.SetVisibility_Panel(pnlRoute, false);
            }
            else if (iReportID == (int)enum_ReportName.ST_Tax_Report_CreditNote)
            {
                flowLayoutCustomerDetailPanel.Visible = true;
                flowLayoutSupplierDetailPanel.Visible = false;
                clsCommon.SetVisibility_Panel(pnlTaxType, true);

                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Tax_Report_Detail_CreditNote)
            {
                flowLayoutCustomerDetailPanel.Visible = true;
                flowLayoutSupplierDetailPanel.Visible = false;
                clsCommon.SetVisibility_Panel(pnlTaxType, false);

                clsCommon.SetVisibility_Panel(pnlSalesman, false);
                clsCommon.SetVisibility_Panel(pnlRoute, false);
            }
            else if (iReportID == (int)enum_ReportName.ST_Tax_Reports_VAT_Schedule01)
            {
                flowLayoutCustomerDetailPanel.Visible = true;
                flowLayoutSupplierDetailPanel.Visible = false;
                clsCommon.SetVisibility_Panel(pnlTaxType, false);

                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Tax_Reports_VAT_Schedule02)
            {
                flowLayoutCustomerDetailPanel.Visible = false;
                flowLayoutSupplierDetailPanel.Visible = true;
                clsCommon.SetVisibility_Panel(pnlTaxType, false);

                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
            }
            else if (iReportID == (int)enum_ReportName.ST_Tax_Reports_VAT_Schedule04)
            {
                flowLayoutCustomerDetailPanel.Visible = true;
                flowLayoutSupplierDetailPanel.Visible = false;
                clsCommon.SetVisibility_Panel(pnlTaxType, false);

                clsCommon.SetVisibility_Panel(pnlSalesman, true);
                clsCommon.SetVisibility_Panel(pnlRoute, true);
            }
        }
        #endregion
        #endregion
    }
}