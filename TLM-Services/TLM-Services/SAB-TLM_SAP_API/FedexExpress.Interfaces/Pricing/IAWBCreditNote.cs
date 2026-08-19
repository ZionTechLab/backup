using Express.Domain.Message;
using Express.Interfaces.Common;
using Express.View.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Pricing
{
    public interface IAWBCreditNote<T> : IDataAccess<T> where T : class
    {
        IList<AWBCreditView> GetAWBCredits(string model);
        IList<AWBCreditView> GetInvoiceDetailFromDebt(decimal invoiceNo);
        IList<AWBCreditView> GetCreditNoteDetailFromDebt(decimal CreditNoteNo);
        IList<AWBCreditNoteDetailDomainViewcs> GetCreditNoteDataFromJobTrance(int CMPY, int AgencyCode, long InvoiceNo);
        IList<AWBCreditNoteDetailDomainViewcs> GetCreditNoteData(int CMPY, int AgencyCode, Int64 InvoiceNo, string AWBNo);
        ResponseMessage SaveCreditNoteDetails(AWBCreditNoteWrappingDomainView typePara);

        IList<AWBCreditView> PreviewData(decimal CreditNoteNo);
    }
}
