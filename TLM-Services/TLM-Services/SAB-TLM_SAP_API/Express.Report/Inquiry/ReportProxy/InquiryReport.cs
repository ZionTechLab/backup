using Express.Interfaces.Report.Inquiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.Inquiry;
using Express.Report.Inquiry.Report;
using System.Data;
using Express.Report.Inquiry.Report.OMAN;
using Express.Report.Inquiry.Report.KSA;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;

namespace Express.Report.Inquiry.ReportProxy
{
    public class InquiryReport : IInquiryReportProvider
    {
        private static Dictionary<string, IInqueryReportSelector> _strategies;
        private IInqueryReportSelector _reportloc;
        public InquiryReport()
        {
            if (_strategies == null)
            {
                _strategies = new Dictionary<string, IInqueryReportSelector>();
            }
            SetStrategies();
        }

        #region  strategies
        public void SetStrategies()
        {
            _strategies.Add("KSA", new InqueryKsaReport());/// Portal 
            _strategies.Add("OMAN", new InqueryOmanReport());/// Express module        
        }

        public void GeReportStrategies(string _key)
        {
            _reportloc = _strategies[_key];
        }
        #endregion
        public void InvoiceSummaryPrint(IList<InvoiceSummaryDomainView> _rptData)
        {
            try
            {
                GeReportStrategies(LoginInfoView.REPORTPATH);
                var invsummary = _reportloc.InqueryReportLocator("invsummery");

               /// InvoiceSummaryReport invsummary = new InvoiceSummaryReport();
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("InvoiceSummaryDomainView", ReportContext.ToDataTable<InvoiceSummaryDomainView>(_rptData.ToList()));
                ReportContext.ShowReport("Invoice Summary", invsummary, Report_Data, null);

            }
            catch (Exception)
            {

            }
        }

        public void ClearanceAnalysisPrint(IList<ClearanceAnalysisDomainView> _rptData)
        {
            try
            {
                ////GeReportStrategies("OMAN");
                ////var clranalsis = _reportloc.InqueryReportLocator("clearanlysis");
                ClearanceAnalysisReport clearanceAnalysis = new ClearanceAnalysisReport();
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("ClearanceAnalysisDomainView", ReportContext.ToDataTable<ClearanceAnalysisDomainView>(_rptData.ToList()));
                ReportContext.ShowReport("Clearance Analysis Report ", clearanceAnalysis, Report_Data, null);

            }
            catch (Exception)
            {

            }
        }

        public void NotInvoiceSummaryPrint(IList<NotInvoiceReportDomainView> _rptData)
        {
            try
            {
                //GeReportStrategies("OMAN");
                //var invsummary = _reportloc.InqueryReportLocator("paysummery");
                NotInvoiceSummaryReport invsummary = new NotInvoiceSummaryReport();
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("NotInvoiceReportDomainView", ReportContext.ToDataTable<NotInvoiceReportDomainView>(_rptData.ToList()));
                ReportContext.ShowReport("Not Invoice Summary", invsummary, Report_Data, null);

            }
            catch (Exception)
            {

            }
        }

        public void PaymentSummaryPrint(IList<PaymetSummaryDomainView> _rptData)
        {
            try
            {
                GeReportStrategies(LoginInfoView.REPORTPATH );
                var invsummary = _reportloc.InqueryReportLocator("paysummery");
                //PaymetSummaryReport invsummary = new PaymetSummaryReport();
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("PaymetSummaryReport", ReportContext.ToDataTable<PaymetSummaryDomainView>(_rptData.ToList()));
                ReportContext.ShowReport("Paymet Summary", invsummary, Report_Data, null);

            }
            catch (Exception)
            {

            }
        }
        public void DutyOutStandingPrint(IList<DutyOutstandingViewModel> _rptData)
        {
            try
            {
                //GeReportStrategies("OMAN");
                //var invsummary = _reportloc.InqueryReportLocator("paysummery");
                DutyOutStanding invsummary = new DutyOutStanding();
                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Report_Data.Add("DutyOutstandingViewModel", ReportContext.ToDataTable<DutyOutstandingViewModel>(_rptData.ToList()));
                ReportContext.ShowReport("Not Invoice Summary", invsummary, Report_Data, null);

            }
            catch (Exception)
            {

            }
        }
        //public void PrintShipmentHeldSammery(IList<InqShipmetHeldDomainView> _rptData, InqShipmentHeldPara para)
        //{
        //    try
        //    {
        //        string _searchStr = "";
        //        _searchStr = "Up to date : " + para.Uptodate.ToString("dd-MMM-yyyy") + " , " +
        //            "Gateway : " +  ((para.GatewayID.Trim() =="")? "ALL" : para.GatewayN.Trim()) + " ,"+
        //            " Station : " + ((para.StationID.Trim()=="")? "ALL" : para.StationN);
        //        InqShipHeldSummary  invRpt = new InqShipHeldSummary();
        //        Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
        //        Dictionary<string, string> Report_Para = new Dictionary<string, string>();
        //        Report_Para.Add("searchText", _searchStr);
        //        Report_Para.Add("CompanyN", para.CompanyN);
        //        Report_Para.Add("AgencyN", para.AgencyN );

        //        Report_Data.Add("InqShipmetHeldDomainView", ReportContext.ToDataTable<InqShipmetHeldDomainView>(_rptData.ToList()));

        //        ReportContext.ShowReport("Shipment Held Summary", invRpt, Report_Data, Report_Para);

        //    }
        //    catch (Exception)
        //    {

        //    }
        //}
    }
}
