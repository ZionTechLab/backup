
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Express.Interfaces.Report.Operation;
using Express.View.Domain.Report.Operation;
using Express.Report.Operation.Report;

namespace Express.Report.Operation.ReportProxy
{
    public class OperationReports : IOperationReportProvider
    {
        private readonly IOperationReportProvider _operationRpt;

        public OperationReports()
        {
            if(_operationRpt==null )
            {
               // _operationRpt = RptOperationUIFactory
            }
        }


        //private IAirlineChargeRptDataProvider<AirlineChargeRptDomainView> airChartRpt;
        //private IPodScans podScann;
        //public void PrintAirlineCharge(AirlineChargeRptParaDomainView para)
        //{


        //    AirlineCharges invRpt = new AirlineCharges();
        //    try
        //    {

        //        if (airChartRpt == null)
        //        {
        //           // airChartRpt = new AirlineChargeRptApiClient();
        //        }
        //        var repTaxInv = airChartRpt.GetRptAirlineCharge(para);
        //        var airName = (para.AirLineName == null) ? "" : para.AirLineName;
        //        Dictionary<string, string> Report_Para = new Dictionary<string, string>();
        //        Report_Para.Add("DateFrom", para.TrDateF.Date.ToString());
        //        Report_Para.Add("DateTo", para.TrDateT.Date.ToString());
        //        Report_Para.Add("Airline", (para.IsAllAirCode == 0) ? "ALL" : airName);

        //        Report_Para.Add("FromHub", (para.IsAllHubs == 0) ? "ALL" : para.FHubID);
        //        Report_Para.Add("ToHub", (para.IsAllHubs == 0) ? "ALL" : para.THubID);

        //        Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
        //        Report_Data.Add("AirlineChargeRptDomainView", ReportContext.ToDataTable<AirlineChargeRptDomainView>(repTaxInv.ToList()));
        //        Report_Data.Add("CompanyReportDomainView", ReportContext.ToDataTable<CompanyReportDomainView>(ReportGeneral.Instance.GetCompany(para.GroupID, para.CompanyID).ToList()));

        //        if (para.IsDirect)
        //        {
        //            ReportContext.PrintReport("Air Line Charge", invRpt, Report_Data, Report_Para, ReportContext.SelectTray(para.AgencyCode));
        //        }
        //        else
        //        {
        //            ReportContext.ShowReport("Air Line Charge", invRpt, Report_Data, Report_Para);
        //        }


        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }


        //}

        //public void PrintPodScan(PodScanParaDomainView para)
        //{
        //    PodScanReport invRpt = new PodScanReport();
        //    try
        //    {
        //        if (podScann == null)
        //        {
        //           // podScann = new PodScanRestClient();
        //        }
        //        var repTaxInv = podScann.GetPodScanReport(para);

        //        Dictionary<string, string> Report_Para = new Dictionary<string, string>();

        //        var _stype = "";
        //        if (para.ShipType == "I")
        //        {
        //            _stype = "Inbound";
        //        }
        //        else if (para.ShipType == "O")
        //        {
        //            _stype = "Outbound";
        //        }
        //        else
        //        {
        //            _stype = "Transhipment";
        //        }

        //        var _searchPara = "";
        //        _searchPara = "Shipment Type: " + _stype + " Date From : " + para.FromDate.ToString("MMMM dd yyyy") + " To : " + para.ToDate.ToString("MMMM dd yyyy");

        //        if ((para.ConsNo != null) && (para.ConsNo != ""))
        //        {
        //            _searchPara = _searchPara + " Cons ID : " + para.ConsNo;
        //        }

        //        if ((para.CustName != null) && (para.CustName != ""))
        //        {
        //            _searchPara = _searchPara + " Customer : " + para.CustName;
        //        }


        //        Report_Para.Add("reportPara", _searchPara);

        //        Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
        //        Report_Data.Add("PodScanRptDomainView", ReportContext.ToDataTable<PodScanRptDomainView>(repTaxInv.ToList()));


        //        ReportContext.ShowReport("POD Scan Sheet", invRpt, Report_Data, Report_Para);




        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
        public void GetManiferReport(IList<RptManifestDomainView> _para , string _searchStr)
        {
            try
            {
                
                RptManifest invRpt = new RptManifest();              

                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Dictionary<string, string> Report_Para = new Dictionary<string, string>();
                Report_Para.Add("searchText", _searchStr);
                Report_Data.Add("RptManifestDomainView", ReportContext.ToDataTable<RptManifestDomainView>(_para.ToList()));
               
                ReportContext.ShowReport("Manifest Report", invRpt, Report_Data, Report_Para);

            }
            catch (Exception)
            {

            }
        }

        public void GetPreManifestReport(IList<RptPreManifestDomainView> _para, string _searchStr)
        {
            try
            {
                RptPreManifest  invRpt = new RptPreManifest();

                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                Dictionary<string, string> Report_Para = new Dictionary<string, string>();
                Report_Para.Add("SearchText", _searchStr);
                Report_Data.Add("RptPreManifestDomainView", ReportContext.ToDataTable<RptPreManifestDomainView>(_para.ToList()));
                ReportContext.ShowReport("Pre Clearence Manifest Report", invRpt, Report_Data, Report_Para);

            }
            catch (Exception)
            {

            }
        }
    }
}
