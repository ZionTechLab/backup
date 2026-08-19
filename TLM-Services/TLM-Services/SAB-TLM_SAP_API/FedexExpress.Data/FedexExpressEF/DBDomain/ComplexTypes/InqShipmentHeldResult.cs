using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    public class InqShipmentHeldResult
    {
        public string Gateway { get; set; }
        public int Day1 { get; set; }
        public int Day2 { get; set; }
        public int Day3 { get; set; }
        public int Day4 { get; set; }
        public int Day5 { get; set; }
        public int Day6 { get; set; }
        public int Day7 { get; set; }
        public int MoreThanDay10 { get; set; }
        public int LineTotal { get; set; }
    }
}
