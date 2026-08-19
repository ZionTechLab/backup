
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.Operations.Manifest;
using Express.Interfaces.Invoice;
using Express.Domain.Message;
using Express.View.Domain.Invoice;

namespace Express.Business.Invoice
{
    public class ClrInvOpsRouteChgBusiness : IClrInvOpsRouteChg
    {
       private readonly   IClrInvOpsRouteChg _invClearence;

        public ClrInvOpsRouteChgBusiness(IClrInvOpsRouteChg _invClearence)
        {
            this._invClearence = _invClearence;
        }
        public IList<RefSvcRootsDomainView> GetRefSvcRoots(int CMPY)
        {
            return _invClearence.GetRefSvcRoots(CMPY);
        }

        public ResponseMessage UpdateDutyInvoiceRoute(ClrInvRoutePopParam _param)
        {
            return _invClearence.UpdateDutyInvoiceRoute(_param);
        }
    }
}
