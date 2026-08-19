using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public  class ClrInvManifestResult
    {
        public string ConsId { get; set; }
        public string FlightNo { get; set; }
        public string GateWayID { get; set; }
    }
}
