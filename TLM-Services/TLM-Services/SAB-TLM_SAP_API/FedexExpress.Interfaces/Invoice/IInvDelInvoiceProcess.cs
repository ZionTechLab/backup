using Express.Domain.Message;
using Express.View.Domain.Invoice;
using Express.View.Domain.Login;
using Express.View.Domain.Report.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Invoice
{
    public interface IInvDelInvoiceProcess
    {
        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);
        InvDelProcessDomainView GetPodSummeryDetail(InvDelProcessPramDomainView _para);
        ResponseMessage DelBillingProcess(InvDelProcessPramDomainView _para);
        ResponseMessage DelInvoiceProcess(InvDelProcessPramDomainView _para);
        IList<InvDellInvoiceReportDomainView> PreviewData(DateTime TransDate, int AgencyCode);
        IList<InvDellInvoiceReportDomainView> PreviewData_PendingDeliverd(DateTime LastScanDate, int AgencyCode);
        IList<InvDellInvoiceReportDomainView> PreviewData_NotInvoiced(DateTime LastScanDate, int AgencyCode);
        IList<InvoiceDeliverySummaryDomainView> PreviewData_InvoiceSummery(int InvoiceNo, int CMPY, int AgencyCode);
        IList<InvoiceDeliveryDetailDomainView> PreviewData_InvoiceDeliveryDetail(int InvoiceNo, int CMPY, int AgencyCode);
        InvDelProcessDomainView GetPodInvoiceDetail(InvDelProcessPramDomainView _para);
    }
}
