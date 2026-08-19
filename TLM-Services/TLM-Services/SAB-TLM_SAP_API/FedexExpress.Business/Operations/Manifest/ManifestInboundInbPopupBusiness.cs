using Express.Interfaces.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Operations.Manifest;
using Express.View.Domain.Invoice;

namespace Express.Business.Operations.Manifest
{
    public class ManifestInboundInbPopupBusiness: IManifestInboundInvPopup
    {
        private readonly IManifestInboundInvPopup _manifetInv;
        public ManifestInboundInbPopupBusiness(IManifestInboundInvPopup _manifetInv)
        {
            this._manifetInv = _manifetInv;
        }

        public IList<InvDutyClrPayAccountDomainView> GetClrPayAccounts(int companyID)
        {
            return _manifetInv.GetClrPayAccounts(companyID);
        }

        public ResponseMessage ProcessCostInvoice(ManifestInbLVProPramDomainView _para)
        {
            return _manifetInv.ProcessCostInvoice(_para);
        }
    }
}
