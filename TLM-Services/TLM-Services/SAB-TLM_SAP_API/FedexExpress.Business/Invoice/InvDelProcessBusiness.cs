using Express.Interfaces.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.Login;
using Express.View.Domain.Invoice;
using Express.Domain.Message;
using Express.View.Domain.Report.Invoice;

namespace Express.Business.Invoice
{
    public class InvDelProcessBusiness : IInvDelInvoiceProcess
    {
        private readonly IInvDelInvoiceProcess _provider;
        public InvDelProcessBusiness(IInvDelInvoiceProcess _provider)
        {
            this._provider = _provider;
        }

        public ResponseMessage DelBillingProcess(InvDelProcessPramDomainView _para)
        {
            return _provider.DelBillingProcess(_para);
        }

        public ResponseMessage DelInvoiceProcess(InvDelProcessPramDomainView _para)
        {
            return _provider.DelInvoiceProcess(_para);
        }

        public IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId)
        {
           return  _provider.GetAgencyDetail(UserId, ModuleId, MenueId);
        }

        public InvDelProcessDomainView GetPodInvoiceDetail(InvDelProcessPramDomainView _para)
        {
            return _provider.GetPodInvoiceDetail(_para);
        }

        public InvDelProcessDomainView GetPodSummeryDetail(InvDelProcessPramDomainView _para)
        {
            return _provider.GetPodSummeryDetail(_para);
        }

        public IList<InvDellInvoiceReportDomainView> PreviewData(DateTime TransDate, int AgencyCode)
        {
            return _provider.PreviewData(TransDate, AgencyCode);
        }

        public IList<InvoiceDeliveryDetailDomainView> PreviewData_InvoiceDeliveryDetail(int InvoiceNo, int CMPY, int AgencyCode)
        {
            return _provider.PreviewData_InvoiceDeliveryDetail(InvoiceNo, CMPY, AgencyCode);
        }

        public IList<InvoiceDeliverySummaryDomainView> PreviewData_InvoiceSummery(int InvoiceNo, int CMPY, int AgencyCode)
        {
            return _provider.PreviewData_InvoiceSummery(InvoiceNo, CMPY, AgencyCode);
        }

        public IList<InvDellInvoiceReportDomainView> PreviewData_NotInvoiced(DateTime LastScanDate, int AgencyCode)
        {
            return _provider.PreviewData_NotInvoiced(LastScanDate, AgencyCode);
        }

        public IList<InvDellInvoiceReportDomainView> PreviewData_PendingDeliverd(DateTime LastScanDate, int AgencyCode)
        {
            return _provider.PreviewData_PendingDeliverd(LastScanDate, AgencyCode);
        }
    }
}
