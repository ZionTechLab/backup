using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Crm.CfgTransportMethods")]
    public partial class CfgTransportMethod
    {
        [Key]
        public int TransportId { get; set; }

        [StringLength(10)]
        public string TranstortCode { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Decription { get; set; }

        [StringLength(1)]
        public string Active { get; set; }
    }
}
