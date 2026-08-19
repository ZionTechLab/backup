using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public partial class ResponseProcessResult
    {
        public string ResponseMessage { get; set; }
        public string ReturnValue { get; set; }
        public string ReturnValue2 { get; set; }
    }
}
