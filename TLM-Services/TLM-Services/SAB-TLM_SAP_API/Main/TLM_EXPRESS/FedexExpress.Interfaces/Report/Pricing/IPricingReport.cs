using Express.View.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Report.Pricing
{
   public interface IPricingReport
    {
        void PrintFedexReconcile(PrincipleReconDomainView typePara);
        void PrintTnTReconcile(PrincipleReconDomainView typePara);
        void PrintFedexReconcileSummery(PrincipleReconDomainView typePara);
    }
}
