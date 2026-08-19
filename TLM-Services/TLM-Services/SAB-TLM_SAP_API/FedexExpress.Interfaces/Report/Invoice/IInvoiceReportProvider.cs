using Express.View.Domain.Invoice;
using Express.View.Domain.Report.General;
using Express.View.Domain.Report.Invoice;
using FedexExpress.View.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Report.Invoice
{
    public interface IInvoiceReportProvider
    {
        void ClearenceDutyPrint(IList<TaxInvoiceReportDomainView> _rptData, IList<CompanyReportDomainView> _company);

        void ClearenceDutyPrintExport(IList<TaxInvoiceReportDomainView> _rptData, IList<CompanyReportDomainView> _company, string InvNo);

        void ClearenceSummaryDutyPrint(IList<TaxInvoiceSummeryDomainView> _rptData, string rptPara);
        void ClearenceDutyPrintDirect(IList<TaxInvoiceReportDomainView> _rptData, IList<CompanyReportDomainView> _company);

        void PrintAirwabilDetail(IList<InvFrtPrintProcessDomainView> _pendingInv, InvFrtPrintProcessParaDomainView _para);
        void PrintInvAirwabilDetail(IList<InvFrtPrintProcessDomainView> _pendingInv, InvFrtPrintProcessParaDomainView _para);

        void PrintInvFrtDetailReport(IList<FrtInvoiceReportDomainView> _pendingInv, IList<CompanyReportDomainView> _company , InvFrtPrintProcessParaDomainView _para);
        void PrintInvFrtSummaryReport(IList<FrtInvoiceSummeryDomainView> _pendingInv, IList<CompanyReportDomainView> _company , InvFrtPrintProcessParaDomainView _para);

        void InvDellInvoice_NotDelivered(IList<InvDellInvoiceReportDomainView> _rptData);
        void InvDellInvoice_PendingDelivered(IList<InvDellInvoiceReportDomainView> _rptData);
        void InvDellInvoice_NotInvoiced(IList<InvDellInvoiceReportDomainView> _rptData);
        void InvDellInvoice_InvoiceSummery(IList<InvoiceDeliverySummaryDomainView> _rptData);
        void InvDellInvoice_InvoiceDeliveryDeatil(IList<InvoiceDeliveryDetailDomainView> _rptData);


        void GetRptPickupBillingPending(InvPickProcessPramDomainView _para, IList<InvoicePickupRptDomainView> _billing);
        void GetRptPickupInvoicePending(InvPickProcessPramDomainView _para, IList<InvoicePickupRptDomainView> _invoicing);
        void GetRptPickupSummary(InvPickProcessPramDomainView _para , IList<InvoicePickupRepSummeryDomainView> _invsummery, IList<CompanyReportDomainView> _company);
        void GetRptPickupDetail(InvPickProcessPramDomainView _para , IList<InvoicePickupRepDetailDomainView> _invdetail, IList<CompanyReportDomainView> _company);
    }
}
