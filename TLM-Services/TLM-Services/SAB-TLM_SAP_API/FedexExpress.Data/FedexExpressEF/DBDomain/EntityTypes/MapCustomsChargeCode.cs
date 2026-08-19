using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.MapCustomsChargeCode")]
    public partial class MapCustomsChargeCode
    {
        [Key]
        [StringLength(10)]
        public string DocType { get; set; }

        [StringLength(10)]
        public string ChargeCodePr { get; set; }

        [StringLength(10)]
        public string ChargeCode { get; set; }

        [StringLength(50)]
        public string ChargeCodePrN { get; set; }
    }
}