using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MHE_Api.Models
{
    public class ESMRevWGTReqTypeDomainView
    {
        public string id { get; set; }
        public DateTime? createdAt { get; set; }
        public string serviceType { get; set; }
        public string inboundOutbound { get; set; }
        public int? mountCode { get; set; }
        public int? mountCode1 { get; set; }
     
    }
}