using Express.Domain.Message;
using Express.View.Domain.Invoice;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Operations.Manifest
{
   public interface IManifestInboundInvPopup
    {
        ResponseMessage ProcessCostInvoice(ManifestInbLVProPramDomainView _para);
        IList<InvDutyClrPayAccountDomainView> GetClrPayAccounts(int companyID);

    }
}
