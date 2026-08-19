using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MHE_Api.Models
{
    public class RatesFind_Parameters
    {
        public string CustomerICPC { get; set; }
        public string  ServiceType { get; set; }
        public string  FromCountry { get; set; }
        public string ToCountry { get; set; }
        public string PackingMaterial { get; set; }
        public decimal Weight { get; set; }
        public string DocNDoc { get; set; }
        
    }
}

