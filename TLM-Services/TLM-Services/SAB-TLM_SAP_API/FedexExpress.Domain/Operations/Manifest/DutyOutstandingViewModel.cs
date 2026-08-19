using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Operations.Manifest
{
    public class DutyOutstandingViewModel
    {
        public int No { get; set; }
        public string Delivered { get; set; }
        public string DeliveredStr { get; set; }
        public string GateWayID { get; set; }
        public string StationID { get; set; }
        public string RouteID { get; set; }
        public string Courier { get; set; }
        public DateTime InvDate { get; set; }
        public int InvNo { get; set; }
        public string AgnAwbNo { get; set; }
        public int OrgCode { get; set; }
        public string OrgName { get; set; }
        public string PayMode { get; set; }
        public decimal InvAmt { get; set; }

        public string CompanyName { get; set; }

        public string FilterBy { get; set; }

        public string CompName { get; set; }


    }
}
