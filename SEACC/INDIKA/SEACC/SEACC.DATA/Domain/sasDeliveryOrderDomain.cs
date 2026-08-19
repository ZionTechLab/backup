using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain
{
    public class sasDeliveryOrderDomain
    {
        public string deliveryOrder_ID { get; set; }
        public DateTime customerDeliveryDate { get; set; }
        public string driver_ID { get; set; }
        public bool isDeliveryDone { get; set; }
        public string deliveryRemarks { get; set; }
        public string driverName { get; set; }
        public string VehicleNo { get; set; }
        public string DeliveryOfficer_ID { get; set; }
        public string DeliveryOfficerName { get; set; }
    }
}
