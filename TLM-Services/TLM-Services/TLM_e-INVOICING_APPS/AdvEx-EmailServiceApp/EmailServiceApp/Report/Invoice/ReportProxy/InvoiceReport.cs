using EmailServiceApp.Domain;
using EmailServiceApp.Report.Invoice.Report.MHE;

using FedexExpress.View.Domain.Report.Invoice;
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
      //  private readonly IInvoiceReportSelector  repDataProvider;
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
            //_strategies.Add("KSA", new InvoiceKsaReport());/// Portal 
            //_strategies.Add("OMAN", new InvoiceOmnReport());/// Express module               
            _strategies.Add("MHE", new InvoiceMheReport());/// Express module   
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

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        //public void PrintTaxInvoiceForEmail(int groupID, int companyID, int agencyID, string invoicNo, bool isDirect)
        //{
            

        //}

        public bool MHEInvoiceTax(IList<TaxInvoiceReportDomainView> _rptData, IList<CompanyReportDomainView> _company, string Invo,string Path)
        {
            try
            {
                GeReportStrategies(Path);
                //int groupID = _company.First().GroupID;

                //int companyID = _company.First().CompanyID;
                //int agencyID = 20102;

                string invoicNo = _rptData.First().InvNo;
                // = , 
                //PrintTaxInvoiceForEmail(groupID, companyID, agencyID, invoicNo, true, _company, _rptData);

                InvoiceTaxRpt invRpt = new InvoiceTaxRpt();
                try
                {
                    //GeReportStrategies(Path);
                    //GeReportStrategies(Path);
                   // var repTaxInv = _reportloc.GetInvTaxRep(groupID, companyID, agencyID, invoicNo);
                    Dictionary<string, string> Report_Para = new Dictionary<string, string>();

                    Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                    Report_Data.Add("TaxInvoiceReportDomainView", ReportContext.ToDataTable<TaxInvoiceReportDomainView>(_rptData.ToList()));
                    Report_Data.Add("CompanyReportDomainView", ReportContext.ToDataTable<CompanyReportDomainView>(_company.ToList()));
                   

                    ReportContext.MHEReport("Invoice Tax", invRpt, Report_Data, null, invoicNo);
                    System.Threading.Thread.Sleep(3000);

                }
                catch (Exception ex)
                {
                    throw;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void PrintTaxInvoiceForEmail(int groupID, int companyID, int agencyID, string invoicNo, bool v, IList<CompanyReportDomainView> _company, IList<TaxInvoiceReportDomainView> _rptData)
        {
            
        }


        public bool MHEInvoiceFreight(IList<FrtInvoiceReportDomainView> _rptData, IList<CompanyReportDomainView> _company, string Invo, string Path)
        {
            try
            {
                GeReportStrategies(Path);
               
                string invoicNo = _rptData.First().InvNo;
                //string awb = _rptData.First().AgnAWBNo;

                
             //  InvoiceFreightWPFRpt invRpt = new InvoiceFreightWPFRpt();
                InvoiceFreightRpt2 invRpt = new InvoiceFreightRpt2();

                try
                {
                    //GeReportStrategies(Path);
                    //GeReportStrategies(Path);
                //    var repTaxInv = _reportloc.GetInvTaxRep(groupID, companyID, agencyID, invoicNo);
                    Dictionary<string, string> Report_Para = new Dictionary<string, string>();

                    Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                    Report_Data.Add("FrtInvoiceReportDomainView", ReportContext.ToDataTable<FrtInvoiceReportDomainView>(_rptData.ToList()));
                    //Report_Data.Add("CompanyReportDomainView", ReportContext.ToDataTable<CompanyReportDomainView>(_company.ToList()));
                    Report_Para.Add("CompanyN", _company.FirstOrDefault().CompanyName);
                    ReportContext.MHEReport("Feight Invoice", invRpt, Report_Data, Report_Para, invoicNo);
                    System.Threading.Thread.Sleep(3000);
                }
                catch (Exception ex)
                {
                    throw;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool MHEInvoiceFreightSummery(IList<FrtInvoiceSummeryDomainView> _rptData, IList<CompanyReportDomainView> _company, string Invo, string Path)
        {
            try
            {
                GeReportStrategies(Path);
                //int groupID = _company.First().GroupID;
                //int companyID = _company.First().CompanyID;
                //int agencyID = 20102;
                string invoicNo = _rptData.First().InvNo;
                //string awb = _rptData.First().AgnAWBNo;

                //PrintFrtInvoiceForEmail(groupID, companyID, agencyID, invoicNo, awb, _rptData, _company);
                InvoiceFreightSummeryRpt invRpt = new InvoiceFreightSummeryRpt();
                try
                {
                    //GeReportStrategies(Path);
                    //GeReportStrategies(Path);
                    //    var repTaxInv = _reportloc.GetInvTaxRep(groupID, companyID, agencyID, invoicNo);
                    Dictionary<string, string> Report_Para = new Dictionary<string, string>();

                    Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                    Report_Data.Add("FrtInvoiceSummeryDomainView", ReportContext.ToDataTable<FrtInvoiceSummeryDomainView>(_rptData.ToList()));
                    Report_Data.Add("CompanyReportDomainView", ReportContext.ToDataTable<CompanyReportDomainView>(_company.ToList()));
                    ReportContext.MHEReport("Feight Invoice", invRpt, Report_Data, null, invoicNo);
                    System.Threading.Thread.Sleep(3000);
                }
                catch (Exception ex)
                {
                    throw;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool MHEInvoiceAwb(IList<InvoiceRepAwbDetailDomainView> _rptData, IList<CompanyReportDomainView> _company, string Invo, string Path)
        {            
                GeReportStrategies(Path);

                InvoiceAwbDetail invRpt = new InvoiceAwbDetail();
                try
                {
                    Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                    Report_Data.Add("InvoiceRepAwbDetailDomainView", ReportContext.ToDataTable<InvoiceRepAwbDetailDomainView>(_rptData.ToList()));
                    Report_Data.Add("CompanyReportDomainView", ReportContext.ToDataTable<CompanyReportDomainView>(_company.ToList()));
                    ReportContext.PrintReport("AWB Invoice", invRpt, Report_Data, null, Invo);
                System.Threading.Thread.Sleep(3000);
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
