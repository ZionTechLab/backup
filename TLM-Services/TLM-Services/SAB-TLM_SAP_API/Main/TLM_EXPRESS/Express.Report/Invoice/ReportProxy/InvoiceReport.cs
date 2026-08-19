
using Express.Interfaces.Report.Invoice;
using Express.Report.Invoice.Report;


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.Report.Invoice;
using Express.View.Domain.Report.General;
using Express.Report.Invoice.Report.KSA;
using Express.Report.Invoice.Report.OMAN;
using Express.View.Domain.Login;
using System.IO;
using System.Diagnostics;
//using AxAcroPDFLib;

namespace Express.Report.Invoice.ReportProxy
{
    public class InvoiceReport : IInvoiceReportProvider
    {
        // PricingReport : IInvoiceReport

        private static Dictionary<string, IInvoiceReportSelector> _strategies;
        private IInvoiceReportSelector _reportloc;
        public InvoiceReport()
        {
            if(_strategies==null)
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
        }

        public void GeReportStrategies(string _key)
        {
            _reportloc = _strategies[_key];
        }
        #endregion

        public void ClearenceDutyPrint(IList<TaxInvoiceReportDomainView> _rptData , IList<CompanyReportDomainView> _company)
        {
            try
            {
                GeReportStrategies(LoginInfoView.REPORTPATH);
                ////InvoiceTaxRpt invRpt = new InvoiceTaxRpt();
                var invRpt =  _reportloc.InvoiceReporLocator("dutyinv");
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("TaxInvoiceReportDomainView", ReportContext.ToDataTable<TaxInvoiceReportDomainView>(_rptData.ToList()));
                Report_Data.Add("CompanyReportDomainView", ReportContext.ToDataTable<CompanyReportDomainView>(_company.ToList()));
                ReportContext.ShowReport("VAT INVOICE", invRpt, Report_Data, null);

            }
            catch (Exception)
            {

            }
        }
        public void ClearenceSummaryDutyPrint(IList<TaxInvoiceSummeryDomainView> _rptData, string rptPara)
        {
            try
            {
               
                InvoiceTaxSummary invRpt = new InvoiceTaxSummary();           
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Dictionary<string, string> Report_Para = new Dictionary<string, string>();
                Report_Para.Add("ReportPara", rptPara);
                Report_Data.Add("TaxInvoiceSummeryDomainView", ReportContext.ToDataTable<TaxInvoiceSummeryDomainView>(_rptData.ToList()));
               
                ReportContext.ShowReport("VAT SUMMERY INVOICE", invRpt, Report_Data, Report_Para);

            }
            catch (Exception)
            {

            }
        }

        public void ClearenceDutyPrintExport(IList<TaxInvoiceReportDomainView> _rptData, IList<CompanyReportDomainView> _company,string InvNo)
        {
            try
            {
                GeReportStrategies(LoginInfoView.REPORTPATH);
                ////InvoiceTaxRpt invRpt = new InvoiceTaxRpt();
                var invRpt = _reportloc.InvoiceReporLocator("dutyinv");
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("TaxInvoiceReportDomainView", ReportContext.ToDataTable<TaxInvoiceReportDomainView>(_rptData.ToList()));
                Report_Data.Add("CompanyReportDomainView", ReportContext.ToDataTable<CompanyReportDomainView>(_company.ToList()));
                ReportContext.ExportDutyReport("VAT INVOICE", invRpt, Report_Data, null, InvNo);
            }
            catch (Exception)
            {

            }


        }

        public void ClearenceDutyPrintDirect(IList<TaxInvoiceReportDomainView> _rptData, IList<CompanyReportDomainView> _company)
        {
            try
            {
                    GeReportStrategies(LoginInfoView.REPORTPATH);
                    var invRpt = _reportloc.InvoiceReporLocator("dutyinv");
                    Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                    Report_Data.Add("TaxInvoiceReportDomainView", ReportContext.ToDataTable<TaxInvoiceReportDomainView>(_rptData.ToList()));
                    Report_Data.Add("CompanyReportDomainView", ReportContext.ToDataTable<CompanyReportDomainView>(_company.ToList()));
                    string cusdecNo = _rptData.First().CusdecNo;
                    string FilePath = @"C:\TLM\Bayan\" + cusdecNo + ".pdf";
                    if (File.Exists(FilePath))
                    {
                        PrintDocument(FilePath);
                    }
                    ReportContext.PrintReport("VAT INVOICE", invRpt, Report_Data, null);
            }
            catch (Exception ex)
            {

            }
        }
       
        private void PrintFormPdfData(string formPdfPath)
        {
           
        }

        private void PrintDocument(string fileName)
        {
            var process = new Process
            {
                StartInfo =
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                Verb = "print",
                FileName = @"C:\Program Files (x86)\Adobe\Reader 11.0\Reader\AcroRd32.exe", //You could use an app config string here
                Arguments = $@"/p /h {fileName}",

                UseShellExecute = false,
                CreateNoWindow = true
            }
            };
            process.Start();
            if (process.HasExited == false)
            {
                process.WaitForExit(3500);
            }
            process.EnableRaisingEvents = true;
            try
            {
                //Try to gracefully exit the process first
                var proccessIsClosed = process.CloseMainWindow();
                //If it doesn't gracefully close, kill the process
                if (!proccessIsClosed)
                {
                    process.Kill();
                }
            }
            catch
            {
                throw new Exception("Process ID " + process.Id +
                                               " is unable to gracefully close. Please check current running processes.");
            }
        }




        //string tempFile;
        //tempFile = Path.GetTempFileName();
        //using (FileStream fs = new FileStream(tempFile, FileMode.Create))
        //{
        //    fs.Write(formPdfData, 0, formPdfData.Length);
        //    fs.Flush();
        //}
        //try
        //{
        //    string gsArguments;
        //    string gsLocation;
        //    ProcessStartInfo gsProcessInfo;
        //    Process gsProcess;
        //    gsArguments = string.Format("-grey -noquery -printer \"HP LaserJet 5M\" \"{0}\"", tempFile);
        //    gsLocation = @"C:\Program Files\Ghostgum\gsview\gsprint.exe";
        //    gsProcessInfo = new ProcessStartInfo();
        //    gsProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
        //    gsProcessInfo.FileName = gsLocation;
        //    gsProcessInfo.Arguments = gsArguments;
        //    gsProcess = Process.Start(gsProcessInfo);
        //    gsProcess.WaitForExit();
        //}
        //finally
        //{
        //    File.Delete(tempFile);
        //}
        //}
    }
}
