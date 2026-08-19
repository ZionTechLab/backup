using Express.Domain.Message;
using Express.View.Domain.Invoice;
using Express.View.Domain.Report.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Invoice.InvoiceHelper.FrightInvoiceProcess
{
    public interface IFrtProcess
    {
        ResponseMessage InvBulkProcess(InvFrtPrintProcessParaDomainView para);
        void PrintAirwabilDetail(IList<InvFrtPrintProcessDomainView> _pendingInv, InvFrtPrintProcessParaDomainView _para);
        void PrintFrtInvoicePreview(InvFrtPrintProcessParaDomainView para , InvFrtInvPrintTypes _printType);
       
    }
}
