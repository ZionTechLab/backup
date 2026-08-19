using Express.Interfaces.Invoice;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Invoice;

namespace Express.Business.Invoice
{
    public class ClrInvOpsInvoiceChgBusiness : IClrInvOpsInvoiceChg
    {
        IClrInvOpsInvoiceChg ClrInvPrinting_InvoiceChn;

        public ClrInvOpsInvoiceChgBusiness(IClrInvOpsInvoiceChg _ClrInvPrinting_InvoiceChn)
        {
            this.ClrInvPrinting_InvoiceChn = _ClrInvPrinting_InvoiceChn;
        }
        public IList<OpsConsAWBDomainView> GetOpsConsAWB(int invoiceno, int AgencyID, int CompanyID)
        {
            return ClrInvPrinting_InvoiceChn.GetOpsConsAWB(invoiceno, AgencyID, CompanyID);
        }

        public InvOrgnzCreditDomainView GetOrgnizCreditDetail(int companyID, string orgCode)
        {
            return ClrInvPrinting_InvoiceChn.GetOrgnizCreditDetail(companyID, orgCode);
        }

        public ResponseMessage UpdateDutyInvoiceOrginization(ClrInvOrgnPopParam _param)
        {
            return ClrInvPrinting_InvoiceChn.UpdateDutyInvoiceOrginization(_param);
        }
    }
}
