using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Pricing
{
    public class SpotRatesAWBDomainView
    {
        public String AWBNo { get; set; }
        public String ExpressID { get; set; }
        public int CMPY { get; set; }
        public int AgencyCode { get; set; }
        public string TrackNo { get; set; }
        public DateTime TransDate { get; set; }
        public string BillTransChgY { get; set; }
        public decimal InvNoTransChg { get; set; }


    }
}
