using Express.Interfaces.Report.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.Pricing;
using System.Data;
using Express.Report.Pricing.Report;

namespace Express.Report.Pricing.ReportProxy
{
    public class PricingReports : IPricingReport
    {

        private readonly IPricingReport _pricingRpt;

        public PricingReports()
        {
            if (_pricingRpt == null)
            {
                // _operationRpt = RptOperationUIFactory
            }
        }

        public void PreviewAWBCreditNote(List<AWBCreditView> previewList)
        {
            try
            {

                RptAWBCreditNoteNo creditNote = new RptAWBCreditNoteNo();

                Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
                //  Dictionary<string, string> Report_Para = new Dictionary<string, string>();
                //  Report_Para.Add("searchText", _searchStr);
                Report_Data.Add("AWBCreditView", ReportContext.ToDataTable<AWBCreditView>(previewList.ToList()));

                ReportContext.ShowReport("Credit Note Report", creditNote, Report_Data, null);

            }
            catch (Exception)
            {

            }

        }

        public void PreviewAWBCreditNote(IList<AWBCreditView> _para)
        {
            throw new NotImplementedException();
            //try
            //{

            //    RptAWBCreditNoteNo creditNote = new RptAWBCreditNoteNo();

            //    Dictionary<string, DataTable> Report_Data = new Dictionary<string, DataTable>();
            //    //  Dictionary<string, string> Report_Para = new Dictionary<string, string>();
            //    //  Report_Para.Add("searchText", _searchStr);
            //    Report_Data.Add("AWBCreditView", ReportContext.ToDataTable<AWBCreditView>(_para.ToList()));

            //    ReportContext.ShowReport("Credit Note Report", creditNote, Report_Data, null);

            //}
            //catch (Exception)
            //{

            //}

        }

        public void PrintFedexReconcile(PrincipleReconDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public void PrintFedexReconcileSummery(PrincipleReconDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public void PrintTnTReconcile(PrincipleReconDomainView typePara)
        {
            throw new NotImplementedException();
        }
    }
}
