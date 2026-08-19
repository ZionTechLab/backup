
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Login;
using Express.View.Domain.Report.Invoice;
using Express.Interfaces.Invoice;
using Express.View.Domain.Invoice;
using Express.View.Domain.Operations.Manifest;

namespace Express.Business.Invoice
{
    public class ClrInvPrintingBusiness : IClrInvPrinting
    {
        private readonly IClrInvPrinting _clearencePrint;

        public ClrInvPrintingBusiness(IClrInvPrinting _clearencePrint)
        {
            this._clearencePrint = _clearencePrint;
        }

       
        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return _clearencePrint.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public IList<ClrInvDocTypesDomainView> GetCfgDoctypes(int CMPY, int AgncyCode)
        {
            return _clearencePrint.GetCfgDoctypes(CMPY, AgncyCode);
        }

        ////public IList<CfgDtaxDocTypesDomainView> GetCfgDtaxDocTypes()
        ////{
        ////    return ClearanceInvoicesPrintingData.GetCfgDtaxDocTypes();
        ////}

        public IList<TaxInvoiceReportDomainView> GetClearenceDutyPrint(InvoiceDutyClearencePara _param)
        {
            return _clearencePrint.GetClearenceDutyPrint(_param);
        }

        public IList<GatewayDomainView> GetGateways(string CountryID)
        {
            return _clearencePrint.GetGateways(CountryID);
        }

        //public ClrInvDetorDomainView GetInvoiceAmount(decimal DocNo)
        //{
        //    return ClearanceInvoicesPrintingData.GetInvoiceAmount(DocNo);
        //}

        ////public IList<ClrInvDomainView> GetInvoiceDTAX_InvoiceNoRange(string AgncyID, int From, int To)
        ////{
        ////    return _clearencePrint.GetInvoiceDTAX_InvoiceNoRange(AgncyID, From, To);
        ////}

        public IList<ClrInvDomainView> GetClearenceInvoices(ClrInvParamDomainView _param)
        {
            return _clearencePrint.GetClearenceInvoices(_param);
        }

        public IList<OpsConsMasterDomainView> GetOpsConsMaster(string AgncyID, int CMPY)
        {
            return _clearencePrint.GetOpsConsMaster(AgncyID, CMPY);
        }

        public IList<RefLocationsDomainView> GetRefLocationsStations()
        {
            return _clearencePrint.GetRefLocationsStations();
        }

        public IList<RefSvcRootsDomainView> GetRefSvcRoots(int CMPY)
        {
            return _clearencePrint.GetRefSvcRoots(CMPY);
        }

        public IList<ClrInvManifestDomainView> GetManifestConsDetail(int companyID, int agencyID, string cons)
        {
            return _clearencePrint.GetManifestConsDetail(companyID, agencyID, cons);
        }

        public IList<TaxInvoiceSummeryDomainView> GetClearenceSummaryDutyPrint(InvoiceDutyClearencePara _param)
        {
            return _clearencePrint.GetClearenceSummaryDutyPrint(_param);
        }
    }
}
