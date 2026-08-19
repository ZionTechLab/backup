using Express.View.Domain.Invoice;
using Express.View.Domain.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Invoice.InvoiceHelper.DelInvoiceProcess
{
   public interface IDelInvoicePreview
    {
        IList<AgencyDomainViewcs> GetAgencyDetail(int UserId, int ModuleId, int MenueId);
        InvDelProcessDomainView GetPodSummeryDetail(InvDelProcessPramDomainView _para);
        void PreviewData(DateTime TransDate, int AgencyCode);
        void PreviewData_PendingDeliverd(DateTime LastScanDate, int AgencyCode);
        void PreviewData_NotInvoiced(DateTime LastScanDate, int AgencyCode);
        void PreviewData_InvoiceSummery(int InvoiceNo, int CMPY, int AgencyCode);
        void  PreviewData_InvoiceDeliveryDetail(int InvoiceNo, int CMPY, int AgencyCode);
        InvDelProcessDomainView GetPodInvoiceDetail(InvDelProcessPramDomainView _para);
    }
}
