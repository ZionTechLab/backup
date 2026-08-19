using Express.Interfaces.Common;
using Express.View.Domain.Invoice;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using Express.View.Domain.Report.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Invoice
{
    public interface IClrInvPrinting
    {
        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);
        IList<GatewayDomainView> GetGateways(string CountryID);
        IList<RefLocationsDomainView> GetRefLocationsStations();
        IList<RefSvcRootsDomainView> GetRefSvcRoots(int CMPY);
        IList<ClrInvDomainView> GetClearenceInvoices(ClrInvParamDomainView _param);
       /// IList<ClrInvDomainView> GetInvoiceDTAX_InvoiceNoRange(string AgncyID, int From, int To);
        IList<OpsConsMasterDomainView> GetOpsConsMaster(string AgncyID, int CMPY);
      ///  IList<CfgDtaxDocTypesDomainView> GetCfgDtaxDocTypes();
        ////ClrInvDetorDomainView GetInvoiceAmount(decimal DocNo);
        IList<ClrInvDocTypesDomainView> GetCfgDoctypes(int CMPY, int AgncyCode);
        IList<TaxInvoiceReportDomainView> GetClearenceDutyPrint(InvoiceDutyClearencePara _param);
        IList<TaxInvoiceSummeryDomainView> GetClearenceSummaryDutyPrint(InvoiceDutyClearencePara _param);
        IList<ClrInvManifestDomainView> GetManifestConsDetail(int companyID, int agencyID, string cons);

    }
}
