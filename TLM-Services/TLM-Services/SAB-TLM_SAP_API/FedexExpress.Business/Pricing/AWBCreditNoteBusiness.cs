using Express.Domain.Message;
using Express.Interfaces.Pricing;
using Express.View.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Business.Pricing
{
    public class AWBCreditNoteBusiness : IAWBCreditNote<AWBCreditView>
    {

        private IAWBCreditNote<AWBCreditView> AWBCredietNoteDataProvider;

        public AWBCreditNoteBusiness(IAWBCreditNote<AWBCreditView> awbCreditNote)
        {
            this.AWBCredietNoteDataProvider = awbCreditNote;
        }

        public ResponseMessage DeleteDetail(AWBCreditView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(AWBCreditView typePara)
        {
            throw new NotImplementedException();
        }

        public IList<AWBCreditView> GetAWBCredits(string model)
        {
            throw new NotImplementedException();
        }

        public IList<AWBCreditNoteDetailDomainViewcs> GetCreditNoteData(int CMPY, int AgencyCode, long InvoiceNo, string AWBNo)
        {
            return AWBCredietNoteDataProvider.GetCreditNoteData(CMPY, AgencyCode, InvoiceNo, AWBNo);
        }

        public IList<AWBCreditNoteDetailDomainViewcs> GetCreditNoteDataFromJobTrance(int CMPY, int AgencyCode, long InvoiceNo)
        {
            return AWBCredietNoteDataProvider.GetCreditNoteDataFromJobTrance(CMPY, AgencyCode, InvoiceNo);
        }

        //public IList<AWBCreditView> GetCreditNoteDetailFromDebt(int CreditNoteNo)
        //{
        //    throw new NotImplementedException();
        //}

        public IList<AWBCreditView> GetCreditNoteDetailFromDebt(decimal CreditNoteNo)
        {
            return AWBCredietNoteDataProvider.GetCreditNoteDetailFromDebt(CreditNoteNo);
        }

        public List<AWBCreditView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<AWBCreditView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public List<AWBCreditView> GetDetails(AWBCreditView typePara)
        {
            throw new NotImplementedException();
        }

        //public IList<AWBCreditView> GetInvoiceDetailFromDebt(int invoiceNo)
        //{
        //    throw new NotImplementedException();
        //}

        public IList<AWBCreditView> GetInvoiceDetailFromDebt(decimal invoiceNo)
        {
            return AWBCredietNoteDataProvider.GetInvoiceDetailFromDebt(invoiceNo);
        }

        public IList<AWBCreditView> PreviewData(decimal CreditNoteNo)
        {
            return AWBCredietNoteDataProvider.PreviewData(CreditNoteNo);
        }

        public ResponseMessage SaveCreditNoteDetails(AWBCreditNoteWrappingDomainView typePara)
        {
            return AWBCredietNoteDataProvider.SaveCreditNoteDetails(typePara);
        }

        public ResponseMessage SaveDetails(AWBCreditView typePara)
        {
            return AWBCredietNoteDataProvider.SaveDetails(typePara);
        }

       

    }
}
