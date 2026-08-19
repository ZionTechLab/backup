using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Report.Operation
{
   public class RptManifestParaDomainView
    {
        public DateTime TrDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string ConsID { get; set; }
        public string TrakNumbers { get; set; }
        public int CompanyID { get; set; }
        public int AgencyId { get; set; }
        public string ShipValType { get; set; }
        public int IsNotInvoiced { get; set; }
        public string PayModes { get; set; }
       
    }
}
