using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Inquiry
{
   public class InqShipmentHeldPara
    {
        public int CompanyID { get; set; }
        public int AgencyId { get; set; }
        public string CompanyN { get; set; }
        public string AgencyN { get; set; }
        public DateTime  Uptodate { get; set; }
        public string GatewayID { get; set; }
        public string GatewayN { get; set; }
        public string StationID { get; set; }
        public string StationN { get; set; }
    }
}
