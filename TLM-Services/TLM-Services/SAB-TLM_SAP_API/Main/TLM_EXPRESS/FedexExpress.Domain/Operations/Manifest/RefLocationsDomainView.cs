using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Operations.Manifest
{
    [NotMapped]
    public class RefLocationsDomainView
    {
        public string Country { get; set; }
        public string LocationID { get; set; }
        public string LocationName { get; set; }
        public string Hub { get; set; }
        public string GateWay { get; set; }
        public string Station { get; set; }
        public string SalesCode { get; set; }
        public string Remarks { get; set; }
        public string Active { get; set; }
    }
}
