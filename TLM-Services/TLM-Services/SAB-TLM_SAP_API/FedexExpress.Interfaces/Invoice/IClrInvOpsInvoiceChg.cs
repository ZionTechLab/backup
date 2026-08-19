using Express.Domain.Message;
using Express.View.Domain.Invoice;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Invoice
{
    public interface IClrInvOpsInvoiceChg
    {
        IList<OpsConsAWBDomainView> GetOpsConsAWB(int invoiceno, int AgencyID, int CompanyID);
        ResponseMessage UpdateDutyInvoiceOrginization(ClrInvOrgnPopParam _param);
        InvOrgnzCreditDomainView GetOrgnizCreditDetail(int companyID, string orgCode);

    }
}
