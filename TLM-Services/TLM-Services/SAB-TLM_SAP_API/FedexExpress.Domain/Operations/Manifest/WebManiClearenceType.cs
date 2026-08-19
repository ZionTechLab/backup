using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Operations.Manifest
{
   public class WebManiClearenceType
    {
        public string ShipValType { get; set; }
        public int ShipTypeCount { get; set; }
        public decimal ShipTypeValue { get; set; }
        public decimal ShipTypeDuty { get; set; }
        public bool IsSelect { get; set; }
    }
}
