using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.Com
{
    public class CommishionDateSlab
    {
        public bool isSelected { get; set; }
        public int id { get; set; }
        public string slabName { get; set; }
        public decimal deductionAmount { get; set; }
    }
}