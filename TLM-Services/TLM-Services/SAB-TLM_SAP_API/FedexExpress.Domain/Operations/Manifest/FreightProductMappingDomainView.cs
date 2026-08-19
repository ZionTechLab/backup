using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Operations.Manifest
{
   public class FreightProductMappingDomainView 
    {
        public int AgncyCode { get; set;}
        public string Doctype { get; set; }
        public string ProductM { get; set; }
        public string ProductS { get; set; }
        public string SvcType { get; set; }
        public string PackType { get; set; }
        public string DocNDoc { get; set; }
        public decimal WgtFrom { get; set; }
        public decimal WgtTo { get; set; }
        public string Remarks { get; set; }
        public string SvcTypeN { get; set; }
        public string PackTypeN { get; set; }
    }
}
