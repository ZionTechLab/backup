using Express.Domain.Message;
using Express.View.Domain.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Invoice.InvoiceHelper.DelInvoiceProcess
{
    public interface IDelInvProcess
    {
        ResponseMessage DelBillingProcess(InvDelProcessPramDomainView _para);
        ResponseMessage DelInvProcess(InvDelProcessPramDomainView _para);

    }
}
