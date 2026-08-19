
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
using Microsoft.Win32;
using CrystalDecisions.CrystalReports.Engine;
using Express.View.Domain.Invoice;
using FedexExpress.View.Domain.Pricing;

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
                ReportDocument invRpt = null;
                var repPara = _rptData.FirstOrDefault();
                if (repPara.DocType.Trim() == "XDTISH" || repPara.DocType.Trim() == "XDTISL")
                {
                    invRpt = _reportloc.InvoiceReporLocator("ddpdutyinv");
                }
                else
                {
                    invRpt = _reportloc.InvoiceReporLocator("dutyinv");
                }

                ////InvoiceTaxRpt invRpt = new InvoiceTaxRpt();
               /// var invRpt =  _reportloc.InvoiceReporLocator("dutyinv");
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

        public void ClearenceDutyPrintExport(IList<TaxInvoiceReportDomainView> _rptData, IList<CompanyReportDomainView> _company, string InvNo)
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
                string FilePath = "\\\\10.10.6.12\\Bayaans\\" + cusdecNo + ".pdf";
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
           
            try
            {
                var adobe = Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Microsoft").OpenSubKey("Windows").OpenSubKey("CurrentVersion").OpenSubKey("App Paths").OpenSubKey("AcroRd32.exe");
                var path = adobe.GetValue("");
                //var adobeOtherWay = Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Classes").OpenSubKey("acrobat").OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command");
                //var pathOtherWay = adobeOtherWay.GetValue("");

                //string ACRbatePath = System.Configuration.ConfigurationManager.AppSettings["pdfPath"];
                if (path != null)
                {
                    var process = new Process
                    {
                        StartInfo =
                {

                WindowStyle = ProcessWindowStyle.Hidden,
                Verb = "print",
                FileName=path.ToString(),
                //FileName = @"C:\Program Files (x86)\Adobe\Reader 11.0\Reader\AcroRd32.exe", //You could use an app config string here
                Arguments = $"/p /h {fileName}",

                UseShellExecute = false,
                CreateNoWindow = true
                }
                    };
                    process.Start();
                    if (process.HasExited == false)
                    {
                        process.WaitForExit(8000);

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
            }
            catch (Exception exx)
            {
                throw new Exception(exx.Message +
                                                   " Fail to Print Bayan ");
            }


        }

        public void PrintAirwabilDetail(IList<InvFrtPrintProcessDomainView> _pendingInv, InvFrtPrintProcessParaDomainView _para)
        {
            //GeReportStrategies(LoginInfoView.REPORTPATH);
            FrtPendingInvAwbDetail invRpt = new FrtPendingInvAwbDetail();
            //var invRpt = _reportloc.InvoiceReporLocator("dutyinv");
            Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
            Dictionary<string, string> Report_Para = new Dictionary<string, string>();
            var _repname = "Pending Invoice Airwaybill Detail";
            var _param = "Agency : "+ _para.AgencyN + " Up to date : " + _para.DteUpto +" Doc Type : "+_para.DocType ;
            if(_para.IsCutormer ==1)
            {
                _param = _param + " Customer Name : " + _para.OrgName;
            }


            Report_Para.Add("rptpara", _param);
            Report_Para.Add("rptname", _repname);
            Report_Data.Add("InvFrtPrintProcessDomainView", ReportContext.ToDataTable<InvFrtPrintProcessDomainView>(_pendingInv.ToList()));

            ReportContext.ShowReport("PENDING INVOICE AWB", invRpt, Report_Data, Report_Para);
        }

        public void PrintInvAirwabilDetail(IList<InvFrtPrintProcessDomainView> _pendingInv, InvFrtPrintProcessParaDomainView _para)
        {
            //GeReportStrategies(LoginInfoView.REPORTPATH);FrtPendingInvAwbDetail
            FrtInvoiceAwbDetail invRpt = new FrtInvoiceAwbDetail();
            //var invRpt = _reportloc.InvoiceReporLocator("dutyinv");
            Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
            Dictionary<string, string> Report_Para = new Dictionary<string, string>();
            var _repname = "Invoiced Airwaybill Detail";
            var _param = "Agency : " + _para.AgencyN + " / Doc Type : " + _para.DocType;
            if (_para.IsInvNumberRange  == 1)
            {
                _param = _param + " / Invoice From : " + _para.FromInvNo + " And Invoice To : "+ _para.ToInvNo;
            }

            if( _para.IsInvDateRange ==1)
            {
                _param = _param + " / Date From : " + _para.DtFrom + " And Date To : " + _para.DtTo;
            }

            if(_para.AllAwb ==1)
            {
                _param = _param + " / Airwabill no : " + _para.AwbNumber;
            }

            Report_Para.Add("rptname", _repname);
            Report_Para.Add("rptpara", _param);
            Report_Data.Add("InvFrtPrintProcessDomainView", ReportContext.ToDataTable<InvFrtPrintProcessDomainView>(_pendingInv.ToList()));

          if (_para.IsDirectPrint)
            {
                ReportContext.PrintReport("PENDING INVOICE AWB", invRpt, Report_Data, Report_Para);
            }
          else
            {
                ReportContext.ShowReport("PENDING INVOICE AWB", invRpt, Report_Data, Report_Para);
            }
           
        }

        public void PrintInvFrtDetailReport(IList<FrtInvoiceReportDomainView> _pendingInv, IList<CompanyReportDomainView> _company ,InvFrtPrintProcessParaDomainView _para)
        {
            
            try
            {
               // InvoiceFreightRpt invRpt = new InvoiceFreightRpt();
                //InvoiceSubCharges subRpt = new InvoiceSubCharges();
                GeReportStrategies(LoginInfoView.REPORTPATH);
                var invRpt = _reportloc.InvoiceReporLocator("FrtDetail");
                var subRpt = _reportloc.InvoiceReporLocator("FrtSubDetail");
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("FrtInvoiceReportDomainView", ReportContext.ToDataTable<FrtInvoiceReportDomainView>(_pendingInv.ToList()));
                Report_Data.Add("CompanyReportDomainView", ReportContext.ToDataTable<CompanyReportDomainView>(_company.ToList()));

                if (_para.IsDirectPrint)
                {
                    ReportContext.PrintReport("Freight Bulk Invoice", invRpt, Report_Data, null, ReportContext.SelectTray(_para.AgencyCode));
                }
                else
                {
                    ReportContext.ShowReport("Freight Bulk Invoice", invRpt, Report_Data, null);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void PrintInvFrtSummaryReport(IList<FrtInvoiceSummeryDomainView> _pendingInv, IList<CompanyReportDomainView> _company , InvFrtPrintProcessParaDomainView _para)
        {

            try
            {                
                GeReportStrategies(LoginInfoView.REPORTPATH);
                var invRpt = _reportloc.InvoiceReporLocator("FrtSummary");
                
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("FrtInvoiceSummeryDomainView", ReportContext.ToDataTable<FrtInvoiceSummeryDomainView>(_pendingInv.ToList()));
                Report_Data.Add("CompanyReportDomainView", ReportContext.ToDataTable<CompanyReportDomainView>(_company.ToList()));

                if (_para.IsDirectPrint)
                {
                    ReportContext.PrintReport("Freight Bulk Invoice", invRpt, Report_Data, null, ReportContext.SelectTray(_para.AgencyCode));
                }
                else
                {
                    ReportContext.ShowReport("Freight Bulk Invoice", invRpt, Report_Data, null);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InvDellInvoice_NotDelivered(IList<InvDellInvoiceReportDomainView> _rptData)
        {
            try
            {
                //GeReportStrategies("OMAN");
                //var invsummary = _reportloc.InqueryReportLocator("paysummery");
                InvDellInvoice_Not_Delivered notDelivered = new InvDellInvoice_Not_Delivered();
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("InvDellInvoiceReportDomainView", ReportContext.ToDataTable<InvDellInvoiceReportDomainView>(_rptData.ToList()));
                ReportContext.ShowReport("Not Delivered", notDelivered, Report_Data, null);

            }
            catch (Exception)
            {

            }
        }

        public void InvDellInvoice_PendingDelivered(IList<InvDellInvoiceReportDomainView> _rptData)
        {
            try
            {
                //GeReportStrategies("OMAN");
                //var invsummary = _reportloc.InqueryReportLocator("paysummery");
                InvDellInvoice_PendingDelivered pendingDelivered = new InvDellInvoice_PendingDelivered();
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("InvDellInvoiceReportDomainView", ReportContext.ToDataTable<InvDellInvoiceReportDomainView>(_rptData.ToList()));
                ReportContext.ShowReport("Pending Delivered", pendingDelivered, Report_Data, null);

            }
            catch (Exception)
            {

            }
        }

        public void InvDellInvoice_NotInvoiced(IList<InvDellInvoiceReportDomainView> _rptData)
        {
            try
            {
                //GeReportStrategies("OMAN");
                //var invsummary = _reportloc.InqueryReportLocator("paysummery");
                InvDellInvoiceNotInvoiced pendingDelivered = new InvDellInvoiceNotInvoiced();
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("InvDellInvoiceReportDomainView", ReportContext.ToDataTable<InvDellInvoiceReportDomainView>(_rptData.ToList()));
                ReportContext.ShowReport("Not Invoiced", pendingDelivered, Report_Data, null);

            }
            catch (Exception)
            {

            }
        }

        public void InvDellInvoice_InvoiceSummery(IList<InvoiceDeliverySummaryDomainView> _rptData)
        {
            try
            {
                InvoiceDeliverySummery pendingDelivered = new InvoiceDeliverySummery();
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("InvoiceDeliverySummaryDomainView", ReportContext.ToDataTable<InvoiceDeliverySummaryDomainView>(_rptData.ToList()));
                ReportContext.ShowReport("Invoice Summery", pendingDelivered, Report_Data, null);

            }
            catch (Exception)
            {

            }
        }

        public void InvDellInvoice_InvoiceDeliveryDeatil(IList<InvoiceDeliveryDetailDomainView> _rptData)
        {
            try
            {
                InvoiceDeliveryDetail pendingDelivered = new InvoiceDeliveryDetail();
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("InvoiceDeliveryDetailDomainView", ReportContext.ToDataTable<InvoiceDeliveryDetailDomainView>(_rptData.ToList()));
                ReportContext.ShowReport("Invoice Delivery Detail", pendingDelivered, Report_Data, null);

            }
            catch (Exception)
            {

            }
        }

        public void GetRptPickupBillingPending(InvPickProcessPramDomainView _para, IList<InvoicePickupRptDomainView> _billing)
        {
            try
            {
                //GeReportStrategies("OMAN");
                //var invsummary = _reportloc.InqueryReportLocator("paysummery");
                InvoicePickupBillingPending _billpending = new InvoicePickupBillingPending();
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("InvoicePickupRptDomainView", ReportContext.ToDataTable<InvoicePickupRptDomainView>(_billing.ToList()));
                ReportContext.ShowReport("Pending billing - Pickup", _billpending, Report_Data, null);

            }
            catch (Exception)
            {

            }
        }

        public void GetRptPickupInvoicePending(InvPickProcessPramDomainView _para, IList<InvoicePickupRptDomainView> _invoicing)
        {
            try
            {
                //GeReportStrategies("OMAN");
                //var invsummary = _reportloc.InqueryReportLocator("paysummery");
                InvoicePickupInvoicePending _invoicepending = new InvoicePickupInvoicePending();
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("InvoicePickupRptDomainView", ReportContext.ToDataTable<InvoicePickupRptDomainView>(_invoicing.ToList()));
                ReportContext.ShowReport("Pending Invoice - Pickup", _invoicepending, Report_Data, null);

            }
            catch (Exception)
            {

            }
        }

        public void GetRptPickupSummary(InvPickProcessPramDomainView _para, IList<InvoicePickupRepSummeryDomainView> _invsummery, IList<CompanyReportDomainView> _company)
        {
            try
            {
                InvoicePickupSummery _invsummary = new InvoicePickupSummery();
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("InvoicePickupRepSummeryDomainView", ReportContext.ToDataTable<InvoicePickupRepSummeryDomainView>(_invsummery.ToList()));
                Report_Data.Add("CompanyReportDomainView", ReportContext.ToDataTable<CompanyReportDomainView>(_company.ToList()));
                ReportContext.ShowReport("PickUp summery", _invsummary, Report_Data, null);

            }
            catch (Exception)
            {

            }
        }

        public void GetRptPickupDetail(InvPickProcessPramDomainView _para, IList<InvoicePickupRepDetailDomainView> _invdetail, IList<CompanyReportDomainView> _company)
        {
            try
            {
                InvoicePickupDetail _invoicedetails = new InvoicePickupDetail();
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("InvoicePickupRepDetailDomainView", ReportContext.ToDataTable<InvoicePickupRepDetailDomainView>(_invdetail.ToList()));
                Report_Data.Add("CompanyReportDomainView", ReportContext.ToDataTable<CompanyReportDomainView>(_company.ToList()));
                ReportContext.ShowReport("PickUp Details", _invoicedetails, Report_Data, null);

            }
            catch (Exception)
            {

            }
        }
    }
}
