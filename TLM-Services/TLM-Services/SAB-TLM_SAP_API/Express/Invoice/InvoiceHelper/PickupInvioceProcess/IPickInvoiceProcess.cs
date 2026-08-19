using Express.Domain.Message;
using Express.View.Domain.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Invoice.InvoiceHelper.PickupInvioceProcess
{
    public interface IPickInvoiceProcess
    {
        ResponseMessage PickBillingProcess(InvPickProcessPramDomainView _para);
        ResponseMessage PickInvProcess(InvPickProcessPramDomainView _para);
    }
}
