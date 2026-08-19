using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.SAS
{
    public class Para_DeliveryOrder_Save
    {
        public tbl_sasDeliveryOrder Header { get; set; }
        public List<tbl_sasDeliveryOrder_Detail> Detail { get; set; }
        public string User_ID { get; set; }
        public string Terminal_ID { get; set; }
        public bool IsUpdate { get; set; }
        public string configForm_ID { get; set; }
        public string orderRefNo { get; set; }
    }
}
