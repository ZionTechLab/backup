using Express.Domain.Message;
using Express.View.Domain.SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.SAP
{
    public interface ISAPInvoice
    {
        IList<InvoiceHeaderView> GetInvoiceHeader(string ACDocNo);
        IList<InvoiceHeaderView> GetReversalHeader(string ACRevNo);
        IList<AccountGLViewModel> GetAccountGL(string ACDocNo);

        IList<AccountReceivableViewModel> GetAccountReceivable(string ACDocNo);

        IList<AccountTaxViewModel> GetAccountTax(string ACDocNo);

        IList<CurrencyAmountViewModel> GetCurrencyAmount(string ACDocNo);
        ResponseMessage UpdateSuccess(InvoiceHeaderView InvHed);
        ResponseMessage UpdateError(InvoiceHeaderView InvHed);
        IList<InvoiceResendHeader> GetInvoiceResendList(string ACDocNo);

        IList<AccountGLView> GetInvoiceGLResendList(string ACDocNo);


        IList<CustomerCpdViewModel> GetCustomerCpd(string ACDocNo);


        IList<InvoiceHeaderView> GetInvoiceResendHeader(SapInvoiceResend Resend);
    }
}
