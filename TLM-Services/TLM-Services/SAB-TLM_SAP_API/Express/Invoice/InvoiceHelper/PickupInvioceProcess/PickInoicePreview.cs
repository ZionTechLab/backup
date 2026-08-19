using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.Invoice;
using Express.View.Domain.Login;
using Express.Interfaces.Invoice;
using Express.UI.Factory.Invoice;
using Express.UI.Common.Helpers;
using Express.UI.Helpers;
using Express.View.Domain.Report.Invoice;
using FedexExpress.View.Domain.Pricing;
using Express.Interfaces.Report.Invoice;
using Express.UI.Factory.Report.Invoice;
using Express.Interfaces.Report;
using Express.UI.Factory.Report;
using Express.UI.Common.CustomValidators;

namespace Express.UI.Invoice.InvoiceHelper.PickupInvioceProcess
{
    public class PickInoicePreview : IPickInvoicePreview
    {
        private readonly IInvPickProcessRepo _pickProvider;
        private readonly IInvoiceReportProvider _report;
        private IGeneralReport _generalRpt;
        public PickInoicePreview()
        {
            _pickProvider = InvoiceUIFactory.GetService<IInvPickProcessRepo>();
            _report = RptInvoiceUIFactory.GetService<IInvoiceReportProvider>();
            _generalRpt = GeneralnvoiceUIFactrory.GetService<IGeneralReport>();
        }
        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return _pickProvider.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public IList<InvDelDocTypes> GetPickDocTypes(int companyID, int agencyID, string category)
        {
            if(companyID ==0)
            {
                return null;
            }

            if(agencyID ==0)
            {
                return null;
            }
            return _pickProvider.GetPickDocTypes(companyID, agencyID, category);
        }

        public InvPickProcessDomainView GetPickInvoiceDetail(InvPickProcessPramDomainView _para)
        {
            if (_para.InvoiceNo == null || _para.InvoiceNo == "" || _para.InvoiceNo == "0")
            {
                MessageNotification.MessageBoxError("Please enter invoice no", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }

            if (_para.AgencyID == 0)
            {
                MessageNotification.MessageBoxError("Please select agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }

            if (_para.CompanyID == 0)
            {
                MessageNotification.MessageBoxError("Please select company ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }

            if (_para.DocType == null || _para.DocType == "")
            {
                MessageNotification.MessageBoxError("Please select doc type ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }

            if(! NumberValidator.TryPassInteger(_para.InvoiceNo ))
            {
                MessageNotification.MessageBoxError("Please enter valid invoice no ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }
            return _pickProvider.GetPickInvoiceDetail(_para);
        }

        public InvPickProcessDomainView GetPickSummeryDetail(InvPickProcessPramDomainView _para)
        {
            if(_para.DocType ==null || _para.DocType =="")
            {
                MessageNotification.MessageBoxError("Please select doc type ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }

            if(_para.BillOrgCode ==0 )
            {
                MessageNotification.MessageBoxError("Please select doc type to pick bill customer ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }
            
            return _pickProvider.GetPickSummeryDetail(_para);
        }

        public void GetRptPickupBillingPending(InvPickProcessPramDomainView _para)
        {

            if (_para.AgencyID == 0)
            {
                MessageNotification.MessageBoxError("Please select agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }
            var _billpending =  _pickProvider.GetRptPickupBillingPending(_para);
            _report.GetRptPickupBillingPending(_para, _billpending);
           
        }
        

        public void GetRptPickupDetail(InvPickProcessPramDomainView _para)
        {
            if (_para.AgencyID == 0)
            {
                MessageNotification.MessageBoxError("Please select agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if (_para.DocType == null || _para.DocType == "")
            {
                MessageNotification.MessageBoxError("Please select doc type ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if (_para.InvoiceNo == null || _para.InvoiceNo == "" || _para.InvoiceNo == "0")
            {
                MessageNotification.MessageBoxError("Please enter invoice no ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if (!NumberValidator.TryPassInteger(_para.InvoiceNo))
            {
                MessageNotification.MessageBoxError("Please enter valid invoice no ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return ;
            }

            var _invoicedetail = _pickProvider.GetRptPickupDetail(_para);
            var _company = _generalRpt.GetCompany(_para.CompanyID);
            _report.GetRptPickupDetail(_para, _invoicedetail , _company);
        }

        public void GetRptPickupInvoicePending(InvPickProcessPramDomainView _para)
        {
            if (_para.AgencyID == 0)
            {
                MessageNotification.MessageBoxError("Please select agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if(_para.DocType ==null || _para.DocType =="")
            {
                MessageNotification.MessageBoxError("Please select doc type ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }
            var _invpending = _pickProvider.GetRptPickupInvoicePending(_para);
            _report.GetRptPickupInvoicePending(_para ,_invpending );
        }

        public void GetRptPickupSummary(InvPickProcessPramDomainView _para)
        {
            if (_para.AgencyID == 0)
            {
                MessageNotification.MessageBoxError("Please select agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if (_para.DocType == null || _para.DocType == "")
            {
                MessageNotification.MessageBoxError("Please select doc type ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }


            if (_para.InvoiceNo  == null || _para.InvoiceNo == "" || _para.InvoiceNo == "0")
            {
                MessageNotification.MessageBoxError("Please enter invoice no ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if (!NumberValidator.TryPassInteger(_para.InvoiceNo))
            {
                MessageNotification.MessageBoxError("Please enter valid invoice no ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return ;
            }


            var _summary =  _pickProvider.GetRptPickupSummary(_para);
            var _company = _generalRpt.GetCompany(_para.CompanyID);
            _report.GetRptPickupSummary(_para, _summary , _company);

        }
    }
}
