using Express.View.Domain.Operations.Manifest;
using Express.View.Domain.Report.Operation;
using FedexExpress.View.Domain.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Report.Operation
{
    public interface IOperationReportProvider
    {
        void GetManiferReport(IList<RptManifestDomainView> _para ,string _searchStr);
        void GetPreManifestReport(IList<RptPreManifestDomainView> _para ,string _searchStr);
        void GetPrincipleAccountsReport(IList<PrincipleAccountsView> _para);
        void GetPodScanReport(IList<PodScanRptDomainView> para);
    }
}
