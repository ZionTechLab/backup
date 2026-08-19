using Express.Domain.Message;
using Express.Interfaces.SAP;
using Express.View.Domain.SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Business.SAP
{
    public class InvoiceHeaderBusiness: ISAPInvoice
    {


        private readonly ISAPInvoice SAPInvoiceHeaderData;


        public InvoiceHeaderBusiness(ISAPInvoice _SAPInvoiceHeaderData)
        {
            this.SAPInvoiceHeaderData = _SAPInvoiceHeaderData;
        }



        public IList<InvoiceHeaderView> GetInvoiceHeader(string ACDocNo)
        {
            return SAPInvoiceHeaderData.GetInvoiceHeader(ACDocNo);
        }




        public IList<AccountGLViewModel> GetAccountGL(string ACDocNo)
        {
            return SAPInvoiceHeaderData.GetAccountGL(ACDocNo);
        }



        public IList<AccountReceivableViewModel> GetAccountReceivable(string ACDocNo)
        {
            return SAPInvoiceHeaderData.GetAccountReceivable(ACDocNo);
        }



        public IList<AccountTaxViewModel> GetAccountTax(string ACDocNo)
        {
            return SAPInvoiceHeaderData.GetAccountTax(ACDocNo);
        }


        public IList<CurrencyAmountViewModel> GetCurrencyAmount(string ACDocNo)
        {
            return SAPInvoiceHeaderData.GetCurrencyAmount(ACDocNo);
        }


        public ResponseMessage UpdateSuccess(InvoiceHeaderView InvHed)
        {
            return SAPInvoiceHeaderData.UpdateSuccess(InvHed);
        }


        public ResponseMessage UpdateError(InvoiceHeaderView InvHed)
        {
            return SAPInvoiceHeaderData.UpdateError(InvHed);
        }


        public IList<InvoiceResendHeader> GetInvoiceResendList(string ACDocNo)
        {
            return SAPInvoiceHeaderData.GetInvoiceResendList(ACDocNo);
        }

        public IList<AccountGLView> GetInvoiceGLResendList(string ACDocNo)
        {
            return SAPInvoiceHeaderData.GetInvoiceGLResendList(ACDocNo);
        }


        public IList<CustomerCpdViewModel> GetCustomerCpd(string ACDocNo)
        {
            return SAPInvoiceHeaderData.GetCustomerCpd(ACDocNo);
        }

    }
}
