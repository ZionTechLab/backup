using Express.View.Domain.Inquiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Report.Inquiry
{
    public interface IInquiryReportProvider
    {
        void InvoiceSummaryPrint(IList<InvoiceSummaryDomainView> _rptData);

        void PaymentSummaryPrint(IList<PaymetSummaryDomainView> _rptData);

        void NotInvoiceSummaryPrint(IList<NotInvoiceReportDomainView> _rptData);

        void ClearanceAnalysisPrint(IList<ClearanceAnalysisDomainView> _rptData);
        void PrintShipmentHeldSammery(IList<InqShipmetHeldDomainView> _rptData, InqShipmentHeldPara para);
    }
}
