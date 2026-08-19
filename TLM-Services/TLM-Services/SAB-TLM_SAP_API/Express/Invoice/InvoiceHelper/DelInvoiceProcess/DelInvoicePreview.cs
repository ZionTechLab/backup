using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.Login;
using Express.Interfaces.Invoice;
using Express.UI.Factory.Invoice;
using Express.View.Domain.Invoice;
using Express.Interfaces.Report.Invoice;
using Express.UI.Factory.Report.Invoice;
using Express.UI.Common.Helpers;
using Express.UI.Helpers;

namespace Express.UI.Invoice.InvoiceHelper.DelInvoiceProcess
{
    public class DelInvoicePreview : IDelInvoicePreview
    {
        private readonly IInvDelInvoiceProcess _delProvider;
        private readonly IInvoiceReportProvider _report;
        public  DelInvoicePreview()
        {           
                _delProvider = InvoiceUIFactory.GetService<IInvDelInvoiceProcess>();
                 _report = RptInvoiceUIFactory.GetService<IInvoiceReportProvider>();
        }
        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
            return _delProvider.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public InvDelProcessDomainView GetPodInvoiceDetail(InvDelProcessPramDomainView _para)
        {
            if (_para.InvoiceNo ==null || _para.InvoiceNo =="" ||  _para.InvoiceNo  == "0")
            {
                MessageNotification.MessageBoxError("Please enter invoice no", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }

            if (_para.AgencyID  == 0)
            {
                MessageNotification.MessageBoxError("Please select agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null;
            }

            if (_para.CompanyID  == 0)
            {
                MessageNotification.MessageBoxError("Please select company ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return null ;
            }
            return _delProvider.GetPodInvoiceDetail(_para);
        }

        public InvDelProcessDomainView GetPodSummeryDetail(InvDelProcessPramDomainView _para)
        {
            return _delProvider.GetPodSummeryDetail(_para);
          
        }

        public void PreviewData(DateTime TransDate, int AgencyCode)
        {

            if (AgencyCode == 0)
            {
                MessageNotification.MessageBoxError("Please select agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            var _invDellInvoice = _delProvider.PreviewData(TransDate, AgencyCode);
            if (_invDellInvoice!=null &&  _invDellInvoice.Count >0)
            {
                _report.InvDellInvoice_NotDelivered(_invDellInvoice);
            }
            else
            {
                MessageNotification.MessageBoxError("There are no data to preview", LoginInfoView.COMPANYNAME, MessagHeaderInfo.InfoError);
            }
               
             
        }

        public void PreviewData_InvoiceDeliveryDetail(int InvoiceNo, int CMPY, int AgencyCode)
        {
            if (InvoiceNo == 0)
            {
                MessageNotification.MessageBoxError("Please enter invoice no", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if (AgencyCode == 0)
            {
                MessageNotification.MessageBoxError("Please select agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if (CMPY == 0)
            {
                MessageNotification.MessageBoxError("Please select company ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }
            var _delInvDetail= _delProvider.PreviewData_InvoiceDeliveryDetail(InvoiceNo, CMPY, AgencyCode);
            if(_delInvDetail !=null)
            {
                _report.InvDellInvoice_InvoiceDeliveryDeatil(_delInvDetail);
            }
            else
            {
                MessageNotification.MessageBoxError("There are no data to preview", LoginInfoView.COMPANYNAME, MessagHeaderInfo.InfoError);
            }
            
        }

        public void PreviewData_InvoiceSummery(int InvoiceNo, int CMPY, int AgencyCode)
        {
            if(InvoiceNo ==0)
            {
                MessageNotification.MessageBoxError("Please enter invoice no", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return ;
            }

            if(AgencyCode ==0)
            {
                MessageNotification.MessageBoxError("Please select agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if (CMPY == 0)
            {
                MessageNotification.MessageBoxError("Please select company ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            var _delInvSummary= _delProvider.PreviewData_InvoiceSummery(InvoiceNo, CMPY, AgencyCode);

            if (_delInvSummary != null)
            {
                _report.InvDellInvoice_InvoiceSummery(_delInvSummary);
            }
            else
            {
                MessageNotification.MessageBoxError("There are no data to preview", LoginInfoView.COMPANYNAME, MessagHeaderInfo.InfoError);
            }
        }

        public void PreviewData_NotInvoiced(DateTime LastScanDate, int AgencyCode)
        {

            if (AgencyCode == 0)
            {
                MessageNotification.MessageBoxError("Please select agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            var _invDellInvoice = _delProvider.PreviewData_NotInvoiced(LastScanDate, AgencyCode);
            if (_invDellInvoice != null && _invDellInvoice.Count > 0)
            {
                _report.InvDellInvoice_NotInvoiced(_invDellInvoice);
            }
            else
            {
                MessageNotification.MessageBoxError("There are no data to preview", LoginInfoView.COMPANYNAME, MessagHeaderInfo.InfoError);
            }
        }

        public void PreviewData_PendingDeliverd(DateTime LastScanDate, int AgencyCode)
        {

            if (AgencyCode == 0)
            {
                MessageNotification.MessageBoxError("Please select agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            var _invDellInvoice = _delProvider.PreviewData_PendingDeliverd(LastScanDate, AgencyCode);
            if (_invDellInvoice != null && _invDellInvoice.Count > 0)
            {
                _report.InvDellInvoice_PendingDelivered(_invDellInvoice);
            }
            else
            {
                MessageNotification.MessageBoxError("There are no data to preview", LoginInfoView.COMPANYNAME, MessagHeaderInfo.InfoError);

            }
        }
    }
}
