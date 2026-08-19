using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Invoice;
using Express.UI.Factory.Invoice;
using Express.Interfaces.Invoice;

namespace Express.UI.Invoice.InvoiceHelper.PickupInvioceProcess
{
    public class PickInvoiceProcess : IPickInvoiceProcess
    {
        private readonly Interfaces.Invoice.IInvPickProcessRepo _pickProvider;
        public PickInvoiceProcess()
        {
            _pickProvider = InvoiceUIFactory.GetService<IInvPickProcessRepo>();
        }
        public ResponseMessage PickBillingProcess(InvPickProcessPramDomainView _para)
        {
            ResponseMessage responce = new ResponseMessage();
            responce = IsValid(responce, _para);

            if (responce.IsSuccess == false)
            {
                return responce;
            }

            if (_para.ToBillAwbCount == 0)
            {
                responce.StrMessage = "There are no delivery airwaybills to bill ";
                responce.IsSuccess = false;
                return responce;
            }
            return _pickProvider.PickBillingProcess(_para);
        }

        public ResponseMessage PickInvProcess(InvPickProcessPramDomainView _para)
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

            return _pickProvider.PickInvoiceProcess(_para);
        }


        private ResponseMessage IsValid(ResponseMessage responce, InvPickProcessPramDomainView _para)
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
