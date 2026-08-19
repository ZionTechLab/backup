using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Invoice;
using Express.Interfaces.Invoice;
using Express.UI.Factory.Invoice;

namespace Express.UI.Invoice.InvoiceHelper.DelInvoiceProcess
{
    public class DelInvoiceProcess : IDelInvProcess
    {
        private readonly IInvDelInvoiceProcess _delProvider;
        public DelInvoiceProcess()
        {
            _delProvider = InvoiceUIFactory.GetService<IInvDelInvoiceProcess>();
        }
        public ResponseMessage DelBillingProcess(InvDelProcessPramDomainView _para)
        {
            ResponseMessage responce = new ResponseMessage();
            responce= IsValid(responce, _para);

            if(responce.IsSuccess ==false )
            {
                return responce;
            }

            if (_para.ToBillAwbCount ==0)
            {
                responce.StrMessage = "There are no delivery airwaybills to bill ";
                responce.IsSuccess = false;
                return responce;
            }
           return   _delProvider.DelBillingProcess(_para);
        }

       public  ResponseMessage DelInvProcess(InvDelProcessPramDomainView _para)
        {
            ResponseMessage responce = new ResponseMessage();
            responce = IsValid(responce, _para);

            if (responce.IsSuccess == false)
            {
                return responce;
            }

            if (_para.ToBillAwbCount == 0)
            {
                responce.StrMessage = "Can find data to process invoice";
                responce.IsSuccess = false;
                return responce;
            }
            
            return _delProvider.DelInvoiceProcess(_para);
        }


        private ResponseMessage IsValid(ResponseMessage responce , InvDelProcessPramDomainView _para)
        {
            responce.IsSuccess = false;
            if (_para.AgencyID == 0)
            {
                responce.StrMessage = "Please select agency";
                return responce;
            }

            if (_para.CompanyID == 0)
            {
                responce.StrMessage = "Please select company";
                return responce;
            }
            if (_para.BillOrgCode == 0)
            {
                responce.StrMessage = "Billing customer can not be empty";
                return responce;
            }

            if (_para.DocType == null || _para.DocType == "")
            {
                responce.StrMessage = "Please select document type";
                return responce;
            }
            responce.IsSuccess = true;
            return responce;

        }



    }
}
