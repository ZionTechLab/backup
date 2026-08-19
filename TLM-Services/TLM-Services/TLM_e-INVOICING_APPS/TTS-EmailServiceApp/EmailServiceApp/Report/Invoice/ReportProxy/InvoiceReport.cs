using EmailServiceApp.Domain;
using EmailServiceApp.Report.Invoice.Report.KSA;
using EmailServiceApp.Report.Invoice.Report.OMAN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServiceApp.Report.Invoice.ReportProxy
{
    public class InvoiceReport 
    {
        // PricingReport : IInvoiceReport

        private static Dictionary<string, IInvoiceReportSelector> _strategies;
        private IInvoiceReportSelector _reportloc;
        public InvoiceReport()
        {
            if (_strategies == null)
            {
                _strategies = new Dictionary<string, IInvoiceReportSelector>();
            }
            SetStrategies();
        }
        #region  strategies
        public void SetStrategies()
        {
            _strategies.Add("KSA", new InvoiceKsaReport());/// Portal 
            _strategies.Add("OMAN", new InvoiceOmnReport());/// Express module        
            _strategies.Add("MALE", new InvoiceMaleReport());
        }

        public void GeReportStrategies(string _key)
        {
            _reportloc = _strategies[_key];
        }
        #endregion

        public void ClearenceDutyPrint(IList<TaxInvoiceReportDomainView> _rptData, IList<CompanyReportDomainView> _company,string Path)
        {
            try
            {
                GeReportStrategies(Path);
                ////InvoiceTaxRpt invRpt = new InvoiceTaxRpt();
                var invRpt = _reportloc.InvoiceReporLocator("dutyinv");
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("TaxInvoiceReportDomainView", ReportContext.ToDataTable<TaxInvoiceReportDomainView>(_rptData.ToList()));
                Report_Data.Add("CompanyReportDomainView", ReportContext.ToDataTable<CompanyReportDomainView>(_company.ToList()));
                ReportContext.ShowReport("VAT INVOICE", invRpt, Report_Data, null);

            }
            catch (Exception)
            {

            }
        }
       
        public bool ClearenceDutyPrintExport(IList<TaxInvoiceReportDomainView> _rptData, IList<CompanyReportDomainView> _company, string InvNo, string Path)
        {
            try
            {
                GeReportStrategies(Path);
                ////InvoiceTaxRpt invRpt = new InvoiceTaxRpt();
                var invRpt = _reportloc.InvoiceReporLocator("dutyinv");
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("TaxInvoiceReportDomainView", ReportContext.ToDataTable<TaxInvoiceReportDomainView>(_rptData.ToList()));
                Report_Data.Add("CompanyReportDomainView", ReportContext.ToDataTable<CompanyReportDomainView>(_company.ToList()));
                ReportContext.ExportDutyReport("VAT INVOICE", invRpt, Report_Data, null, InvNo);
                //ReportContext.ExportDutyReportb("VAT INVOICE", invRpt, Report_Data, null, InvNo);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool ClearenceFrtPrintExport(IList<FrtInvoiceReportDomainView> _rptData, IList<CompanyReportDomainView> _company, string InvNo, string Path)
        {
            try
            {
                GeReportStrategies(Path);
                var invRpt = _reportloc.InvoiceReporLocator("frtinv");
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("FrtInvoiceReportDomainView", ReportContext.ToDataTable<FrtInvoiceReportDomainView>(_rptData.ToList()));
                Report_Data.Add("CompanyReportDomainView", ReportContext.ToDataTable<CompanyReportDomainView>(_company.ToList()));
                ReportContext.ExportFrtReport("Freight Bulk Invoice", invRpt, Report_Data, null, InvNo);
                //ReportContext.ExportFrtReportb("Freight Bulk Invoice", invRpt, Report_Data, null, InvNo);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }



        private void PrintFormPdfData(string formPdfPath)
        {

        }

     

    }
}
