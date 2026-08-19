using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public  class ConsoleTypeResult
    {
        public int ConsoleT { get; set; }
        public string ConsoleTypeN { get; set; }
        public string Remark { get; set; }
    }
}
