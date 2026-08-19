using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.Login;
using Express.Interfaces.Invoice;
using Express.UI.Factory.Invoice;
using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Invoice;
using Express.UI.Helpers;
using Express.UI.Common.Helpers;
using Express.UI.Common.CustomValidators;
using FedexExpress.View.Domain.Pricing;

namespace Express.UI.Invoice.InvoiceHelper.FrightInvoiceProcess
{
    public class InvFrtPocessLoad : IFrtProcessLoad
    {
        private readonly IInvFrtProcessPrint _frtProvider;
        public InvFrtPocessLoad()
        {
            _frtProvider = InvoiceUIFactory.GetService<IInvFrtProcessPrint>();
           
        }
        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return _frtProvider.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public IList<InvFrtPrintProcessDomainView> GetFrtBillingDetail(InvFrtPrintProcessParaDomainView _para, InvFrtShipTypes _shipType)
        {
            if(_para.CompanyID ==0)
            {
                MessageNotification.MessageBoxError("Please select company ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }
            if(_para.AgencyCode ==0 )
            {
                MessageNotification.MessageBoxError("Please select agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }

            if(_para.DocType=="")
            {
                MessageNotification.MessageBoxError("Please select doctype ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }

            if(_para.IsPeriodic ==1 &&  _para.InvMode == "")
            {
                MessageNotification.MessageBoxError("Please select periodic type ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }

            if(_para.IsCutormer ==1 && _para.OrgCode ==0 )
            {
                MessageNotification.MessageBoxError("Please select Customer ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }


            _para.ShipType = GetShipType(_shipType);
            _para.InvModeXml = GetInvMode(_para);
            return _frtProvider.GetFrtBillingDetail(_para);
        }

        public IList<InvProcessModeDomainView> GetInvProcessMode()
        {
            return _frtProvider.GetInvProcessMode();
        }

        private string  GetShipType(InvFrtShipTypes type)
        {
            string _sType = "";
            switch (type)
            {
                case InvFrtShipTypes.OUTBOUND: _sType = "O";
                    break;
                case InvFrtShipTypes.INBOUND:_sType = "I";
                    break;
                case InvFrtShipTypes.TPARTY: _sType= "T";
                    break;
                case InvFrtShipTypes.DOMESTIC:_sType = "D";
                    break;
                
            }

            return _sType;
        }

        private string GetInvMode(InvFrtPrintProcessParaDomainView _para)
        {
            string xmlString = "";
            if(_para.IsPeriodic ==1 )
            {
                xmlString = "<ROOT>";
                switch(_para.InvMode)
                {
                    case "D":
                        xmlString = xmlString + "<ROW><InvMode>" + "D" + "</InvMode></ROW>";
                        break;
                    case "W":
                        xmlString = xmlString + "<ROW><InvMode>" + "D" + "</InvMode></ROW>";
                        xmlString = xmlString + "<ROW><InvMode>" + "W" + "</InvMode></ROW>";
                        break;
                    case "F":
                        xmlString = xmlString + "<ROW><InvMode>" + "D" + "</InvMode></ROW>";
                        xmlString = xmlString + "<ROW><InvMode>" + "W" + "</InvMode></ROW>";
                        xmlString = xmlString + "<ROW><InvMode>" + "F" + "</InvMode></ROW>";
                        break;
                    case "M":
                        xmlString = xmlString + "<ROW><InvMode>" + "D" + "</InvMode></ROW>";
                        xmlString = xmlString + "<ROW><InvMode>" + "W" + "</InvMode></ROW>";
                        xmlString = xmlString + "<ROW><InvMode>" + "F" + "</InvMode></ROW>";
                        xmlString = xmlString + "<ROW><InvMode>" + "M" + "</InvMode></ROW>";
                        break;

                }

                xmlString = xmlString + "</ROOT>";
            }
            return xmlString;
        }

        public IList<InvFrtPrintProcessDomainView> GetFrtInvoiceDetail(InvFrtPrintProcessParaDomainView _para, InvFrtShipTypes _shipType)
        {
            if (_para.CompanyID == 0)
            {
                MessageNotification.MessageBoxError("Please select company ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }
            if (_para.AgencyCode == 0)
            {
                MessageNotification.MessageBoxError("Please select agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }

            if(_para.DocType.Trim() =="")
            {
                MessageNotification.MessageBoxError("Please select document type ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }         

            if(_para.IsInvNumberRange ==1)
            {
                if(! NumberValidator.TryPassInteger(_para.FromInvNo ))
                {
                    MessageNotification.MessageBoxError("Please enter a value to Invoice number range (From)", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return null;
                }

                if (!NumberValidator.TryPassInteger(_para.ToInvNo))
                {
                    MessageNotification.MessageBoxError("Please enter a value to Invoice number range (To)", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return null;
                }

                
            }

            if( _para.IsInvDateRange ==1)
            {
                if(_para.DtFrom =="")
                {
                    MessageNotification.MessageBoxError("Please select from date ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return null;
                }

                if (_para.DtTo  == "")
                {
                    MessageNotification.MessageBoxError("Please select to date ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return null;
                }
            }

                    
            return _frtProvider.GetFrtInvoiceDetail(_para);
        }

        public IList<InvoiceTypeCategoryDomainView> DocumentTypes(int companyId, int agencyID)
        {
            return _frtProvider.DocumentTypes(companyId, agencyID);
        }
    }
}
