using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public  class ClearenceStatusResult
    {
        public int ClearStatusID { get; set; }
        public string ClearStatusN { get; set; }
    }
}
